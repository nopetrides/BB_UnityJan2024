using UnityEngine;

namespace BB
{
    public class KillingFloor : MonoBehaviour
    {
        [SerializeField] private Collider OwnCollider;
        [SerializeField] private Collider[] IgnoredColliders;

        private void Start()
        {
            foreach (var c in IgnoredColliders)
            {
                Physics.IgnoreCollision(OwnCollider, c);
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            var enemy = collision.gameObject.GetComponent<EnemyBase>();
            if (enemy != null)
            {
                enemy.TakeDamage();
            }
        }
    }
}