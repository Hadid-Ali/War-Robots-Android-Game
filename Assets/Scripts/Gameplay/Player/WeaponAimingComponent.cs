using System;
using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;
using Random = System.Random;

public class WeaponAimingComponent : MonoBehaviour
{
    [SerializeField] private Crosshair m_Crosshair;
    [SerializeField] private bool m_CanAim = true;

    [SerializeField] private LayerMask m_AimLayerMask;

    private void Update()
    {
        if (!m_CanAim)
            return;

        Aim();
    }

    private void Aim()
    {
        Ray ray = Camera.main.ScreenPointToRay(m_Crosshair.AimingPosition);

        if (Physics.Raycast(ray, out RaycastHit raycastHit, Mathf.Infinity,m_AimLayerMask))
        {
            m_Crosshair.Focus();
        }
        else
        {
            m_Crosshair.UnFocus();
        }
    }
}
