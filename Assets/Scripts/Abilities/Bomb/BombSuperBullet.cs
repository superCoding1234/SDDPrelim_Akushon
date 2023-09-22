using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BombSuperBullet : MonoBehaviour, IPlayerController
{
    public static BombSuperBullet bombSuperBullet;
    public GameObject target;
    [SerializeField] private float speed, damage, maxHealth;
    [SerializeField] private Slider slider;
    private float currHealth;
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sr;
    private bool canDamage = true;

    private void Start()
    {
        if(bombSuperBullet) Destroy(bombSuperBullet.gameObject);
        bombSuperBullet = this;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        currHealth = maxHealth;
        slider.maxValue = maxHealth;
    }

    private void Update()
    {
        slider.gameObject.transform.parent.rotation = Quaternion.Euler(-transform.rotation.ToEuler());
        slider.value = currHealth;
        if (currHealth <= 0)
        {
            Destroy(gameObject);
        }
        
        UpdateAnimationState();
    }

    private void FixedUpdate()
    {
        Vector2 direction = (Vector2)target.transform.position - rb.position;
        direction.Normalize();
        float rotation = Vector3.Cross(direction, transform.right).z;
        rb.angularVelocity = -rotation * 1000f;
        rb.velocity = transform.right * (speed * Time.deltaTime);
    }

    private void UpdateAnimationState()
    {
        sr.flipY = transform.position.x > target.transform.position.x;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player") && canDamage)
        {
            anim.SetTrigger("explode");
            other.gameObject.GetComponent<IPlayerController>().TakeDamage(damage);
            canDamage = false;
            StartCoroutine(StartDamageBuffer());
        }
        
    }

    private IEnumerator StartDamageBuffer()
    {
        yield return new WaitForSeconds(1f);
        canDamage = true;
    }

    public void TakeDamage(float dmg)
    {
        currHealth -= dmg;
    }
}