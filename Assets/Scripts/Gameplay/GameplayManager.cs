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

    public Action<Transform, Crosshair> OnPlayerSpawn;

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
        OnPlayerSpawn(m_CameraManager.AimPoint, m_GameplayUIHandler.Crosshair);
    }
}
