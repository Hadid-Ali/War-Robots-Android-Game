using System;
using System.Collections;
using System.Collections.Generic;
using Gameplay.Weapons;
using UnityEngine;

public class PlayerWeaponsManager : MonoBehaviour
{
   [SerializeField] private BaseWeapon m_CurrentPrimaryWeapon;
   [SerializeField] private BaseWeapon m_CurrentSecondaryWeapon;

   private PlayerController m_PlayerController;


   private void Start()
   {
      m_PlayerController = GetComponent<PlayerController>();
   }

   private void OnEnable()
   {
      InputManager.OnPrimaryWeaponDown += FirePrimaryWeapon;
      InputManager.OnSecondaryWeaponDown += FireSecondaryWeapon;

      InputManager.OnPrimaryWeaponUp += ReleaseFirePrimaryWeapon;
      InputManager.OnSecondaryWeaponUp += ReleaseSecondaryWeapon;
   }

   private void FirePrimaryWeapon()
   {
      m_CurrentPrimaryWeapon.OnFireDown(m_PlayerController.AimingComponent.CurrentAimObject);
   }

   private void ReleaseFirePrimaryWeapon()
   {
      m_CurrentPrimaryWeapon.OnFireUp();
   }

   private void FireSecondaryWeapon()
   {
      m_CurrentSecondaryWeapon.OnFireDown(m_PlayerController.AimingComponent.CurrentAimObject);
   }  
   
   private void ReleaseSecondaryWeapon()
   {
      m_CurrentSecondaryWeapon.OnFireUp();
   }
}
