using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 7f;
    [SerializeField] private float despawnTime = 5f;
    
    [NonSerialized] public float direction;

    private float currentTime;

    private void OnEnable()
    {
        currentTime = despawnTime;
        if (direction > 0) GetComponent<SpriteRenderer>().flipX = false;
        else if (direction < 0) GetComponent<SpriteRenderer>().flipX = true;
    }

    private void Update()
    {
        if (gameObject.activeSelf) transform.Translate(Vector3.right * (direction * speed * Time.deltaTime));
        if (currentTime <= 0f) gameObject.SetActive(false);
        else currentTime -= Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) collision.gameObject.GetComponent<IPlayerController>().TakeDamage(10);
        gameObject.SetActive(false);
    }
}
