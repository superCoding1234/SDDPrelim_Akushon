using UnityEngine;

public class PoisonPool : MonoBehaviour
{
    [SerializeField] private float lifeTime;
    private float currTime;

    public void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<IPlayerController>().TakeDamage(0.5f);
        }
    }

    public void Update()
    {
        currTime += Time.deltaTime;
        if(currTime >= lifeTime) Destroy(gameObject);
    }
}