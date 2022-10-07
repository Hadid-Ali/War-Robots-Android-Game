using System;
using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;


public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] private PlayerController[] m_AllPlayers;

    private PlayerController m_CurrentPlayer;
    public PlayerController CurrentPlayer => m_CurrentPlayer;

    public void Initialize(ref Action<Transform, Crosshair> onPlayerAction)
    {
        onPlayerAction += OnPlayerSpawned;
    }

    public void SpawnPlayer(int index)
    {
        for (int i = 0; i < m_AllPlayers.Length; i++)
        {
            if (i == index)
            {
                m_CurrentPlayer = m_AllPlayers[i];
            }
            else
            {
                m_AllPlayers[i].Hide();
            }
        }
    }

    public void OnPlayerSpawned(Transform aimPoint, Crosshair crosshair)
    {
        m_CurrentPlayer.OnPlayerSpawn(aimPoint, crosshair);
    }
}
