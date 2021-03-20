using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MacePivotBehaviour : MonoBehaviour
{
    public UnityEvent inflictDamage;

    void InflictDamage()
    {
        inflictDamage.Invoke();
    }
}
