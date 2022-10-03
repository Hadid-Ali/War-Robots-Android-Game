using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   [SerializeField] private PlayerWeaponsManager m_PlayerWeaponsManager;
   [SerializeField] private WeaponAimingComponent m_AimingComponent;
   [SerializeField] private PlayerAnimatorController m_AnimatorController;
   [SerializeField] private MechaArmatureAimingComponent m_ArmatureAimingComponent;
   
   public PlayerWeaponsManager PlayerWeaponsManager => m_PlayerWeaponsManager;
   public WeaponAimingComponent AimingComponent => m_AimingComponent;
   public CharacterAnimatorController CharacterAnimatorController => m_AnimatorController;
   public MechaArmatureAimingComponent ArmatureAimingComponent => m_ArmatureAimingComponent;
   
   public void OnCharacterAvatarSpawn(AnimatorOverrideController animatorOverrideController, Avatar avatar,Transform aimingPoint)
   {
      m_AnimatorController.ApplyAnimatorOverrideController(animatorOverrideController,avatar);
      m_ArmatureAimingComponent.RegisterAimingPoint(aimingPoint);
   }
}
