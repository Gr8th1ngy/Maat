using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MeleeFighterBehaviour : FighterBehaviour
{
    public MeleeWeaponBehaviour weapon;

    protected NavMeshAgent agent;
    protected Vector3 originalPosition;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        agent = GetComponentInChildren<NavMeshAgent>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        FighterBehaviour target = null;

        if (opponents.Count > 0)
        {
            target = opponents[0];
            var targetHealthSystem = target.GetComponentInParent<HealthSystem>();

            if (targetHealthSystem == null || targetHealthSystem.isDead)
            {
                state = State.Idle;
            }
        }

        if (state == State.Idle)
        {
            agent.destination = originalPosition;
            agent.stoppingDistance = 0;
            opponents = LookForOpponent(enemyLayerMask);

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
            Attack();
        }
        else if (state == State.RotateToOpponent)
        {
            RotateToOpponent(target);
        }
    }

    protected void GoToOpponent(FighterBehaviour target)
    {
        agent.destination = target.transform.position;
        agent.stoppingDistance = stoppingDistanceToEnemy;

        if ((target.transform.position - transform.position).magnitude <= stoppingDistanceToEnemy)
        {
            state = State.RotateToOpponent;
        }
    }

    protected void Attack()
    {
        if (timeTillNextAttack <= 0)
        {
            weapon.Use();
            timeTillNextAttack = 1 / attackSpeed;
        }
        else
        {
            timeTillNextAttack -= Time.deltaTime;
        }
    }

    protected void RotateToOpponent(FighterBehaviour target)
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
        state = State.Idle;
    }
}
