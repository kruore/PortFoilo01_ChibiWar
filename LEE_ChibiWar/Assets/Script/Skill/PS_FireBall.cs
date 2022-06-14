using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PS_FireBall : Skill
{
    public float skillVelocity;
    public PS_FireBall()
    {
        id = 00;
        name = "FireBall";
        level = 1;
        damage = 1;
        speed = 1;
        coolTime = 1;
        activeTime = 1;
        skill_Effect = (GameObject)Resources.Load("Skill/PS_FireBall");
    }
    public override void Activate()
    {
        base.Activate();
    }
}
