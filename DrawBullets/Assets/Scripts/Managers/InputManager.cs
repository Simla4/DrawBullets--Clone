using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoSingleton<InputManager>
{
    public bool isGameStart;
    public void TaptoPlay()
    {
        if(Input.GetMouseButtonDown(0))
        {
            isGameStart = true;
        }
        
    }
}
