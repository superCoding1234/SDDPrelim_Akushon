using UnityEngine;

public class BombSuperManager : MonoBehaviour
{
    public Transform firingPoint;
    public GameObject target;

    public void Start()
    {
        target = GetComponent<ElementalManager>().target;
    }
}