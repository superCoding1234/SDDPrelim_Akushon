using System;
using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class SerpentsortiaSuperBullet : MonoBehaviour
{
    [SerializeField] private float speed = 7f;
    [SerializeField] private float despawnTime = 5f;
    [SerializeField] private GameObject poisonPoolPrefab;
    
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
        if (currentTime <= 0f) Destroy(gameObject);
        else currentTime -= Time.deltaTime;
    }

    private void OnCollisionEnter(Collision other)
    {
        Instantiate(poisonPoolPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}