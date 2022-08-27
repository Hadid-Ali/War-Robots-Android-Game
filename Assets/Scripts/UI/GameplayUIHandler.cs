using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UI;

public class GameplayUIHandler : MonoBehaviour
{
    [SerializeField] private Crosshair m_Crosshair;
    
    public Crosshair Crosshair => m_Crosshair;
}
