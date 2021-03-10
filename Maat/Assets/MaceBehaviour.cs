using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaceBehaviour : WeaponBehaviour
{
    Animator maceAnimator;

    // Start is called before the first frame update
    void Start()
    {
        maceAnimator = GetComponent<Animator>();
    }

    public override void Attack()
    {
        maceAnimator.SetTrigger("Mace attack");
    }

    public override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
    }
}
