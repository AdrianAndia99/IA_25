using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthSoldier : healthHuman
{
    // Start is called before the first frame update
    void Start()
    {
        base.LoadComponent();
    }

    public override void Dead()
    {
        base.Dead();
    }
}
