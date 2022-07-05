﻿using System.Collections;
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
        skillstate = EnumHolder.SkillState.ready;
    }
    public void Start()
    {
    }
    public override void Activate()
    {
        this.gameObject.transform.position = Vector3.zero;
        base.Activate();
    }
    protected override void DeActive()
    {
        base.DeActive();
    }
    public void FixedUpdate()
    {
        Debug.Log("???");
        base.skill_Calculate();
    }

}
