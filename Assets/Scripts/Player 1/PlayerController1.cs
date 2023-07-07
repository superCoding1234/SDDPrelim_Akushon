//main script

using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController1 : MonoBehaviour, IPlayerController
{
    [NonSerialized] public Rigidbody2D rb;
    [NonSerialized] public CapsuleCollider2D coll;
    [NonSerialized] public TrailRenderer tr;
    [NonSerialized] public SpriteRenderer sr;
    [NonSerialized] public ParticleSystem ps;
    [NonSerialized] public Player1Inputs pi;
    [NonSerialized] public Animator anim;
    //scripts
    private PlayerMovement1 pm;
    private Death1 death;
    private Abilities1 ab;
    private Health1 health;
    
    //scripts settings
    [Header("Player Movement")]
    [Header("Ground Layer")] 
    public LayerMask ground;

    [Header("Movement")]
    public float jumpHeight = 420f;
    public float speed = 420f;

    [Header("Dashing")]
    public float dashStrength = 20f;
    public float dashTime = .1f;

    [Header("Health")] 
    public Slider slider;
    public int maxHealth = 100;
    [NonSerialized] public float currentHealth;

    [Header("Abilities")] 
    public GameObject[] abilities;
    public float slowTime = .25f;

    [Header("Death")] 
    public TextMeshProUGUI deathMessage;


    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<CapsuleCollider2D>();
        tr = GetComponent<TrailRenderer>();
        sr = GetComponent<SpriteRenderer>();
        ps = GetComponentInChildren<ParticleSystem>();
        anim = GetComponent<Animator>();
        
        pm = GetComponentInChildren<PlayerMovement1>();
        death = GetComponentInChildren<Death1>();
        ab = GetComponentInChildren<Abilities1>();
        health = GetComponentInChildren<Health1>();
        
        pi = new Player1Inputs();
        pi.PlayerMovement.Enable();
        Debug.Log("PC1 loaded");
    }

    // Update is called once per frame
    private void Update()
    {
        pm.SubUpdate();
        health.SubUpdate();
        death.SubUpdate();
        ab.SubUpdate();
    }

    private void FixedUpdate()
    {
        pm.SubFixedUpdate();   
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        death.SubOnCollisionEnter2D(collision);
    }
    
    //damage
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
    }
}
