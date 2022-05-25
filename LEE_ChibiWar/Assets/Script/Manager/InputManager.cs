using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InputManager
{
    public Action KeyAction = null;
    public Action<Define.MouseEvent> mouseAction = null;

    bool _press = false;

    public void OnUpdate()
    {
        if(Input.anyKey && KeyAction != null)
        {
            return;
        }

        if(mouseAction != null)
        {
            if(Input.GetMouseButton(0))
            {
                mouseAction.Invoke(Define.MouseEvent.LeftClick);
                _press = true;
            }
            if(Input.GetMouseButton(1))
            {
                mouseAction.Invoke(Define.MouseEvent.RightClick);
                _press = true;
            }
        }
    }
}