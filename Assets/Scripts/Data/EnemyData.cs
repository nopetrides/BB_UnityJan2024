using System;

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
        
        public EnemyClass Class;
        public float AttackPower;
        public float Health;
        public float Speed;
        public float SpawnRate;
    }
}