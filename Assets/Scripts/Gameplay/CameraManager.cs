using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
  [SerializeField] private Transform m_AimPoint;
  public Transform AimPoint => m_AimPoint;
}
