using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : FighterBehaviour
{
    public float timeBetweenTargetPositionUpdate;

    float timeTillTargetPositionUpdate;
    NavMeshAgent agent;
    List<AllyBehaviour> opponents;
    Vector3 finalDestination;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        agent = GetComponentInChildren<NavMeshAgent>();
        finalDestination = References.destination.GetDestinationPoint();
        agent.destination = finalDestination;
        opponents = new List<AllyBehaviour>();
        timeTillTargetPositionUpdate = 0;
    }

    // Update is called once per frame
    protected void Update()
    {
        var target = opponents.Count > 0 ? opponents[0] : null;

        if (state == State.Idle)
        {
            opponents = LookForOpponent<AllyBehaviour>(References.allyLayer);

            if (opponents.Count > 0)
            {
                state = State.MoveToOpponent;
            }
        }
        else if (state == State.MoveToOpponent)
        {
            GoToOpponent(target);
        }
        else if (state == State.Attack)
        {
            Attack(target);
        }
        else if (state == State.RotateToOpponent)
        {

        }
    }

    void GoToOpponent(AllyBehaviour target)
    {
        if (timeTillTargetPositionUpdate <= 0)
        {
            agent.destination = target.transform.position;
            agent.stoppingDistance = stoppingDistanceToEnemy;
            timeTillTargetPositionUpdate = timeBetweenTargetPositionUpdate;
        }
        else
        {
            timeTillTargetPositionUpdate -= Time.deltaTime;
        }

        if ((target.transform.position - transform.position).magnitude <= stoppingDistanceToEnemy)
        {
            state = State.RotateToOpponent;
            agent.isStopped = true;
        }
    }

    void Attack(AllyBehaviour target)
    {
        agent.isStopped = true;
    }
}
