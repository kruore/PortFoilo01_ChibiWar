using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Skill : MonoBehaviour
{
    public int id;
    public string name;
    public int level;
    public int damage;
    public float speed;
    public float coolTime;
    public float activeTime;
    public bool isReady;
    public GameObject skillEffect;
    public EnumHolder.SkillState skillstate;
    //  public static IEnumerator skillCollTime;

    public void Start()
    {
    }
    public virtual void Activate()
    {
        if (skillstate == EnumHolder.SkillState.ready)
        {
            gameObject.SetActive(true);
            skillstate = EnumHolder.SkillState.active;
        }
    }

    protected virtual void DeActive()
    {
        gameObject.SetActive(false);
    }

    protected virtual void skill_Calculate()
    {
        switch (skillstate)
        {
            case EnumHolder.SkillState.ready:
                isReady = true;
                break;
            case EnumHolder.SkillState.active:
                if (isReady)
                {
                    isReady = false;
                }
                activeTime -= Time.deltaTime;
                if (activeTime < 0)
                {
                    activeTime = 1;
                    skillstate = EnumHolder.SkillState.cooldown;
                    DeActive();
                }
                break;
            case EnumHolder.SkillState.cooldown:
                coolTime -= Time.deltaTime;
                if (coolTime < 0)
                {
                    coolTime = 1;
                    skillstate = EnumHolder.SkillState.ready;
                }
                break;
            default:
                break;
        }
    }
    IEnumerator SkillCoolTime()
    {
        coolTime -= Time.deltaTime;
        if (coolTime < 0)
        {
            coolTime = 1;
            skillstate = EnumHolder.SkillState.ready;
        }
        yield return new WaitForSeconds(coolTime);
    }
}