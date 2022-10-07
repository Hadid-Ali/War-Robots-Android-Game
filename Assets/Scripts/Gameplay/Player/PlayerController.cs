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
   [SerializeField] private PlayerHealthController m_PlayerHealthController;
   
   public PlayerWeaponsManager PlayerWeaponsManager => m_PlayerWeaponsManager;

   public void OnPlayerSpawn(Transform aimPoint, Crosshair crossHair,Action<float> healthBarEvent)
   {
      m_ArmatureAimingComponent.RegisterAimingPoint(aimPoint);
      m_AimingComponent.RegisterCrosshair(crossHair);
      m_PlayerHealthController.RegisterHealthBarEvent(healthBarEvent);
      gameObject.SetActive(true);
   }

   public void Hide()
   {
      gameObject.SetActive(false);
   }
   
}
