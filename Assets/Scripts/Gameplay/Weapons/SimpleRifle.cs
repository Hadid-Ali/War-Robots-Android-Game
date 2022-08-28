using UnityEngine;

namespace Gameplay.Weapons
{
    public class SimpleRifle : BaseWeapon
    {
        [SerializeField] private WeaponVFXHandler m_WeaponVFXHandler;

        protected override void FireInternal()
        {
            base.FireInternal();

            if (m_CurrentAimObject is not null)
            {
                m_WeaponVFXHandler.ShowBulletImpact(m_CurrentAimObject.UnderAimPosition);
            }
        }
    }
}
