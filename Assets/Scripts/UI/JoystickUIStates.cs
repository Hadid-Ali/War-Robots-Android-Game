using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class JoystickUIStates : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
{
    [SerializeField] private Image m_JoystickBase;
    [SerializeField] private Image m_JoystickHandle;

    [SerializeField] private Sprite m_JoystickBaseUpState;
    [SerializeField] private Sprite m_JoystickBaseDownState;
    
    [SerializeField] private Sprite m_JoystickHandleDownState;
    [SerializeField] private Sprite m_JoystickHandleUpState;


    private void Start()
    {
        
    }

    void IPointerDownHandler.OnPointerDown(PointerEventData pointerEventData)
    {
        m_JoystickBase.sprite = m_JoystickBaseDownState;
        m_JoystickHandle.sprite = m_JoystickHandleDownState;
    }

    void IPointerUpHandler.OnPointerUp(PointerEventData pointerEventData)
    {
        m_JoystickBase.sprite = m_JoystickBaseUpState;
        m_JoystickHandle.sprite = m_JoystickHandleUpState;
    }
}
