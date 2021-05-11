using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MeleeFighterBehaviour
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        originalPosition = References.destination.GetDestinationPoint();
        agent.destination = originalPosition;

        weapon.TargetLayerMask = References.allyLayer;
        enemyLayerMask = References.allyLayer;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

        if (state == State.Idle && agent.remainingDistance <= 0.2f)
        {
            Destroy(gameObject);
        }
    }

    protected override void ChooseOpponent()
    {
        foreach (var potentialTarget in opponents)
        {
            if (potentialTarget.GetComponent<AllyBehaviour>().target == this)
            {
                target = potentialTarget;
                state = State.MoveToOpponent;
                break;
            }
        }
    }
}
