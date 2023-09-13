using System;
using UnityEngine;

public class SkillShotIndicator : MonoBehaviour
{
    private float step;
    private int direction;
    [SerializeField] private float speed;
    private void Update()
    {
        transform.rotation = Quaternion.Lerp(Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 180), step);
        if (step >= 1) direction = -1;
        else if(step <= 0) direction = 1;
        step += Time.deltaTime * direction * speed;
    }

    private void OnDisable()
    {
        transform.rotation = Quaternion.identity;
    }
}