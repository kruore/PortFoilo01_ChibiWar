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
    protected IEnumerator skillActiveTimes;
    //  public static IEnumerator skillCollTime;

    public void Start()
    {
        skillActiveTimes = skill_Calculate();
    }
    public virtual void Activate()
    {
        if (skillstate == EnumHolder.SkillState.ready)
        {
            gameObject.SetActive(true);
            Debug.Log("ACTIVE");
            skillstate = EnumHolder.SkillState.active;
            if (skillActiveTimes != null)
            {
                StopCoroutine(skillActiveTimes);
            }
            skillActiveTimes = skill_Calculate();
            StartCoroutine(skillActiveTimes);
        }
    }

    protected virtual void DeActive()
    {
        U_SkillPool.ReturnObject(this);
        gameObject.SetActive(false);
    }
    protected IEnumerator skill_Calculate()
    {
        while (skillstate != EnumHolder.SkillState.ready)
        {
            yield return new WaitForFixedUpdate();
            activeTime -= Time.deltaTime;
            Debug.Log("Skill");
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
                    if (activeTime < 0)
                    {
                        activeTime = 1;
                        skillstate = EnumHolder.SkillState.cooldown;                   
                    }
                    break;
                case EnumHolder.SkillState.cooldown:
                    coolTime -= Time.deltaTime;
                    if (coolTime < 0)
                    {
                        coolTime = 1;
                        skillstate = EnumHolder.SkillState.ready;
                        DeActive();
                    }
                    break;
                default:
                    break;
            }
        }
    }
}