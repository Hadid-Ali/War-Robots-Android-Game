using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public abstract class CharacterAnimatorController : MonoBehaviour
{
    [SerializeField] protected Animator m_Animator;
    public Animator Animator => m_Animator;

    private int m_SpeedAnimatorParameter = UnityEngine.Animator.StringToHash("Speed");
    
    private readonly int m_HasWeaponParameter = Animator.StringToHash("HasWeapon");
    private readonly int m_AimWeaponParamter = Animator.StringToHash("Aim");
    private readonly int m_ShootWeaponParameter = Animator.StringToHash("Shoot");
    private readonly int m_PunchingParameter = Animator.StringToHash("Punch");
    
    public void ApplyAnimatorOverrideController(AnimatorOverrideController animatorOverrideController,Avatar avatar = null)
    {
        m_Animator.runtimeAnimatorController = animatorOverrideController;
        if(avatar is null)
            return;
        m_Animator.avatar = avatar;
    }
    
    public void SetIdle()
    {
        SetSpeed(0f);
    }

    public void SetWalkPose()
    {
        SetSpeed(2f);
    }

    public void SetRunningPose()
    {
        SetSpeed(6f);
    }
    
    public void Punch()
    {
        m_Animator.SetTrigger(m_PunchingParameter);
    }

    private void SetSpeed(float value)
    {
        m_Animator.SetFloat(m_SpeedAnimatorParameter,value);
    }

    public void SetAimPose(bool b)
    {
        m_Animator.SetBool(m_AimWeaponParamter,b);
    }

    public void SetHasWeapon(bool b)
    {
        m_Animator.SetBool(m_HasWeaponParameter,b);
    }

    public void ShootPose()
    {
        m_Animator.SetTrigger(m_ShootWeaponParameter);
    }
}
