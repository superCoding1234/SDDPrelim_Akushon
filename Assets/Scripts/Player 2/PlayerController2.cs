using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController2 : MonoBehaviour, IPlayerController
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private CapsuleCollider2D coll;
    [SerializeField] private TrailRenderer tr;
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private ParticleSystem ps;
    [SerializeField] private Animator anim;
    [SerializeField] private Weapon weapon;
    [NonSerialized] public Player2Inputs pi2;

    //scripts settings
    [Header("Player Movement")]
    [Header("Ground Layer")] 
    [SerializeField] private LayerMask ground;

    [Header("Movement")]
    [SerializeField] private float jumpHeight = 420f;
    [SerializeField] private float speed = 420f;

    [Header("Dashing")]
    [SerializeField] private float dashStrength = 20f;
    [SerializeField] private float dashTime = .1f;

    [Header("Health")] 
    [SerializeField] private Slider slider;
    [SerializeField] private int maxHealth = 100;
    private float currentHealth;

    [Header("Abilities")] 
    public StandardAbility elemental;
    [SerializeField] private StandardAbility ultimate;
    public GameObject timeSlow;
    public GameObject[] abilityFlags;
    public TimeScaleManager tsm;

    [Header("Death")] 
    //[SerializeField] private TextMeshProUGUI deathMessage;

    #region PlayerMovement
    
    private bool canDash = true;
    private bool dash;
    private bool falling;
    private Vector2 movement;
    private float originalGravityScale;
    
    #endregion
    
    #region Death

    [NonSerialized] public bool isDead;

    #endregion

    #region Abilities

    private Action<GameObject>[] ability;
    private float[] activetimes = new float[2], cooldowns = new float[2];
    private int index;
    private bool isInAbility;
    private float fixedTimeScale, cooldownElement, cooldownSuper;

    #endregion

    // Start is called before the first frame update
    private void Start()
    {
        #region ImportUnityComponents
        
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<CapsuleCollider2D>();
        tr = GetComponent<TrailRenderer>();
        sr = GetComponent<SpriteRenderer>();
        ps = GetComponentInChildren<ParticleSystem>();
        anim = GetComponent<Animator>();
        
        #endregion

        #region InitializeInputs

        pi2 = new Player2Inputs();
        pi2.PlayerMovement.Enable();
        InitializeInputs();
        Debug.Log("PC1 loaded");
        
        #endregion

        #region InitializeVariables

        currentHealth = maxHealth;

        ability = new Action<GameObject>[] {elemental.Activate, ultimate.Activate};

        #endregion
        
        #region VerifyAbilities
        
        if(elemental.abilityType == AbilityType.ultimate || ultimate.abilityType == AbilityType.elemental) Debug.LogWarning("Ability type of " + gameObject + " do not match!");
        cooldowns = new float[2];
        activetimes = new float[2];
        elemental.abilityState = AbilityState.ready;
        ultimate.abilityState = AbilityState.ready;
        elemental.Deactivate(gameObject);
        ultimate.Deactivate(gameObject);
        cooldownElement = elemental.cooldownTime + elemental.activeTime;
        cooldownSuper = ultimate.cooldownTime + ultimate.activeTime;

        #endregion
    }
    private void InitializeInputs()
    {
        #region PlayerMovement

        pi2.PlayerMovement.Dash.started += PlayerMovementDashStarted;
        pi2.PlayerMovement.Shoot.performed += PlayerMovementShootPerformed;
        
        #endregion

        #region Death

        pi2.Death.Reset.performed += DeathResetPerformed;

        #endregion

        #region Abilities

        pi2.Ability.UseAbility.performed += UseAbilityPerformed;
        pi2.Ability.Ability.started += AbilityAbilityStarted;
        pi2.PlayerMovement.Ability.started += PlayerMovementAbilityStarted;

        #endregion
    }

    // Update is called once per frame
    private void Update()
    {
        Health();
        Abilities();
        Death();
        PlayerMovement();
        UpdateCooldownValues();
    }
    
    private void FixedUpdate()
    {
        PlayerMovementPhysics();
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        DeathCollision(collision);
    }
    
    //damage
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
    }

    #region PlayerMovement
    
    private void PlayerMovement()
    {
        movement = pi2.PlayerMovement.Move.ReadValue<Vector2>();

        //dashing
        if (IsGrounded()) canDash = true;

        //update animation
        UpdateAnimations();
    }

    private void PlayerMovementPhysics()
    {
        rb.velocity = new Vector2(movement.x * speed * Time.deltaTime, movement.y > .1f && IsGrounded() ? movement.y * jumpHeight * Time.deltaTime : rb.velocity.y);
        if (dash) StartDashing();
    }
    
    //grounding mechanics (cursed)
    private bool IsGrounded()
    {
        Bounds bounds = coll.bounds;
        return Physics2D.CapsuleCast(bounds.center, bounds.size, CapsuleDirection2D.Vertical, 0f, Vector2.down, .1f, ground);
    }

    //update animations (also cursed)
    private void UpdateAnimations()
    {
        switch (movement.x)
        {
            case > .1f:
                anim.SetBool("facingLeft", false);
                anim.SetBool("isMoving", true);
                transform.GetChild(0).localScale = Vector3.right;
                break;
            case < -.1f:
                anim.SetBool("facingLeft", true);
                anim.SetBool("isMoving", true);
                transform.GetChild(0).localScale = Vector3.left;
                break;
            default:
                anim.SetBool("isMoving", false);
                break;
        }
    }
    
    //dashing functions (cursed)
    private void StartDashing()
    {
        dash = false;
        Vector2 direction = pi2.PlayerMovement.Move.ReadValue<Vector2>().normalized;
        canDash = false;
        Color tmp = sr.color;
        tmp.a = 0.5f;
        tr.emitting = true;
        coll.enabled = false;
        originalGravityScale = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = direction * new Vector2(speed * dashStrength * Time.deltaTime, jumpHeight * Time.deltaTime);
        sr.color = tmp;
        StartCoroutine(StopDashing());
    }

    private IEnumerator StopDashing()
    {
        yield return new WaitForSeconds(dashTime);
        rb.gravityScale = originalGravityScale;
        Color color = sr.color;
        color = new Color(color.r, color.g, color.b, 1);
        sr.color = color;
        tr.emitting = false;
        coll.enabled = true;
    }
    
    #endregion

    #region Health

    private void Health()
    {
        if (Input.GetKeyDown(KeyCode.F)) currentHealth -= 10;
        slider.value = currentHealth;
    }

    #endregion

    #region Death

    private void Death()
    {
        if (currentHealth <= 0 && !isDead)
        {
            anim.SetTrigger("isDead");
            pi2.PlayerMovement.Disable();
            pi2.Ability.Disable();
            pi2.Death.Enable();
            isDead = true;
            //deathMessage.text = "PLAYER1 DIED LMFAO";
            //deathMessage.gameObject.SetActive(true);
            FindFirstObjectByType<AudioManager>().Stop("BattleMusic");
            FindFirstObjectByType<AudioManager>().Stop("BattleMusicMix");
            PlayerPrefs.SetInt("player2Score", PlayerPrefs.GetInt("player2Score", 0) + 1);
        }
    }

    private void DeathCollision(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("KO")) return;
        currentHealth = 0;
    }
    
    private void PlayerMovementDashStarted(InputAction.CallbackContext context)
    {
        if (canDash && movement != Vector2.zero) dash = true;
    }

    private void PlayerMovementShootPerformed(InputAction.CallbackContext context)
    {
        weapon.ShootWeapon();
    }
    
    private void AbilityAbilityStarted(InputAction.CallbackContext context)
    {
        StandardAbility currentAbility = Mod(index, 2) == 0 ? elemental : ultimate;
        isInAbility = false;
        pi2.Ability.Disable();
        pi2.PlayerMovement.Enable();
        currentAbility.OffHoverAbility(gameObject);
    }

    private void PlayerMovementAbilityStarted(InputAction.CallbackContext context)
    {
        Debug.Log("ability overlay on");
        isInAbility = true;
        pi2.Ability.Enable();
        pi2.PlayerMovement.Disable();
    }
    
    private void DeathResetPerformed(InputAction.CallbackContext context)
    {
        pi2.Ability.UseAbility.performed -= UseAbilityPerformed;
        pi2.PlayerMovement.Shoot.performed -= PlayerMovementShootPerformed;
        pi2.PlayerMovement.Dash.started -= PlayerMovementDashStarted;
        pi2.Death.Reset.performed -= DeathResetPerformed;
        pi2.Ability.Ability.started -= AbilityAbilityStarted;
        pi2.PlayerMovement.Ability.started -= PlayerMovementAbilityStarted;
        Destroy(transform.parent.gameObject);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    #endregion

    #region Abilities

    private void Abilities()
    {
        switch (elemental.abilityState)
        {
            case AbilityState.ready:
                break;
            case AbilityState.active:
                activetimes[0] += Time.deltaTime;
                elemental.WhileActive(gameObject);
                if (activetimes[0] >= elemental.activeTime)
                {
                    elemental.Deactivate(gameObject);
                    elemental.abilityState = AbilityState.cooldown;
                    activetimes[0] = 0;
                }
                break;
            case AbilityState.cooldown:
                cooldowns[0] += Time.deltaTime;
                if (cooldowns[0] >= elemental.cooldownTime)
                {
                    elemental.abilityState = AbilityState.ready;
                    cooldowns[0] = 0;
                }
                break;
        }
        switch (ultimate.abilityState)
        {
            case AbilityState.ready:
                break;
            case AbilityState.active:
                activetimes[1] += Time.deltaTime;
                ultimate.WhileActive(gameObject);
                if (activetimes[1] >= ultimate.activeTime)
                {
                    ultimate.Deactivate(gameObject);
                    ultimate.abilityState = AbilityState.cooldown;
                    activetimes[1] = 0;
                }
                break;
            case AbilityState.cooldown:
                cooldowns[1] += Time.deltaTime;
                if (cooldowns[1] >= ultimate.cooldownTime)
                {
                    ultimate.abilityState = AbilityState.ready;
                    cooldowns[1] = 0;
                }
                break;
        }
        if (isInAbility)
        {
            anim.ResetTrigger("superAnimation");
            StandardAbility currentAbility = Mod(index, 2) == 0 ? elemental : ultimate;
            tsm.player1 = true;
            timeSlow.GetComponent<Animator>().SetBool("abilityUse", true);
            currentAbility.OnHoverAbility(gameObject);
            if (pi2.Ability.CycleAbility.WasPressedThisFrame())
            {
                currentAbility.OffHoverAbility(gameObject);
                abilityFlags[Mod(index, 2)].GetComponent<Animator>().SetBool("abilityUse", false);
                index += (int) pi2.Ability.CycleAbility.ReadValue<float>();
            }
            abilityFlags[Mod(index, 2)].GetComponent<Animator>().SetBool("abilityUse", true);
        }
        else
        {
            timeSlow.GetComponent<Animator>().SetBool("abilityUse", false);
            tsm.player1 = false;
            foreach (var o in abilityFlags)
            {
                o.GetComponent<Animator>().SetBool("abilityUse", false);
            }
            index = 0;
            pi2.Ability.Disable();
        }
    }

    private void UpdateCooldownValues()
    {
        if (elemental.abilityState is AbilityState.active or AbilityState.cooldown)
        {
            TextMeshProUGUI textMeshProUGUI = abilityFlags[0].GetComponentInChildren<TextMeshProUGUI>();
            textMeshProUGUI.text = Mathf.FloorToInt(cooldownElement).ToString();
            cooldownElement -= Time.deltaTime;
            if (cooldownElement <= 0 || elemental.abilityState == AbilityState.ready) 
            {
                textMeshProUGUI.text = "";
                cooldownElement = elemental.cooldownTime + elemental.activeTime;
            }
        }
        if (ultimate.abilityState is AbilityState.active or AbilityState.cooldown)
        {
            TextMeshProUGUI textMeshProUGUI = abilityFlags[1].GetComponentInChildren<TextMeshProUGUI>();
            textMeshProUGUI.text = Mathf.FloorToInt(cooldownSuper).ToString();
            cooldownSuper -= Time.deltaTime;
            if (cooldownSuper <= 0 || ultimate.abilityState == AbilityState.ready)
            {
                textMeshProUGUI.text = "";
                cooldownSuper = ultimate.cooldownTime + ultimate.activeTime;
            }
        }
    }

    //cursed mod
    private int Mod(int x, int y)
    {
        return (x % y + y) % y;
    }

    //required to prevent it throwing missing reference exception in input manager - see Death1
    private void UseAbilityPerformed(InputAction.CallbackContext context)
    {
        StandardAbility currentAbility = Mod(index, 2) == 0 ? elemental : ultimate;
        if(currentAbility.abilityState == AbilityState.ready)
        { 
            currentAbility.OffHoverAbility(gameObject);
            ability[Mod(index, 2)](gameObject);
            isInAbility = false;
            currentAbility.abilityState = AbilityState.active;
            pi2.Ability.Disable();
            pi2.PlayerMovement.Enable();
        }else Debug.Log("Ability is not ready");
    }

    #endregion
}
