using System.Collections; 
using UnityEngine;

[CreateAssetMenu]
public class Wind : StandardAbility
{
    [SerializeField] private GameObject windDetector;
    [SerializeField] private float strength;

    public override void Activate(GameObject parent)
    {
        parent.GetComponent<ElementalManager>().target.GetComponent<Rigidbody2D>().velocity = Vector2.up * strength;
        parent.GetComponent<ElementalManager>().target.GetComponent<Rigidbody2D>().gravityScale = 5;
        GameObject wd = Instantiate(windDetector, parent.GetComponent<ElementalManager>().target.transform, false);
        wd.transform.localPosition += Vector3.down * 1.5f;
    }
}