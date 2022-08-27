using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechaArmatureAimingComponent : MonoBehaviour
{
    [SerializeField] private Transform m_TransformAimingBone;
    [SerializeField] private Transform m_AimingPointTransform;

    [SerializeField] private bool m_X;
    [SerializeField] private bool m_Y;
    [SerializeField] private bool m_Z;

    private Vector3 m_DefaultAimingBoneRotation;

    private void Update()
    {
        m_DefaultAimingBoneRotation = m_TransformAimingBone.eulerAngles;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        m_TransformAimingBone.transform.rotation =
            Quaternion.LookRotation(m_AimingPointTransform.position - m_TransformAimingBone.position);
        
        Vector3 vAiming = m_TransformAimingBone.eulerAngles;
        
        m_TransformAimingBone.eulerAngles = new Vector3(m_X ? vAiming.x : m_DefaultAimingBoneRotation.x,
            m_Y ? vAiming.y : m_DefaultAimingBoneRotation.y,
            m_Z ? vAiming.z : m_DefaultAimingBoneRotation.z);
    }
}