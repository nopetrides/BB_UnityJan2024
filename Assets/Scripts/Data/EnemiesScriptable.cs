using System;
using UnityEngine;

namespace BB
{
    [CreateAssetMenu(fileName = "EnemiesDataScriptableObject", menuName = "BuffaloBuffalo/Enemies Data", order = 1)]
    internal class EnemiesScriptable : ScriptableObject
    {
        public EnemyObject[] Enemies;

        [Serializable]
        internal class EnemyObject
        {
            public EnemyData.EnemyType Type;
            public EnemyBase Prefab;
            public EnemyData Data;
        }
    }
}