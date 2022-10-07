using System;
using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   [SerializeField] private PlayerWeaponsManager m_PlayerWeaponsManager;
   [SerializeField] private WeaponAimingComponent m_AimingComponent;
   [SerializeField] private MechaArmatureAimingComponent m_ArmatureAimingComponent;
   
   public PlayerWeaponsManager PlayerWeaponsManager => m_PlayerWeaponsManager;

   public void OnPlayerSpawn(Transform aimPoint, Crosshair crossHair)
   {
      m_ArmatureAimingComponent.RegisterAimingPoint(aimPoint);
      m_AimingComponent.RegisterCrosshair(crossHair);
      gameObject.SetActive(true);
   }

   public void Hide()
   {
      gameObject.SetActive(false);
   }
   
}
