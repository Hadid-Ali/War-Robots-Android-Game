using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   [SerializeField] private PlayerWeaponsManager m_PlayerWeaponsManager;
   [SerializeField] private WeaponAimingComponent m_AimingComponent;
   
   public PlayerWeaponsManager PlayerWeaponsManager => m_PlayerWeaponsManager;
   public WeaponAimingComponent AimingComponent => m_AimingComponent;
}
