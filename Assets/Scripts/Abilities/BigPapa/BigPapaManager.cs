using UnityEngine;

public enum PlayerTarget
{
    Player1 = 6,
    Player2 = 7
}


public class BigPapaManager : MonoBehaviour
{
    public Transform firingPoint;
    public float areaOfEffect;
    public PlayerTarget playerTarget;
    public ParticleSystem forceField;

    // visual indicator in inspector
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(firingPoint.position, areaOfEffect);
    }
}