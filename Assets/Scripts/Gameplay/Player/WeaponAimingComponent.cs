using System;
using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;

public class AimObject
{
    public GameObject UnderAimObject { get; set; }
    public Vector3 UnderAimPosition  { get; set; }

    public AimObject(GameObject aimObject, Vector3 aimPosition)
    {
        UnderAimObject = aimObject;
        UnderAimPosition = aimPosition;
    }
}

public class WeaponAimingComponent : MonoBehaviour
{
    [SerializeField] private Crosshair m_Crosshair;
    [SerializeField] private bool m_CanAim = true;

    [SerializeField] private LayerMask m_AimLayerMask;
    
    public AimObject CurrentAimObject { private set; get; }

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
            if (CurrentAimObject is null)
            {
                CurrentAimObject = new AimObject(raycastHit.transform.gameObject, raycastHit.point);
            }
            else
            {
                CurrentAimObject.UnderAimObject = raycastHit.transform.gameObject;
                CurrentAimObject.UnderAimPosition = raycastHit.point;
            }
        }
        else
        {
            m_Crosshair.UnFocus();
            CurrentAimObject = null;
        }
    }
}
