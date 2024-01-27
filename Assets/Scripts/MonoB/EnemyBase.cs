using UnityEngine;

namespace BB
{
    /// <summary>
    ///     Enemy Prefab script
    /// </summary>
    internal class EnemyBase : MonoBehaviour
    {
        private EnemyManager _manager;
        private EnemyData.EnemyType _type;
        private EnemyData _data;

        internal void Init(EnemyManager manager, EnemyData.EnemyType type, EnemyData data)
        {
            _type = type;
            SetData(data);
        }

        internal void SetData(EnemyData data)
        {
            _data = data;
        }

        internal void TakeDamage()
        {
            _data.Health--;
            if (_data.Health <= 0)
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