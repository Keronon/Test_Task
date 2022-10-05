using UnityEngine;

public class Game_control : MonoBehaviour
{
    // ===== ===== OUTSIDE VALUES ===== =====

    [SerializeField] private GameObject coins;
    [SerializeField] private GameObject coin;
    [SerializeField] private GameObject spikes;
    [SerializeField] private GameObject spike;

    // ===== ===== FUNCTIONS ===== =====

    private void Start()
    {
        for (int i = 0; i < Score_keeper.max_score; i++)
        {
            Instantiate(coin,  new Vector3(Random.Range(-2f, 2f), Random.Range(-2f, 2f), 0), new Quaternion()).transform.parent = coins.transform;
            Instantiate(spike, new Vector3(Random.Range(-2f, 2f), Random.Range(-2f, 2f), 0), new Quaternion()).transform.parent = spikes.transform;
        }
    }
}
