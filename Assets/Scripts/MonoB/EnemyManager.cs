
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Pool;

namespace BB
{
    internal class EnemyManager : MonoBehaviour
    {
        [SerializeField] private EnemiesScriptable EnemiesData;
        
        private ObjectPool<EnemyBase> _pool;

        internal void InitializePool()
        {
            
        }

        internal EnemyBase SpawnEnemy(EnemyData data)
        {
            return _pool.Get();
        }

        internal void ReleaseEnemy(EnemyBase enemy)
        {
            _pool.Release(enemy);
        }

        internal EnemiesScriptable.EnemyObject[] GetEnemiesByType(EnemyData.EnemyType t)
        {
            
            return EnemiesData.Enemies.Where(enemy => enemy.Type == t).ToArray();
        }

        internal EnemiesScriptable.EnemyObject[] GetEnemiesByClass(EnemyData.EnemyClass c)
        {
            return EnemiesData.Enemies.Where(enemy => enemy.Data.Class == c).ToArray();
        }
    }
}