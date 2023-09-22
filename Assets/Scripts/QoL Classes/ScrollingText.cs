using UnityEngine;

public class ScrollingText : MonoBehaviour
{
    private RectTransform rt;
    [SerializeField] private float speed;
    private float endYPosition;

    private void Start()
    {
        rt = GetComponent<RectTransform>();
        endYPosition = -rt.localPosition.y;
    }

    private void Update()
    {
        if (!(rt.localPosition.y < endYPosition)) return;
        rt.Translate(Vector3.up * speed);
    }
}