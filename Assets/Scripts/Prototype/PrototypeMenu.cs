using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrototypeMenu : MonoBehaviour
{
   [SerializeField] private GameObject [] m_Characters;
   [SerializeField] private Image[] m_ButtonImages;

   private void Start()
   {
       ChangeCharacter(0);
   }

   public void ChangeCharacter(int index)
   {
       for (int i = 0; i < m_Characters.Length; i++)
       {
           m_Characters[i].SetActive(i == index);
           m_ButtonImages[i].color = i == index ? Color.green : Color.white;
       }
   }
}
