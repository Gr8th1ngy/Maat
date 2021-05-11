using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AllyBehaviour : MeleeFighterBehaviour
{
    public PatrolPointBehaviour patrolPoint;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        weapon.TargetLayerMask = References.enemyLayer;
        enemyLayerMask = References.enemyLayer;
    }

    protected override void Update()
    {
        if (patrolPoint)
        {
            originalPosition = patrolPoint.gameObject.transform.position;
        }

        base.Update();
    }

    protected override void ChooseOpponent()
    {
        target = opponents[0];
        state = State.MoveToOpponent;
    }

    private void OnDestroy()
    {
        patrolPoint.IsOccupied = false;
    }
}
