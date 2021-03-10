using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterBehaviour : MonoBehaviour
{
    public float detectionRange;
    public float attackRange;
    public float attackSpeed;

    public WeaponBehaviour weapon;
    public Transform attackPoint;

    protected State state;
    protected float stoppingDistanceToEnemy;

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
    }

    protected List<T> LookForOpponent<T>(LayerMask opponentLayerMask)
    {
        List<T> opponents = new List<T>();
        var colliders = Physics.OverlapSphere(transform.position, detectionRange, opponentLayerMask);

        foreach (var collider in colliders)
        {
            T opponent = collider.GetComponentInParent<T>();
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
