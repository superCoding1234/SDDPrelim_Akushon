using UnityEngine;

[CreateAssetMenu]
public class SerpentsortiaSuper : StandardAbility
{
    public override void OnHoverAbility(GameObject parent)
    {
        parent.GetComponent<SerpentsortiaManager>().skillShotIndicator.SetActive(true);
    }

    public override void OffHoverAbility(GameObject parent)
    {
        parent.GetComponent<SerpentsortiaManager>().skillShotIndicator.SetActive(false);
    }

    public override void Activate(GameObject parent)
    {
        Instantiate(parent.GetComponent<SerpentsortiaManager>().bulletPrefab, parent.GetComponent<SerpentsortiaManager>().firingPoint.position, parent.GetComponent<SerpentsortiaManager>().skillShotIndicator.transform.rotation);
    }
}