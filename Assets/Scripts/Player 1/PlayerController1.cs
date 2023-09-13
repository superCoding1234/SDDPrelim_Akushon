using System;
using System.Collections;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController1 : MonoBehaviour, IPlayerController
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private CapsuleCollider2D coll;
    [SerializeField] private TrailRenderer tr;
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private ParticleSystem ps;
    [SerializeField] private Animator anim;
    private Player1Inputs pi;

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
    [SerializeField] private StandardAbility elemental;
    [SerializeField] private StandardAbility ultimate;
    [SerializeField] private GameObject timeSlow;
    [SerializeField] private GameObject[] abilityFlags;
    [SerializeField] private TimeScaleManager tsm;

    [Header("Death")] 
    [SerializeField] private TextMeshProUGUI deathMessage;

    #region PlayerMovement
    
    private bool canDash = true;
    private bool dash;
    private bool falling;
    private Vector2 movement;
    private float originalGravityScale;
    
    #endregion
    
    #region Death

    private bool isDead;

    #endregion

    #region Abilities

    private Action<GameObject>[] ability;
    private float[] activetimes = new float[2], cooldowns = new float[2];
    private int index;
    private bool isInAbility;
    private float fixedTimeScale;

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

        pi = new Player1Inputs();
        pi.PlayerMovement.Enable();
        InitializeInputs();
        Debug.Log("PC1 loaded");
        
        #endregion

        #region InitializeVariables

        currentHealth = maxHealth;

            ability = new Action<GameObject>[] {elemental.Activate, ultimate.Activate};

        #endregion
        
        #region VerifyAbilities
        
        if(elemental.abilityType == AbilityType.ultimate || ultimate.abilityType == AbilityType.elemental) Debug.LogWarning("Ability type of " + gameObject + " do not match!");
        
        #endregion 
    }
    private void InitializeInputs()
    {
        #region PlayerMovement
        
        pi.PlayerMovement.Dash.started += context =>
        {
            if (canDash && movement != Vector2.zero) dash = true;
        };
        pi.PlayerMovement.Shoot.performed += GetComponentInChildren<Weapon>().ShootWeapon;
        
        #endregion

        #region Death

        pi.Death.Reset.performed += context =>
        {
            pi.Ability.UseAbility.performed -= UseAbilityPerformed;
            pi.PlayerMovement.Shoot.performed -= GetComponentInChildren<Weapon>().ShootWeapon;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        };

        #endregion

        #region Abilities

        pi.Ability.UseAbility.performed += UseAbilityPerformed;
        pi.Ability.Ability.started += context =>
        {
            isInAbility = false;
            pi.Ability.Disable();
            pi.PlayerMovement.Enable();
        };
        pi.PlayerMovement.Ability.started += context =>
        {
            isInAbility = true;
            pi.Ability.Enable();
            pi.PlayerMovement.Disable();
        };

        #endregion
    }

    // Update is called once per frame
    private void Update()
    {
        Health();
        Abilities();
        Death();
        PlayerMovement();
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
        movement = pi.PlayerMovement.Move.ReadValue<Vector2>();

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
        Vector2 direction = pi.PlayerMovement.Move.ReadValue<Vector2>().normalized;
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
        sr.color = Color.white;
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
            pi.PlayerMovement.Disable();
            pi.Ability.Disable();
            pi.Death.Enable();
            isDead = true;
            deathMessage.text = "PLAYER1 DIED LMFAO";
            deathMessage.gameObject.SetActive(true);
            FindFirstObjectByType<AudioManager>().Stop("BattleMusic");
            FindFirstObjectByType<AudioManager>().Stop("BattleMusicMix");
        }
    }

    private void DeathCollision(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("KO")) return;
        currentHealth = 0;
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
                if (activetimes[0] >= elemental.activeTime)
                {
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
                if (activetimes[1] >= ultimate.activeTime)
                {
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
            StandardAbility currentAbility = Mod(index, 2) == 0 ? elemental : ultimate;
            tsm.player1 = true;
            timeSlow.GetComponent<Animator>().SetBool("abilityUse", true);
            if (pi.Ability.CycleAbility.WasPressedThisFrame())
            {
                currentAbility.OffHoverAbility(gameObject);
                abilityFlags[Mod(index, 2)].GetComponent<Animator>().SetBool("abilityUse", false);
                index += (int) pi.Ability.CycleAbility.ReadValue<float>();
            }
            abilityFlags[Mod(index, 2)].GetComponent<Animator>().SetBool("abilityUse", true);
            currentAbility.OnHoverAbility(gameObject);
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
            pi.Ability.Disable();
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
        StandardAbility currentAbility = (Mod(index, 2) == 0 ? elemental : ultimate);
        if(currentAbility.abilityState == AbilityState.ready)
        { 
            ability[Mod(index, 2)](gameObject);
            isInAbility = false;
            currentAbility.abilityState = AbilityState.active;
        }else Debug.Log("Ability is not ready");
    }

    #endregion
}
