using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InputManager : MonoSingleton<InputManager>
{
    public static Action OnBulletFire;
    public static Action OnStartDrawingBulletPath;
    public static Action OnDrawingBulletPath;


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
        if(Input.GetMouseButtonDown(0) && isGameStart == true)
        {
            OnStartDrawingBulletPath?.Invoke();
        }
        else if(Input.GetMouseButton(0) && isGameStart == true)
        {
            OnDrawingBulletPath?.Invoke();
        }
        else if(Input.GetMouseButtonUp(0) && isGameStart == true) {
            {
                OnBulletFire?.Invoke();
            }
        }
    }
}
