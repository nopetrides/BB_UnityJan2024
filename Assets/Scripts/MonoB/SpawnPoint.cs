using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BB
{
    public class SpawnPoint : MonoBehaviour
    {
        [SerializeField] private EnemyData.EnemyType[] SpawnEnemyTypes;
        [SerializeField] private EnemyData.EnemyClass[] SpawnEnemyClasses;

        private EnemyManager _enemyManager;
        
        // Start is called before the first frame update
        internal void Init()
        {
            
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}