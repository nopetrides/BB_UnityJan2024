using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Pool;

namespace BB
{
    internal class EnemyManager : MonoBehaviour
    {
        [SerializeField] private EnemiesScriptable EnemiesData;
        
        private Dictionary<EnemyData.EnemyType, ObjectPool<EnemyBase>> _pools;

        private EnemiesScriptable _runtimeData;
        internal EnemiesScriptable.EnemyObject[] AllEnemies => _runtimeData.Enemies;

        internal void InitializePool()
        {
            _runtimeData = Instantiate(EnemiesData);
            
            _pools = new Dictionary<EnemyData.EnemyType, ObjectPool<EnemyBase>>();
            foreach (EnemyData.EnemyType enemyType in Enum.GetValues(typeof(EnemyData.EnemyType)))
            {
                if (!_pools.ContainsKey(enemyType))
                {
                    _pools.Add(enemyType,
                        new ObjectPool<EnemyBase>(
                            () => CreatePooledItem(enemyType),
                            OnTakeFromPool,
                            OnReturnedToPool,
                            OnDestroyPoolObject,
                            true, 
                            10, 
                            100));
                }
            }
        }

        internal EnemiesScriptable GetRuntimeData()
        {
            return _runtimeData;
        }

        internal void SetRuntimeData(EnemiesScriptable data)
        {
            _runtimeData = data;
        }

        private EnemyBase CreatePooledItem(EnemyData.EnemyType t)
        {
            var toCreate = GetEnemy(t);
            if (toCreate == null)
            {
                Debug.LogError("Failed to load Enemy Type: " + t);
                return null;
            }
            EnemyBase enemy = Instantiate(toCreate.Prefab, transform);
            enemy.Init(this, t, toCreate.Data);
            return enemy;
        }
        
        private void OnTakeFromPool(EnemyBase enemy)
        {
            enemy.gameObject.SetActive(true);
        }
        private void OnReturnedToPool(EnemyBase enemy)
        {
            enemy.gameObject.SetActive(false);
        }

        private void OnDestroyPoolObject(EnemyBase enemy)
        {
            Destroy(enemy.gameObject);
        }

        internal EnemyBase SpawnEnemy(EnemyData.EnemyType type, EnemyData data)
        {
            var enemy = _pools[type].Get();
            enemy.SetData(data);
            return enemy;
        }

        internal void ReleaseEnemy(EnemyData.EnemyType type, EnemyBase enemy)
        {
            _pools[type].Release(enemy);
        }

        private EnemiesScriptable.EnemyObject GetEnemy(EnemyData.EnemyType t)
        {
            return AllEnemies.FirstOrDefault((e) => e.Type == t);
        }
        
        internal EnemiesScriptable.EnemyObject[] GetEnemiesByType(EnemyData.EnemyType t)
        {
            return AllEnemies.Where(enemy => enemy.Type == t).ToArray();
        }

        internal EnemiesScriptable.EnemyObject[] GetEnemiesByClass(EnemyData.EnemyClass c)
        {
            return AllEnemies.Where(enemy => enemy.Data.Class == c).ToArray();
        }
    }
}