using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BB
{
    /// <summary>
    ///     The spawn point in the world where enemies appear.
    /// </summary>
    public class SpawnPoint : MonoBehaviour
    {
        // TODO custom inspector to limit which options show up
        [SerializeField] private bool SpawnAny;
        [SerializeField] private EnemyData.EnemyType[] SpawnEnemyTypes;
        [SerializeField] private EnemyData.EnemyClass[] SpawnEnemyClasses;
        // We don't *need* them to spawn more than once, but this was fun
        [SerializeField] private float RespawnDelay = 1f;

        private EnemyManager _enemyPool;
        private Dictionary<EnemyData.EnemyType, EnemyData> _spawnData;
        private float _spawnTimer;
        private bool _spawnAny;
        private float _spawnWeightTotal;
        
        /// <summary>
        ///     Initialize the spawn point
        ///     Must be done after the pool is ready
        /// </summary>
        /// <param name="enemyPool"></param>
        internal void Init(EnemyManager enemyPool)
        {
            _enemyPool = enemyPool;
            _spawnData = new Dictionary<EnemyData.EnemyType, EnemyData>();
            if (SpawnAny)
            {
                foreach (var enemy in _enemyPool.AllEnemies)
                {
                    _spawnData.Add(enemy.Type, enemy.Data);
                }
            }
            else
            {
                foreach (var t in SpawnEnemyTypes)
                {
                    foreach (var enemy in _enemyPool.GetEnemiesByType(t))
                    {
                        _spawnData.Add(t, enemy.Data);
                    }
                }

                foreach (var c in SpawnEnemyClasses)
                {
                    foreach (var enemy in enemyPool.GetEnemiesByClass(c))
                    {
                        _spawnData.Add(enemy.Type, enemy.Data);
                    }
                }
            }

            _spawnAny = _spawnData.Count > 0;
            // calculate once to save processing
            _spawnWeightTotal = _spawnData.Sum((kvp) => kvp.Value.SpawnRate);
        }

        // Update is called once per frame
        private void Update()
        {
            if (!_spawnAny)
                return;
            
            _spawnTimer += Time.deltaTime;
            if (_spawnTimer > RespawnDelay)
            {
                _spawnTimer = 0;
                SpawnNextEnemy();
            }
        }
        
        private void SpawnNextEnemy()
        {
            var nextEnemy = NextEnemyFromSpawnWeights();
            if (nextEnemy.Item1 == EnemyData.EnemyType.None)
            {
                Debug.LogError("Failed to calculate enemy to spawn!");
            }
            var spawned = _enemyPool.SpawnEnemy(nextEnemy.Item1, nextEnemy.Item2);
            var spawnAt = transform;
            spawned.transform.SetPositionAndRotation(spawnAt.position, spawnAt.rotation);
        }
        
        private (EnemyData.EnemyType, EnemyData) NextEnemyFromSpawnWeights()
        {
            float random = Random.Range(0, _spawnWeightTotal);
            float cumulative = 0;
            foreach (var kvp in _spawnData)
            {
                cumulative += kvp.Value.SpawnRate;
                if (random <= cumulative)
                {
                    return (kvp.Key, kvp.Value);
                }
            }

            return (EnemyData.EnemyType.None,null);
        }
    }
}