using System;
using System.Collections; 
using UnityEngine;

public class ForceField : MonoBehaviour
{
    private ParticleSystem ps;
    private CircleCollider2D cc;
    private ParticleSystem.MinMaxCurve emissionTime;
    private float time;

    private void Start()
    {
        ps = GetComponent<ParticleSystem>();
        cc = GetComponent<CircleCollider2D>();
        emissionTime = ps.sizeOverLifetime.size;
    }
    
    private void Update()
    {
   
        if (ps.isEmitting)
        {
            time += Time.deltaTime;
            cc.radius = emissionTime.Evaluate(time / ps.main.startLifetimeMultiplier) * ps.main.startSizeMultiplier / 2;
        }
        if (time >= ps.main.startLifetimeMultiplier) time = 0;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject != transform.parent.gameObject && other.gameObject.GetComponent<IPlayerController>() != null) other.gameObject.GetComponent<IPlayerController>().TakeDamage(.1f);
    }
}