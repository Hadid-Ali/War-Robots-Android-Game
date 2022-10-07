using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
   private Transform m_CurrentPlayer;

   public Transform CurrentPlayer => m_CurrentPlayer;

   public void RegisterPlayer(Transform player)
   {
      m_CurrentPlayer = player;
   }
}
