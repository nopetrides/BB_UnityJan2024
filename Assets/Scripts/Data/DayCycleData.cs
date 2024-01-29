using System;
using UnityEngine;

namespace BB
{
    [CreateAssetMenu(fileName = "TimesOfDayScriptableObject", menuName = "BuffaloBuffalo/Times Of Day Data", order = 2)]
    internal class DayCycleData : ScriptableObject
    {
        [field: SerializeField] public TimeOfDay[] Times { get; private set; }

        internal enum ToD
        {
            None = 0,
            Morning,
            Afternoon,
            Night
        }

        [Serializable]
        internal class TimeOfDay
        {
            [field: SerializeField] public ToD TimeSection { get; private set; }
            [field: SerializeField] public DataModifier[] EnemyModifiers { get; private set; }
        }

        [Serializable]
        internal class DataModifier
        {
            // TODO custom inspector for either type or class
            [field: SerializeField] public EnemyData.EnemyType Type { get; private set; }
            [field: SerializeField] public EnemyData.EnemyClass Class { get; private set; }

            [field: SerializeField] public bool CanSpawn { get; private set; } = true;

            // TODO change from Vector2 to some other custom object for clarity
            // X is min change, Y is max change
            [field: SerializeField] public Vector2 AttackMod { get; private set; }
            [field: SerializeField] public Vector2 HealthMod { get; private set; }
            [field: SerializeField] public Vector2 SpeedMod { get; private set; }
            [field: SerializeField] public Vector2 SpawnRateMod { get; private set; }
        }
    }
}