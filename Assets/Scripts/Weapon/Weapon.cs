
using System;
using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private bool canUseWeapon = true;
    [SerializeField] private GameObject[] weaponPool;
    [SerializeField] private Transform firingPoint;

    private int length;

    private void Start()
    {
        length = weaponPool.Length;
    }

    public void ShootWeapon()
    {
        if (!canUseWeapon) return;
        GameObject projectile = weaponPool[GetAvailableProjectile()];
        //orientation
        projectile.transform.position = firingPoint.transform.position;
        projectile.GetComponent<Bullet>().direction = transform.localScale.x;
        //activate bullet
        projectile.SetActive(true);
        canUseWeapon = false;
        StartCoroutine(Cooldown());
    }
    private int GetAvailableProjectile()
    {
        for (int i = 0; i < length; i++) if (!weaponPool[i].activeInHierarchy) return i;
        return 0;
    }
    private IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(.5f);
        canUseWeapon = true;
    }
}