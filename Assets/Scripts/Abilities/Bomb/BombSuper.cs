using UnityEngine;

[CreateAssetMenu]
public class BombSuper : StandardAbility
{
    [SerializeField] private GameObject bomb;
    
    public override void Activate(GameObject parent)
    {
        GameObject bullet = Instantiate(bomb, parent.GetComponent<BombSuperManager>().firingPoint.position, Quaternion.identity);
        bullet.GetComponent<BombSuperBullet>().target = parent.GetComponent<BombSuperManager>().target;
    }
}