using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class References
{
    public static DestinationBehaviour destination;
    public static CanvasBehaviour canvas;

    public static LayerMask allyLayer = LayerMask.GetMask("Ally");
    public static LayerMask enemyLayer = LayerMask.GetMask("Enemy");
}
