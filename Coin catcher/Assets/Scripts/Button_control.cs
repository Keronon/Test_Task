using UnityEngine;
using UnityEngine.SceneManagement;

public class Button_control : MonoBehaviour
{
    public void OnPress()
    {
        Score_keeper.score = 0;
        SceneManager.LoadScene("MainGameScene", LoadSceneMode.Single);
    }
}
