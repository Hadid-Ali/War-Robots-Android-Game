using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseWeapon : MonoBehaviour
{
    [SerializeField] protected int m_MagazineSize;
    [SerializeField] protected int m_WeaponCoolDownDuration;

    [SerializeField] private ParticleSystem[] m_WeaponParticles;
    [SerializeField] private float m_WeaponShootingRate = 0.2f;
    
    private int m_CurrentAmmoCount;
    private int m_CurrentCoolDownRemainingTime;
    
    public Action<int> OnWeaponRemainingCoolDownUpdate;
    public Action<int> OnWeaponAmmoCountUpdate;

    private WaitForSeconds m_WeaponCooldownRoutineWait = new WaitForSeconds(1f);

    public float WeaponShootingRate => m_WeaponShootingRate;
    
    private void Start()
    {
    }

    public virtual void Fire()
    {
        for (int i = 0; i < m_WeaponParticles.Length; i++)
        {
            m_WeaponParticles[i].Play(true);
        }
        
        m_CurrentAmmoCount--;
        if (m_CurrentAmmoCount <= 0)
        {
            m_CurrentCoolDownRemainingTime = m_WeaponCoolDownDuration;
        }
    }

    private IEnumerator WeaponCoolDownRoutine()
    {
        while (m_CurrentCoolDownRemainingTime > 0)
        {
            OnWeaponRemainingCoolDownUpdate?.Invoke(m_CurrentCoolDownRemainingTime);
            yield return m_WeaponCooldownRoutineWait;

            m_CurrentCoolDownRemainingTime--;
        }

        m_CurrentAmmoCount = m_MagazineSize;
    }
}