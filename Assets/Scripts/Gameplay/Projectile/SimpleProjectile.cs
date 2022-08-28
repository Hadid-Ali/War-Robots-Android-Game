using UnityEngine;

namespace Gameplay.Projectile
{
    public abstract class SimpleProjectile : MonoBehaviour
    {
        [SerializeField] private Rigidbody m_Rigidbody;
        [SerializeField] private float m_ProjectileSpeed;

        public void Launch(Vector3 targetPosition = default)
        {
            Vector3 travelDirection = transform.forward;
            
            if (targetPosition != default)
            {
                travelDirection = targetPosition - transform.position;
                transform.LookAt(targetPosition);
            }
            
            m_Rigidbody.AddForce(travelDirection.normalized*m_ProjectileSpeed);
        }
    }
}
