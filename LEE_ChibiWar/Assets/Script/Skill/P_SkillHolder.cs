using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_SkillHolder : MonoBehaviour
{
    [SerializeField]
    public Skill skill;
    float cooldownTime;
    float activeTime;
    enum SkillState
    {
        ready,
        active,
        cooldown
    }
    SkillState state = SkillState.ready;
    public KeyCode key;
    public void start()
    {
        skill = new PS_FireBall();
    }
    private void FixedUpdate()
    {
        switch (state)
        {
            case SkillState.ready:
                if (Input.GetKeyDown(key))
                {
                    skill.Activate();
                    state = SkillState.active;
                    activeTime = skill.activeTime;
                    Instantiate(skill.skill_Effect, gameObject.transform);
                    Debug.Log("Active");

                    //Activate
                }
                break;
            case SkillState.active:
                if(activeTime > 0)
                {
                    activeTime -= Time.deltaTime;
                }
                else
                {
                    state = SkillState.cooldown;
                    cooldownTime = skill.coolTime;
                }
                break;
            case SkillState.cooldown:
                if (cooldownTime > 0)
                {
                    cooldownTime -= Time.deltaTime;
                }
                else
                {
                    state = SkillState.ready;
                }
                break;
        }
     
    }
}
