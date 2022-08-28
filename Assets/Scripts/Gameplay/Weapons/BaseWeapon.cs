using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseWeapon : MonoBehaviour
{
    [SerializeField] protected int m_MagazineSize;
    [SerializeField] protected int m_WeaponCoolDownDuration;

    private ParticleSystem[] weaponParticles;
    
    private int m_CurrentAmmoCount;
    private int m_CurrentCoolDownRemainingTime;

    public Action<int> OnWeaponRemainingCoolDownUpdate;
    public Action<int> OnWeaponAmmoCountUpdate;

    private WaitForSeconds m_WeaponCooldownRoutineWait = new WaitForSeconds(1f);

    private void Start()
    {
    }

    public virtual void Fire()
    {
        for (int i = 0; i < weaponParticles.Length; i++)
        {
            weaponParticles[i].Play(true);
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