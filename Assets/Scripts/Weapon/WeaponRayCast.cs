using System.Collections;
using UnityEngine;

public class WeaponRayCast : MonoBehaviour
{
    [SerializeField] private Transform firingPoint;
    [SerializeField] private GameObject bullet;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            Instantiate(bullet, firingPoint);
            RaycastHit2D hit = Physics2D.Raycast(firingPoint.position, Vector2.right);
            if (hit.collider)
            {
                Debug.Log(hit.collider.gameObject.name + " was hit!");
            }
        }
    }
}