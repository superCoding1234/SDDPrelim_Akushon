using UnityEngine;

[CreateAssetMenu]
public class Fire : StandardAbility
{
    [SerializeField] private float damage;

    public override void Activate(GameObject parent)
    {
        parent.GetComponent<ElementalManager>().target.GetComponent<SpriteRenderer>().color = Color.red;
    }

    public override void WhileActive(GameObject parent)
    {
        parent.GetComponent<ElementalManager>().target.GetComponent<IPlayerController>().TakeDamage(damage);
    }

    public override void Deactivate(GameObject parent)
    {
        parent.GetComponent<ElementalManager>().target.GetComponent<SpriteRenderer>().color = Color.white;
    }
}