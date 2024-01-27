using System.Collections.Generic;
using UnityEngine;

namespace BB
{
    public class SpawnPoint : MonoBehaviour
    {
        // TODO custom inspector to limit which options show up
        [SerializeField] private bool SpawnAny;
        [SerializeField] private EnemyData.EnemyType[] SpawnEnemyTypes;
        [SerializeField] private EnemyData.EnemyClass[] SpawnEnemyClasses;

        private EnemyManager _enemyPool;
        private Dictionary<EnemyData.EnemyType, SpawnData> _spawnData;
        
        // Start is called before the first frame update
        internal void Init(EnemyManager enemyPool)
        {
            _enemyPool = enemyPool;
            _spawnData = new Dictionary<EnemyData.EnemyType, SpawnData>();
            if (SpawnAny)
            {
                foreach (var enemy in _enemyPool.AllEnemies)
                {
                    _spawnData.Add(enemy.Type, new SpawnData(enemy.Data));
                }
                return;
            }
            
            foreach (var t in SpawnEnemyTypes)
            {
                foreach (var enemy in _enemyPool.GetEnemiesByType(t))
                {
                    _spawnData.Add(t, new SpawnData(enemy.Data));
                }
            }

            foreach (var c in SpawnEnemyClasses)
            {
                foreach (var enemy in enemyPool.GetEnemiesByClass(c))
                {
                    _spawnData.Add(enemy.Type, new SpawnData(enemy.Data));
                }
            }
        }

        // Update is called once per frame
        private void Update()
        {
            foreach (var (key, spawnData) in _spawnData)
            {
                spawnData.Timer += Time.deltaTime;
                if (spawnData.Timer > spawnData.Data.SpawnRate)
                {
                    spawnData.Timer = 0;
                    var spawned = _enemyPool.SpawnEnemy(key, spawnData.Data);
                    var spawnAt = transform;
                    spawned.transform.SetPositionAndRotation(spawnAt.position, spawnAt.rotation);
                }
            }
        }

        private class SpawnData
        {
            internal float Timer { get; set; }
            internal EnemyData Data { get; }

            internal SpawnData(EnemyData d)
            {
                Timer = 0;
                Data = d;
            }
        }
    }
}