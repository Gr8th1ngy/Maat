using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCollider : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("collide");
        GetComponentInParent<WeaponBehaviour>().OnTriggerEnter(other);
    }
}
