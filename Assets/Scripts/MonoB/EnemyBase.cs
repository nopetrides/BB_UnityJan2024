using UnityEngine;
using UnityEngine.UI;

namespace BB
{
    /// <summary>
    ///     Enemy Prefab script
    /// </summary>
    internal class EnemyBase : MonoBehaviour
    {
        [SerializeField] private Rigidbody Rb;
        [SerializeField] private Canvas WorldCanvas;
        [SerializeField] private Text WorldText;
        
        private EnemyManager _manager;
        private EnemyData.EnemyType _type;
        private EnemyData _data;
        
        private float _currentAttackPower;
        private float _currentHealth;
        private float _currentSpeed;

        internal void Init(EnemyManager manager, EnemyData.EnemyType type, EnemyData data)
        {
            _manager = manager;
            _type = type;
            SetData(data);
        }

        internal void SetData(EnemyData data)
        {
            _data = data;
            _currentAttackPower = _data.AttackPower;
            _currentHealth = _data.Health;
            _currentSpeed = _data.Speed;
            WorldText.text = $"Type: {_type}\nClass: {_data.Class}\nAttack: {_currentAttackPower}\nHealth: {_currentHealth}\nSpeed: {_currentSpeed}\nSpawn Rate: {_data.SpawnRate, 0:0.00)}";
            WorldCanvas.transform.rotation = transform.rotation;
        }

        private void OnEnable()
        {
            Rb.velocity = Vector3.zero;
            Rb.angularVelocity = Vector3.zero;
        }

        internal void TakeDamage()
        {
            _currentHealth--;
            if (_currentHealth <= 0)
            {
                OnDeath();
            }
        }

        private void OnDeath()
        {
            if (_manager != null)
                _manager.ReleaseEnemy(_type, this);
        }
    }
}