using System.Threading;
using OpenAI;
using UnityEngine;

namespace BB
{
    public class DemoManager : MonoBehaviour
    {
        [SerializeField] private EnemyManager EnemyPool;
        [SerializeField] private DayCycleManager DayCycle;
        [SerializeField] private SpawnPoint[] Spawners;

        private OpenAIApi _openAi = new();
        private CancellationTokenSource _token = new CancellationTokenSource();
        
        // Start is called before the first frame update
        private void Start()
        {
            EnemyPool.InitializePool();
            DayCycle.Init(EnemyPool);
            foreach (var sp in Spawners)
            {
                sp.Init(EnemyPool);
            }
        }

        private void OpenAI()
        {
            
        }
    }
}