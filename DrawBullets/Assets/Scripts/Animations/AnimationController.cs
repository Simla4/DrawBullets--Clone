using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoSingleton<AnimationController>
{
    [SerializeField] Animator anim;

    public void RunAnim()
    {
        anim.SetTrigger("Run");
    }
    
    public void DanceAnim()
    {
        anim.SetTrigger("Dance");
    }

    public void DefeatAnim()
    {
        anim.SetTrigger("Defeat");
    }
}
