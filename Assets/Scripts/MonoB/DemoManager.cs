using OpenAI;
using UnityEngine;

//using System.Linq;
//using UnityEngine.Networking;

namespace BB
{
    public class DemoManager : MonoBehaviour
    {
        [SerializeField] private EnemyManager EnemyPool;
        [SerializeField] private DayCycleManager DayCycle;

        [SerializeField] private SpawnPoint[] Spawners;
        //[SerializeField] private MeshRenderer Floor;

        private OpenAIApi _openAi;
        //private CancellationTokenSource _token = new ();

        // Start is called before the first frame update
        private void Start()
        {
            EnemyPool.InitializePool();
            DayCycle.Init(EnemyPool);
            foreach (var sp in Spawners) sp.Init(EnemyPool);
            // Need a valid account
            //OpenAI();
        }
/*
        private async void OpenAI()
        {
            _openAi = new OpenAIApi("PutAValidTokenHere");
            var request = new CreateImageRequest
            {
                Prompt = DayCycle.CurrentTime.ToString()
            };
            var task = await _openAi.CreateImage(request);
            var response = task.Data.FirstOrDefault();
            var url = response.Url;
            var uwr = UnityWebRequestTexture.GetTexture(url);
            var texture = DownloadHandlerTexture.GetContent(uwr);
            Floor.material.mainTexture = texture;
        }
*/
    }
}