using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeaponBehaviour : WeaponBehaviour
{
    public Animator attackAnimator;
    public Transform attackPoint;
    public float attackPointRadius;

    public override void InflictDamage()
    {
        Collider[] targetColliders = Physics.OverlapSphere(attackPoint.position, attackPointRadius, TargetLayerMask);

        if (targetColliders.Length > 0)
        {
            var targetHealthSystem = targetColliders[0].GetComponentInParent<HealthSystem>();

            if (targetHealthSystem != null)
            {
                bool killed = targetHealthSystem.TakeDamage(damage);

                if (killed)
                {
                    KillScored.Invoke();
                }
            }
        }
    }
}
