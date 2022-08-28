using System;
using System.Collections;
using System.Collections.Generic;
using Gameplay.Weapons;
using UnityEngine;

public class PlayerWeaponsManager : MonoBehaviour
{
   [SerializeField] private BaseWeapon m_CurrentPrimaryWeapon;
   [SerializeField] private BaseWeapon m_CurrentSecondaryWeapon;

   private void OnEnable()
   {
      InputManager.OnPrimaryWeaponDown += FirePrimaryWeapon;
      InputManager.OnSecondaryWeaponDown += FireSecondaryWeapon;

      InputManager.OnPrimaryWeaponUp += ReleaseFirePrimaryWeapon;
      InputManager.OnSecondaryWeaponUp += ReleaseSecondaryWeapon;
   }

   public void UpdateWeaponAimObject(AimObject aimObject)
   {
      m_CurrentPrimaryWeapon.RegisterAimObject(aimObject);
      m_CurrentSecondaryWeapon.RegisterAimObject(aimObject);
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
