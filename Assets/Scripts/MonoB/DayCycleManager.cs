using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace BB
{
    internal class DayCycleManager : MonoBehaviour
    {
        [SerializeField] private DayCycleData TimeOfDayData;
        [SerializeField] private GameObject[] TimeOfDayElements;
        [SerializeField] private Text TimeOfDayText;

        internal DayCycleData.TimeOfDay CurrentTime { get; private set; }

        internal void Init(EnemyManager enemyManager)
        {
            SetTimeOfDay();
            UpdateTimeOfDayData(enemyManager);
        }

        private void SetTimeOfDay()
        {
            var index = Random.Range(0, TimeOfDayData.Times.Length);
            CurrentTime = TimeOfDayData.Times[index];
            for (var i = 0; i < TimeOfDayElements.Length; i++) TimeOfDayElements[i].SetActive(i == index);

            TimeOfDayText.text = $"Time Of Day: {CurrentTime.TimeSection}";
        }

        private void UpdateTimeOfDayData(EnemyManager enemyManager)
        {
            var data = enemyManager.GetRuntimeData();
            foreach (var modifier in CurrentTime.EnemyModifiers)
            foreach (var enemy in data.Enemies.Where(enemy =>
                         enemy.Type == modifier.Type || enemy.Data.Class == modifier.Class))
            {
                enemy.Data.AttackPower += Random.Range(modifier.AttackMod.x, modifier.AttackMod.y);
                enemy.Data.Health += Random.Range(modifier.HealthMod.x, modifier.HealthMod.y);
                enemy.Data.Speed += Random.Range(modifier.SpeedMod.x, modifier.SpeedMod.y);
                enemy.Data.SpawnRate += Random.Range(modifier.SpawnRateMod.x, modifier.SpawnRateMod.y);
                enemy.Data.CanSpawn = modifier.CanSpawn;
            }

            enemyManager.SetRuntimeData(data);
        }
    }
}