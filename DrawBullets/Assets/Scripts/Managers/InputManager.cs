using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InputManager : MonoSingleton<InputManager>
{
    public static Action OnBulletFire;


    public bool isGameStart;
    public void TaptoPlay()
    {
        if(Input.GetMouseButtonDown(0))
        {
            isGameStart = true;
        }
        
    }

    public void FireBullet()
    {
        if(Input.GetMouseButtonDown(0) && isGameStart == true) {
            {
                OnBulletFire?.Invoke();
            }
        }
    }
}
