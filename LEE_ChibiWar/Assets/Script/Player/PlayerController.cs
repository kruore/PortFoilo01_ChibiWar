/// Code Maded From 2022-05-23////
/// MADE BY Lee Sang Jun /////////
//////////////////////////////////


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public enum Skill_Num
{
    skill00 = 0, skill01, skill02, skill03
}

// Player Scipts
public class PlayerController : CreateController
{
    public UserController playerinput;

    #region Controller Override
    private Skill_Num _skillCount = Skill_Num.skill00;
    // Started
    protected override void init()
    {
        _animator = this.gameObject.GetComponent<Animator>();
        playerinput = new UserController();
        playerinput.Player.Skill00.performed += val => GetKey(val.ReadValue<float>(), (int)Skill_Num.skill00);
        playerinput.Player.Skill01.performed += val => GetKey(val.ReadValue<float>(), (int)Skill_Num.skill01);
        playerinput.Player.Skill02.performed += val => GetKey(val.ReadValue<float>(), (int)Skill_Num.skill02);
        playerinput.Player.Skill03.performed += val => GetKey(val.ReadValue<float>(), (int)Skill_Num.skill03);
        playerinput.Player.Move.performed += val => OnMouseClick_LookAt(val);
        playerinput.Player.Move.performed += val => OnMouseClick_ToMove(val);

        base.init();
    }
    #endregion

    #region Unity LifeCycle

    private void Awake()
    {
        init();

        // skillHolded();
    }
    private void FixedUpdate()
    {
        //  GetKey();
    }
    protected void GetKey(float value, int skill_ID)
    {
        currentState = PlayerState.ATTACK;
        if (value > 0.5f)
        {
            var SkillID = skillHolder.skill[skill_ID].id;
            U_SkillPool.instance.GetSkill(SkillID);
            Debug.Log($"SkillActive{skill_ID}");
        }
    }

    #endregion

    private void OnEnable()
    {
        playerinput.Enable();
    }
    private void OnDisable()
    {
        playerinput.Disable();
    }
    #region Player Skilled

    public P_SkillHolder skillHolder;

    private void LateUpdate()
    {
        Camera.main.transform.position = new Vector3(transform.position.x,20, transform.position.z-20);
    }
    #endregion
}
