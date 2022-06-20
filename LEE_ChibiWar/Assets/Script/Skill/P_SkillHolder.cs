using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class P_SkillHolder : MonoBehaviour
{
    Dictionary<int,int> skillList = new Dictionary<int,int>();
    [SerializeField]
    public Skill[] skill = new Skill[4];
    float[] cooldownTime = new float[4];
    float[] activeTime = new float[4];
    public enum SkillState
    {
        ready,
        active,
        cooldown
    }
    private SkillState[] state = new SkillState[4] { SkillState.ready, SkillState.ready, SkillState.ready, SkillState.ready };
    private KeyCode[] keys = new KeyCode[4] {KeyCode.Q,KeyCode.W,KeyCode.E,KeyCode.R };
    public void start()
    {
        for (int i = 0; i < skill.Length; i++)
        {
            skill[i] = new PS_FireBall();
            activeTime[i] = skill[i].activeTime;
            cooldownTime[i] = skill[i].coolTime;
            skillList.Add(keys[i].GetHashCode(), ((int)KeyCode.Q));
        }
    }

    void OnKeyDown(KeyDownEvent ev)
    {
        SkillEvent(ev.keyCode);
    }

    void SkillEvent(KeyCode key)
    {
        int init = skillList[key.GetHashCode()];
        switch (state[init])
        {
            case SkillState.ready:
                if (Input.GetKeyDown(key))
                {
                
                    state[init] = SkillState.active;
                    activeTime[init] = skill[init].activeTime;
                    if (skill[init].skill_Effect == null)
                    {
                        skill[init].skill_Effect = Instantiate(skill[init].skill_Effect, gameObject.transform);
                    }
                    skill[init].Activate();
                    //Activate
                }
                break;
            case SkillState.active:
                if (activeTime[init] > 0)
                {
                    activeTime[init] -= Time.deltaTime;
                }
                else
                {
                    state[init] = SkillState.cooldown;
                    cooldownTime[init] = skill[init].coolTime;
                    skill[init].DeActive();
                }
                break;
            case SkillState.cooldown:
                if (cooldownTime[init] > 0)
                {
                    cooldownTime[init] -= Time.deltaTime;
                }
                else
                {
                    state[init] = SkillState.ready;
                }
                break;
        }
    }

    private void FixedUpdate()
    {
        
        //OnKeyDown();
    }
}
