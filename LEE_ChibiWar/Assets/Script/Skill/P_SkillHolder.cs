using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class P_SkillHolder : MonoBehaviour
{
    public static P_SkillHolder instance;
    
    Dictionary<int,int> skillList = new Dictionary<int,int>();
    [SerializeField]
    public Skill[] skill = new Skill[4];
    float[] cooldownTime = new float[4];
    float[] activeTime = new float[4];

    public EnumHolder.SkillState[] state = new EnumHolder.SkillState[4] { EnumHolder.SkillState.ready , EnumHolder.SkillState.ready, EnumHolder.SkillState.ready, EnumHolder.SkillState.ready};
    public void Start()
    {
        instance = this;
        //for (int i = 0; i < skill.Length; i++)
        //{
        //    activeTime[i] = skill[i].GetComponent<Skill>().activeTime;
        //    cooldownTime[i] = skill[i].GetComponent<Skill>().coolTime;
        //    state[i] = skill[i].GetComponent<Skill>().skillstate;
        //}
    }

    private void FixedUpdate()
    {

    }


}
