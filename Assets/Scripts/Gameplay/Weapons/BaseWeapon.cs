using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseWeapon : MonoBehaviour
{
    [SerializeField] protected int[] m_MagazineSize;
    [SerializeField] protected int[] m_WeaponCoolDownDuration;

    private int m_CurrentAmmoCount;
    private int m_CurrentCoolDownRemainingTime;

    public virtual void Fire()
    {
        m_CurrentAmmoCount--;
    }

}
