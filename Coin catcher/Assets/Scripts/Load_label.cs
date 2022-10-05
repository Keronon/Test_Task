using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Load_label : MonoBehaviour
{
    void Awake()
    {
        if (Score_keeper.score == Score_keeper.max_score)
        {
                                  GetComponent<UnityEngine.UI.Text>().text = "! you win !";
            transform.GetChild(0).GetComponent<UnityEngine.UI.Text>().text = "! you win !";
        }
        else
        {
                                  GetComponent<UnityEngine.UI.Text>().text = "! you loose !";
            transform.GetChild(0).GetComponent<UnityEngine.UI.Text>().text = "! you loose !";
        }
    }
}
