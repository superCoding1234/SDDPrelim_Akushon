using UnityEngine;

[CreateAssetMenu]
public class Water : StandardAbility
{
    public override void Activate(GameObject parent)
    {
        parent.GetComponent<ElementalManager>().target.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        parent.GetComponent<ElementalManager>().target.GetComponent<SpriteRenderer>().color = Color.blue;
    }

    public override void Deactivate(GameObject parent)
    {
        parent.GetComponent<ElementalManager>().target.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        parent.GetComponent<ElementalManager>().target.GetComponent<SpriteRenderer>().color = Color.white;
    }
}