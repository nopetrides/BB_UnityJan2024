using BB;
using UnityEngine;

public class DemoManager : MonoBehaviour
{
    [SerializeField] private EnemyManager EnemyPool;
    [SerializeField] private SpawnPoint[] Spawners;
    // Start is called before the first frame update
    void Start()
    {
        EnemyPool.InitializePool();
        foreach (var sp in Spawners)
        {
            sp.Init(EnemyPool);
        }
    }
}
