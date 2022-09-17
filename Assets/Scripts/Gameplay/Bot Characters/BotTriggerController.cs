using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotTriggerController : MonoBehaviour
{
   [SerializeField] private Action<string,GameObject> m_OnTriggerEnter;
   [SerializeField] private Action<string,GameObject> m_OnTriggerExit;

   public void Init(Action<string, GameObject> onTriggerEnter, Action<string, GameObject> onTriggerExit)
   {
      m_OnTriggerEnter = onTriggerEnter;
      m_OnTriggerExit = onTriggerExit;
   }
   
   private void OnTriggerEnter(Collider other)
   {
      m_OnTriggerEnter?.Invoke(other.tag,other.gameObject);
   }

   private void OnTriggerExit(Collider other)
   {
      m_OnTriggerExit?.Invoke(other.tag, other.gameObject);
   }
}
