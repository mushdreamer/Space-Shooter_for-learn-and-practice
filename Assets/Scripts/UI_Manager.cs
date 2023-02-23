using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    [SerializeField]
    private Text Score_text;
    // Start is called before the first frame update
    void Start()
    {
        Score_text.text = "Score: " + 0;
    }

    // Update is called once per frame

    public void updateScore(int Score)
    {
        Score_text.text = "Score: " + Score.ToString();
    }
}
