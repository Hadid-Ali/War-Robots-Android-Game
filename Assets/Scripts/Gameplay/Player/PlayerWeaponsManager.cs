using System;
using System.Collections;
using System.Collections.Generic;
using Gameplay.Weapons;
using UnityEngine;

public class PlayerWeaponsManager : MonoBehaviour
{
   [SerializeField] private SimpleWeapon m_CurrentPrimaryWeapon;
   [SerializeField] private BaseWeapon m_CurrentSecondaryWeapon;

   private AimObject m_AimObject;
   
   private void OnEnable()
   {
      InputManager.OnPrimaryWeaponDown += FirePrimaryWeapon;
      InputManager.OnSecondaryWeaponDown += FireSecondaryWeapon;

      InputManager.OnPrimaryWeaponUp += ReleaseFirePrimaryWeapon;
      InputManager.OnSecondaryWeaponUp += ReleaseSecondaryWeapon;
      
      m_CurrentPrimaryWeapon.Initialize(TryWeaponDamage);
   }

   public void UpdateWeaponAimObject(AimObject aimObject)
   {
      m_AimObject = aimObject;
      m_CurrentPrimaryWeapon.RegisterAimObject(aimObject);
      m_CurrentSecondaryWeapon.RegisterAimObject(aimObject);
   }

   private void TryWeaponDamage(float damage)
   {
      if(m_AimObject is null)
         return;

      if (m_AimObject.UnderAimObject.TryGetComponent(out HealthController healthController))
      {
         healthController.ApplyDamage(damage);
      }
   }
   
   private void FirePrimaryWeapon()
   {
      m_CurrentPrimaryWeapon.OnFireDown();
   }

   private void ReleaseFirePrimaryWeapon()
   {
      m_CurrentPrimaryWeapon.OnFireUp();
   }

   private void FireSecondaryWeapon()
   {
      m_CurrentSecondaryWeapon.OnFireDown();
   }  
   
   private void ReleaseSecondaryWeapon()
   {
      m_CurrentSecondaryWeapon.OnFireUp();
   }
}
