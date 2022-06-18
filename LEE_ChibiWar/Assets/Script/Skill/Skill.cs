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
    public GameObject skill_Effect;

    public virtual void Activate()
    {
        skill_Effect.SetActive(true);
    }
    public virtual void DeActive()
    {
        skill_Effect.SetActive(false);
    }
}
