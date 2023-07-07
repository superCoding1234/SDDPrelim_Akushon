using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController2 : MonoBehaviour, IPlayerController
{
    [NonSerialized] public Rigidbody2D rb;
    [NonSerialized] public CapsuleCollider2D coll;
    [NonSerialized] public TrailRenderer tr;
    [NonSerialized] public SpriteRenderer sr;
    [NonSerialized] public ParticleSystem ps;
    [NonSerialized] public Player2Inputs pi;
    //scripts
    private PlayerMovement2 pm;
    private Death2 death;
    private Abilities2 ab;
    private Health2 health;

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
    public TextMeshProUGUI score;


    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<CapsuleCollider2D>();
        tr = GetComponent<TrailRenderer>();
        sr = GetComponent<SpriteRenderer>();
        ps = GetComponentInChildren<ParticleSystem>();

        pm = GetComponent<PlayerMovement2>();
        death = GetComponent<Death2>();
        ab = GetComponent<Abilities2>();
        health = GetComponent<Health2>();
        
        pi = new Player2Inputs();
        pi.PlayerMovement.Enable();
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

    //take damage interface
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
    }
}
