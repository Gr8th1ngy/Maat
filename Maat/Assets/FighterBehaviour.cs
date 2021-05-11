using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterBehaviour : MonoBehaviour
{
    public float detectionRange;
    public float attackRange;
    public float attackSpeed;

    protected List<FighterBehaviour> opponents;
    public FighterBehaviour target;

    protected State state;
    protected float stoppingDistanceToEnemy;
    protected float timeTillNextAttack;
    protected LayerMask enemyLayerMask;

    public enum State
    {
        Idle,
        MoveToOpponent,
        RotateToOpponent,
        Attack
    }

    // Start is called before the first frame update
    protected virtual void Start()
    {
        state = State.Idle;
        stoppingDistanceToEnemy = attackRange * 2;
        timeTillNextAttack = 0;

        opponents = new List<FighterBehaviour>();
    }

    protected List<FighterBehaviour> LookForOpponent(LayerMask opponentLayerMask)
    {
        List<FighterBehaviour> opponents = new List<FighterBehaviour>();
        var colliders = Physics.OverlapSphere(transform.position, detectionRange, opponentLayerMask);

        foreach (var collider in colliders)
        {
            FighterBehaviour opponent = collider.GetComponentInParent<FighterBehaviour>();
            if (opponent != null)
            {
                opponents.Add(opponent);
            }
        }

        return opponents;
    }

    public virtual void KillScored()
    {

    }
}
