/// Code Maded From 2022-05-23////
/// MADE BY Lee Sang Jun /////////
//////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

// Player Scipts
public class PlayerController : CreateController
{
    #region Controller Override
    // Started
    protected override void init()
    {
        base.init();
        _animator = this.gameObject.GetComponent<Animator>();
    }
    #endregion

    #region Unity LifeCycle
    private void FixedUpdate()
    {
        GetKey();
    }
    protected void GetKey()
    {
        if (isMove)
        {
            OnMouseClick_LookAt(mousePosition);
            OnMouseClick_ToMove(mousePosition);
        }
        if (Input.GetMouseButton(1))
        {
            if(currentState==PlayerState.IDLE||currentState==PlayerState.MOVE)
            {
                isMove = true;
                mousePosition = Input.mousePosition;
            }
        }
        if (Input.GetKey(KeyCode.Q))
        {
            Debug.Log("Skill 01");
        }
        if (Input.GetKey(KeyCode.W))
        {
            Debug.Log("Skill 02");
        }
        if (Input.GetKey(KeyCode.E))
        {
            Debug.Log("Skill 03");
        }
        if (Input.GetKey(KeyCode.R))
        {
            Debug.Log("Skill 04");
        }
    }
    #endregion


    #region Player Skilled


    #endregion
}
