using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaceBehaviour : MeleeWeaponBehaviour
{
    public override void Use()
    {
        attackAnimator.SetTrigger("Mace attack");
    }
}
