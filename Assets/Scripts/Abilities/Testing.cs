using UnityEngine;

[CreateAssetMenu(menuName = "AbilityTest")]
public class Testing : StandardAbility
{
    public override void Activate(GameObject parent)
    {
        FindFirstObjectByType<AudioManager>().Play("ViperSuper");
    }

    public override void WhileActive(GameObject parent)
    {
        Debug.Log("It is active right neow");
    }
}