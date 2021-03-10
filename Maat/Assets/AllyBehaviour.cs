using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AllyBehaviour : FighterBehaviour
{
    public float timeBetweenTargetPositionUpdate;

    float timeTillTargetPositionUpdate;
    float timeTillNextAttack;
    NavMeshAgent agent;
    List<EnemyBehaviour> opponents;
    Vector3 originalPosition;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        agent = GetComponentInChildren<NavMeshAgent>();
        originalPosition = transform.position;
        opponents = new List<EnemyBehaviour>();
        timeTillTargetPositionUpdate = 0;
        timeTillNextAttack = 0;
    }

    // Update is called once per frame
    protected void Update()
    {
        var target = opponents.Count > 0 ? opponents[0] : null;

        if (state == State.Idle)
        {
            opponents = LookForOpponent<EnemyBehaviour>(References.enemyLayer);

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
            RotateToOpponent(target);
        }
    }

    void GoToOpponent(EnemyBehaviour target)
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
        }
    }

    void Attack(EnemyBehaviour target)
    {
        if (timeTillNextAttack <= 0)
        {
            weapon.Attack();
            timeTillNextAttack = 1 / attackSpeed;
        }
        else
        {
            timeTillNextAttack -= Time.deltaTime;
        }
    }

    void RotateToOpponent(EnemyBehaviour target)
    {
        Vector3 targetDirection = target.transform.position - transform.position;
        float singleStep = agent.angularSpeed * Mathf.Deg2Rad * Time.deltaTime;

        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);
        Quaternion oldRotation = transform.rotation;
        transform.rotation = Quaternion.LookRotation(newDirection);

        if (oldRotation == transform.rotation)
        {
            state = State.Attack;
        }
    }

    public override void KillScored()
    {
        opponents.Clear();

        agent.destination = originalPosition;

        state = State.Idle;
    }
}
