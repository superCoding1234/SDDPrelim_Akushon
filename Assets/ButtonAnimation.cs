using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonAnimation : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Sprite buttonUp;
    [SerializeField] private Sprite buttonDown;
    private Image image;
    [SerializeField] private RectTransform rt;
    
    private void Start()
    {
        image = GetComponent<Image>();
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        image.sprite = buttonDown;
        rt.position += Vector3.down * 12;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        image.sprite = buttonUp;
        rt.position += Vector3.up * 12;
    }
}
