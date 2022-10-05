using System;
using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;

[System.Serializable]
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

    private AimObject m_CurrentAimObject;
    private PlayerController m_PlayerController;


    private void Start()
    {
        m_PlayerController = GetComponent<PlayerController>();
    }

    private void LateUpdate()
    {
        if (!m_CanAim || m_Crosshair is null)
            return;

        Aim();
    }

    private void Aim()
    {
        Ray ray = Camera.main.ScreenPointToRay(m_Crosshair.AimingPosition);

        if (Physics.Raycast(ray, out RaycastHit raycastHit, Mathf.Infinity,m_AimLayerMask))
        {
            m_Crosshair.Focus();
            if (m_CurrentAimObject is null)
            {
                m_CurrentAimObject = new AimObject(raycastHit.transform.gameObject, raycastHit.point);
            }
            else
            {
                m_CurrentAimObject.UnderAimObject = raycastHit.transform.gameObject;
                m_CurrentAimObject.UnderAimPosition = raycastHit.point;
            }
        }
        else
        {
            m_Crosshair.UnFocus();
            m_CurrentAimObject = null;
        }
        m_PlayerController.PlayerWeaponsManager.UpdateWeaponAimObject(m_CurrentAimObject);
    }
}
