using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RallyPointBehaviour : MonoBehaviour
{
    public List<PatrolPointBehaviour> patrolPoints;

    public PatrolPointBehaviour GetNextPoint()
    {
        foreach (var point in patrolPoints)
        {
            if (!point.IsOccupied)
            {
                return point;
            }
        }

        return null;
    }
}
