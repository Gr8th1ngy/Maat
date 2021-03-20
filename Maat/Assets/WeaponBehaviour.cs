using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WeaponBehaviour : MonoBehaviour
{
    public float damage;
    public UnityEvent KillScored;

    public GameObject projectilePrefab;

    public LayerMask TargetLayerMask { get; set; }

    public virtual void Use()
    {

    }

    public virtual void InflictDamage()
    {
        var projectile = Instantiate(projectilePrefab, transform.position, GetComponentInParent<Transform>().rotation).GetComponent<ProjectileBehaviour>();
        projectile.damage = damage;
        projectile.KillScored = KillScored;
    }
}
