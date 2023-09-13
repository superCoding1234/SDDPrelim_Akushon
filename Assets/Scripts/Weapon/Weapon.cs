
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Weapon : MonoBehaviour
{
    private bool canUseWeapon = true;
    [SerializeField] private GameObject[] weaponPool;
    [SerializeField] private Transform firingPoint;

    public void ShootWeapon(InputAction.CallbackContext context)
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
        for (int i = 0; i < weaponPool.Length; i++) if (!weaponPool[i].activeInHierarchy) return i;
        return 0;
    }
    private IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(.5f);
        canUseWeapon = true;
    }
}