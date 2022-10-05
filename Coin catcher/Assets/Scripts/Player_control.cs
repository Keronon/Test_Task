using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_control : MonoBehaviour
{
    [SerializeField] private GameObject kill_particles;

    [SerializeField] private GameObject score_value;
    [SerializeField] private GameObject score_max;

    private void Start()
    {
        Score_keeper.max_score = Random.Range(1, 15);
        score_max.                      GetComponent<UnityEngine.UI.Text>().text = Score_keeper.max_score.ToString();
        score_max.transform.GetChild(0).GetComponent<UnityEngine.UI.Text>().text = Score_keeper.max_score.ToString();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Coin")
        {
            Destroy(other.gameObject);
            Score_keeper.score++;
            score_value.                      GetComponent<UnityEngine.UI.Text>().text = Score_keeper.score.ToString();
            score_value.transform.GetChild(0).GetComponent<UnityEngine.UI.Text>().text = Score_keeper.score.ToString();

            if (Score_keeper.score == Score_keeper.max_score)
                SceneManager.LoadScene("RestartScene", LoadSceneMode.Single);
        }
        else if (other.tag == "Spike")
        {
            Instantiate(kill_particles, transform.position, new Quaternion());
            Destroy(gameObject);

            SceneManager.LoadScene("RestartScene", LoadSceneMode.Single);
        }
    }
}
