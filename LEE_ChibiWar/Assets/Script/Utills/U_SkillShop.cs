using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class U_SkillShop : MonoBehaviour
{
    Dictionary<int,Skill> keyValuePairs = new Dictionary<int,Skill>();
    public PlayerController controller;
    public Skill[] gameSkill;

    // Start is called before the first frame update
    void Start()
    {
        gameSkill = Resources.LoadAll<Skill>("Skill");
        Debug.Log($"All  Complete{gameSkill.Length}");
    }

    // Update is called once per frame
    void Update()
    {
        //if (controller == null)
        //{
        //    return;
        //}
        //else
        //{
        //    Debug.Log("controll");
        //}
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        controller = other.gameObject.GetComponentInParent<PlayerController>();
        controller.GetComponent<P_SkillHolder>().skill[0] = gameSkill[0];
        U_SkillPool.instance.Initialize(10, controller.GetComponent<P_SkillHolder>().skill[0]);
    }
}
