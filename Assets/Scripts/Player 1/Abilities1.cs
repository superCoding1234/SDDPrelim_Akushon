using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Abilities1 : MonoBehaviour
{
    private Player1Inputs pi;
    private PlayerController1 pc;
    private Rigidbody2D rb;
    private ParticleSystem ps;
    private GameObject[] abilities;
    private Action[] ability;
    private int index;
    private float jumpHeight;
    private float slowTime;
    private bool canUseAbility = true;
    private bool isInAbility;

    private void Start()
    {
        pc = GetComponent<PlayerController1>();
        jumpHeight = pc.jumpHeight;
        slowTime = pc.slowTime;
        abilities = pc.abilities;
        rb = pc.rb;
        ps = pc.ps;
        ability = new Action[] { Fire1, Fire2, Fire3 };
        
        //inputs
        pi = pc.pi;
        InitializeInputs();
    }

    private void InitializeInputs()
    {
        pi.Ability.UseAbility.performed += UseAbilityPerformed;
        pi.Ability.Ability.started += context =>
        {
            isInAbility = false;
            pi.Ability.Disable();
        };
        pi.PlayerMovement.Ability.started += context =>
        {
            isInAbility = true;
            pi.Ability.Enable();
        };
    }

    public void SubUpdate()
    {
        Time.timeScale = 0;//Mathf.Lerp(1, slowTime, 5);
        if (isInAbility && canUseAbility)
        {
            Time.timeScale = Mathf.Lerp(1, slowTime, 5);
            if (pi.Ability.CycleAbility.WasPressedThisFrame())
            {
                abilities[Mod(index, 3)].GetComponent<Animator>().SetBool("abilityUse", false);
                index += (int) pi.Ability.CycleAbility.ReadValue<float>();
            }
            abilities[Mod(index, 3)].GetComponent<Animator>().SetBool("abilityUse", true);
        }
        else
        {
            Time.timeScale = Mathf.Lerp(slowTime, 1, 5);
            foreach (var o in abilities)
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

    private IEnumerator StartCooldown()
    {
        yield return new WaitForSeconds(1f);
        canUseAbility = true;
        isInAbility = false;
    }

    //abilities
    private void Fire1()
    {
        FindFirstObjectByType<AudioManager>().Play("ViperRoundLost");
        //transform.localScale =  new Vector3(3 * transform.localScale.x, 3, 1);
    }

    private void Fire2()
    {
        FindFirstObjectByType<AudioManager>().Play("ViperRoundWon");
        //transform.localScale = new Vector3(1, 1, 1);
    }

    private void Fire3()
    {
        if(ps.isStopped) ps.Play();
        FindFirstObjectByType<AudioManager>().Play("ViperSuper");
    }

    //required to prevent it throwing missing reference exception in input manager - see Death1
    public void UseAbilityPerformed(InputAction.CallbackContext context)
    {
        ability[Mod(index, 3)]();
        canUseAbility = false;
        StartCoroutine(StartCooldown());
    }
}
