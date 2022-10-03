using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAvatar : MonoBehaviour
{
    [SerializeField] private AnimatorOverrideController m_AvatarOverrideController;
    [SerializeField] private Avatar m_Avatar;
    
    [SerializeField] private Transform m_AimingPoint;

    private void OnEnable()
    {
        PlayerController playerController = GetComponentInParent<PlayerController>();
        playerController.OnCharacterAvatarSpawn(m_AvatarOverrideController, m_Avatar, m_AimingPoint);
    }
}
