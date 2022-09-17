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
    private int m_KickAnimatorParameter = Animator.StringToHash("KickOpen");
    
    private readonly int m_HasWeaponParameter = Animator.StringToHash("HasWeapon");
    private readonly int m_AimWeaponParamter = Animator.StringToHash("Aim");
    private readonly int m_ShootWeaponParameter = Animator.StringToHash("Shoot");
    private readonly int m_PunchingParameter = Animator.StringToHash("Punch");
    
    private Action m_KickDoorAction;

    public void KickDoorPose(Action kickDoorAction)
    {
        m_Animator.SetTrigger(m_KickAnimatorParameter);
        m_KickDoorAction = kickDoorAction;
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
    
    private void KickOpenDoor()
    {
        m_KickDoorAction?.Invoke();
        m_KickDoorAction = null;
    }

    public void SetAimPose(bool b)
    {
        m_Animator.SetBool(m_AimWeaponParamter,b);
    }

    public void ApplyAnimatorOverrideController(AnimatorOverrideController animatorOverrideController)
    {
        m_Animator.runtimeAnimatorController = animatorOverrideController;
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
