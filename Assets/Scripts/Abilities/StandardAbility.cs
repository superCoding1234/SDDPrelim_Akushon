using System;
using UnityEngine;

public enum AbilityState
{
    ready,
    active,
    cooldown
}

public enum AbilityType
{
    elemental,
    ultimate
}

public class StandardAbility : ScriptableObject
{
    public AbilityType abilityType;
    public float cooldownTime;
    public float activeTime;
    [NonSerialized] public AbilityState abilityState = AbilityState.ready;
    
    public virtual void Activate(GameObject parent) {}
    public virtual void WhileActive(GameObject parent) {}
    public virtual void Deactivate(GameObject parent) {}

    public virtual void OnHoverAbility(GameObject parent) {}
    
    public virtual void OffHoverAbility(GameObject parent) {}
}