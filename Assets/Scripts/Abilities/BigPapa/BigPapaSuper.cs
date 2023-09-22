using UnityEngine;

[CreateAssetMenu]
public class BigPapaSuper : StandardAbility
{
    public override void Activate(GameObject parent)
    {
        Vector2 firingPoint = parent.GetComponent<BigPapaManager>().firingPoint.position;
        Transform firingPointTransform = parent.GetComponent<BigPapaManager>().firingPoint;
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(firingPoint, parent.GetComponent<BigPapaManager>().areaOfEffect);
        parent.GetComponent<BigPapaManager>().forceField.Play();
        
        foreach (var coll in hitEnemies)
        {
            if(coll.gameObject.CompareTag("Player") && coll.gameObject.layer == (int)parent.GetComponent<BigPapaManager>().playerTarget) coll.gameObject.GetComponent<Rigidbody2D>().MovePosition(Vector2.MoveTowards(coll.gameObject.transform.position, firingPoint, -30));
        }
    }
}