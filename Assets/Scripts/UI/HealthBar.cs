using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image m_HealthBarImage;

    public void UpdateHealthBar(float value)
    {
        m_HealthBarImage.fillAmount = value;
    }
}
