using System;
using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    [SerializeField] private PlayerSpawner m_PlayerSpawner;
    [SerializeField] private GameplayUIHandler m_GameplayUIHandler;
    [SerializeField] private CameraManager m_CameraManager;

    private Transform m_GlobalBillBoardTarget;

    public Transform GlobalBillBoardTarget
    {
        get
        {
            m_GlobalBillBoardTarget ??= GameplayCamera.transform;
            return m_GlobalBillBoardTarget;
        }
    }
    public Camera GameplayCamera => m_CameraManager.MainPlayerCamera;
    public Action<Transform, Crosshair,Action<float>> OnPlayerSpawn;

    private void Awake()
    {
        GameManager.Instance.RegisterGameplayManager(this);
        m_PlayerSpawner.Initialize(ref OnPlayerSpawn);
    }

    private void OnDestroy()
    {
        OnPlayerSpawn = null;
        GameManager.Instance.UnRegisterGameplayManager(this);
    }

    public void SpawnPlayer(int index)
    {
        m_PlayerSpawner.SpawnPlayer(index);
        OnPlayerSpawn(m_CameraManager.AimPoint, m_GameplayUIHandler.Crosshair,
            m_GameplayUIHandler.HealthBar.UpdateHealthBar);
    }
}
