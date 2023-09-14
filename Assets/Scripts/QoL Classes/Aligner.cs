using System;
using System.Collections; 
using UnityEngine;

public class Aligner : MonoBehaviour
{
    public float scale;
    
    private void Update()
    {
        Transform transform1 = transform;
        transform1.position = transform1.parent.parent.GetChild(0).GetChild(0).position;
        scale = transform1.parent.parent.GetChild(0).localScale.x;
    }
}