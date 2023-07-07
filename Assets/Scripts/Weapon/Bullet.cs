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
    }

    private void Update()
    {
        if (gameObject.activeSelf) transform.Translate(Vector2.right * (direction * speed * Time.deltaTime));
        if (currentTime <= 0f) gameObject.SetActive(false);
        else currentTime -= Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameObject.SetActive(false);
        if (collision.gameObject.CompareTag("Player")) collision.gameObject.GetComponent<IPlayerController>().TakeDamage(10);
    }
}
