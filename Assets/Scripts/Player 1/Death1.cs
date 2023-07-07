using System;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Death1 : MonoBehaviour
{
    private PlayerController1 pc;
    private Animator anim;
    private Player1Inputs pi;

    private bool isDead;
    private TextMeshProUGUI deathMessage;

    private void Start()
    {
        pc = GetComponent<PlayerController1>();
        anim = pc.anim;
        pi = pc.pi;
        deathMessage = pc.deathMessage;
        Abilities1 ab = GetComponent<Abilities1>();
        
        pi.Death.Reset.performed += context =>
        {
            pi.Ability.UseAbility.performed -= ab.UseAbilityPerformed;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        };
        Debug.Log("Death1 Loaded");
    }
    

    public void SubUpdate()
    {
        if (pc.currentHealth <= 0 && !isDead)
        {
            anim.SetTrigger("isDead");
            pi.PlayerMovement.Disable();
            pi.Ability.Disable();
            pi.Death.Enable();
            isDead = true;
            deathMessage.text = "PLAYER1 DIED LMFAO";
            deathMessage.gameObject.SetActive(true);
        }
    }

    public void SubOnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("KO")) return;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
