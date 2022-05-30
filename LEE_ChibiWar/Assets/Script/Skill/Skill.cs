using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill
{
    public int id;
    public string name;
    public int level;
    public int damage;
    public float speed;
    public float coolTime;
    public float activeTime;

    public virtual void Activate()
    {

    }
}
