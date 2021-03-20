using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ProjectileBehaviour : MonoBehaviour
{
    public UnityEvent KillScored;
    public float damage;

    private void OnCollisionEnter(Collision collision)
    {
        HealthSystem theirHealthSystem = collision.gameObject.GetComponentInParent<HealthSystem>();

        if (theirHealthSystem != null)
        {
            bool killed = theirHealthSystem.TakeDamage(damage);

            if (killed)
            {
                KillScored.Invoke();
            }
        }

        Destroy(gameObject);
    }
}
