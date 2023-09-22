using UnityEngine;

public class WindDetector : MonoBehaviour
{
    private Rigidbody2D rb;

    private void Start()
    {
        rb = transform.parent.gameObject.GetComponent<Rigidbody2D>();
    }


    private void Update()
    {
        float velocity = rb.velocity.y;
        if (velocity == 0f)
        {
            transform.parent.gameObject.GetComponent<IPlayerController>().TakeDamage(5);
            rb.gravityScale = 1;
            Destroy(gameObject);
        }
    }
}