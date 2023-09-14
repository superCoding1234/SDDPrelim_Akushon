using System;
using UnityEngine;

public class SkillShotIndicator : MonoBehaviour
{
    private float step;
    private int direction;
    [SerializeField] private float speed;
    private void Update()
    {
        transform.rotation = (GetComponent<Aligner>().scale >= .9f) ? Quaternion.Lerp(Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 180), step) : Quaternion.Lerp(Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 179), step);
        if (step >= 1) direction = -1;
        else if(step <= 0) direction = 1;
        step += Time.deltaTime * direction * speed;
    }

    private void OnEnable()
    {
        step = 0;
        transform.rotation = Quaternion.identity;
    }
}