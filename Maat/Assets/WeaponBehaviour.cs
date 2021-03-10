using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WeaponBehaviour : MonoBehaviour
{
    public float damage;
    public UnityEvent killScored;

    public virtual void Attack()
    {

    }

    public virtual void OnTriggerEnter(Collider other)
    {
        HealthSystem theirHealthSystem = other.gameObject.GetComponentInParent<HealthSystem>();

        if (theirHealthSystem != null)
        {
            bool killed = theirHealthSystem.TakeDamage(damage);

            if (killed)
            {
                killScored.Invoke();
            }
        }
    }
}
