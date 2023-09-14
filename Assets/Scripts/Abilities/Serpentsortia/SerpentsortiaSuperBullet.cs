using System;
using System.Collections;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using UnityEngine;

public class SerpentsortiaSuperBullet : MonoBehaviour
{
    [SerializeField] private float speed = 7f;
    [SerializeField] private float despawnTime = 5f;
    [SerializeField] private GameObject poisonPoolPrefab;

    private float currentTime;

    private void OnEnable()
    {
        currentTime = despawnTime;
    }

    private void Update()
    {
        if (gameObject.activeSelf) transform.Translate(Vector3.up * (speed * Time.deltaTime));
        if (currentTime <= 0f) Destroy(gameObject);
        else currentTime -= Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Instantiate(poisonPoolPrefab, transform.position - Vector3.down * GetComponent<CircleCollider2D>().radius, Quaternion.identity);
        Destroy(gameObject);
    }
}