using System;
using UnityEngine;

namespace BB
{
    [CreateAssetMenu(fileName = "EnemiesDataScriptableObject", menuName = "BuffaloBuffalo/Enemies Data", order = 1)]
    internal class EnemiesScriptable : ScriptableObject
    {
        [field: SerializeField] public EnemyObject[] Enemies { get; private set; }

        [Serializable]
        internal class EnemyObject
        {
            [field: SerializeField] public EnemyData.EnemyType Type { get; private set; }
            [field: SerializeField] public EnemyBase Prefab { get; private set; }
            [field: SerializeField] public EnemyData Data { get; private set; }
        }
    }
}