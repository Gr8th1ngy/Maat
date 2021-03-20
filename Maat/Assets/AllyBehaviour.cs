using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AllyBehaviour : MeleeFighterBehaviour
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        originalPosition = transform.position;
        weapon.TargetLayerMask = References.enemyLayer;
        enemyLayerMask = References.enemyLayer;
    }
}
