using System;
using UnityEngine;

namespace BB
{
    /// <summary>
    ///     Serialized Data Information
    /// </summary>
    [Serializable]
    public class EnemyData
    {
        public enum EnemyType
        {
            None = 0,
            Red,
            Brown,
            Blue,
            Green,
            Yellow
        }
        public enum EnemyClass
        {
            None = 0,
            Grunt,
            Archer,
            Assassin
        }
        [field: SerializeField] public EnemyClass Class { get; private set; }
        [field: SerializeField] public float AttackPower { get; private set; }
        [field: SerializeField] public float Health { get; private set; }
        [field: SerializeField] public float Speed { get; private set; }
        [field: SerializeField] public float SpawnRate { get; private set; }
    }
}