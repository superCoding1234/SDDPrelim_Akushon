using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class ToggleAnimation : MonoBehaviour, IPointerDownHandler
{
    [NonSerialized] public bool buttonState;
    [SerializeField] private Sprite buttonDown, buttonUp;
    [SerializeField] private RectTransform content;

    public void OnPointerDown(PointerEventData eventData)
    {
        buttonState = !buttonState;
        GetComponent<Image>().sprite = buttonState ? buttonDown : buttonUp;
        content.position += (buttonState ? Vector3.down : Vector3.up) * 4;
    }
}