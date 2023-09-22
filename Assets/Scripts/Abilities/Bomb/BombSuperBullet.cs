using System;
using UnityEngine;
using UnityEngine.UI;

public class BombSuperBullet : MonoBehaviour, IPlayerController
{
    public GameObject target;
    [SerializeField] private float speed, damage, maxHealth;
    [SerializeField] private Slider slider;
    private float currHealth;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
    }

    private void FixedUpdate()
    {
        Vector2 direction = (Vector2)target.transform.position - rb.position;
        direction.Normalize();
        float rotation = Vector3.Cross(direction, transform.up).z;
        rb.angularVelocity = -rotation * 1000f;
        rb.velocity = transform.up * (speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player")) other.gameObject.GetComponent<IPlayerController>().TakeDamage(damage);
    }

    public void TakeDamage(float damage)
    {
        currHealth -= damage;
    }
}