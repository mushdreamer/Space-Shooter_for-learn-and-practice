using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    [SerializeField]
    private Text Desk_toshow_Score;

    [SerializeField]
    private Image Desk_toshow_lives;//这个相当于一个展示柜，我们将照片搬出来，然后放置在展示柜上

    [SerializeField]
    private Sprite[] Lives;//这个是照片的几种状态
    // Start is called before the first frame update
    void Start()
    {
        Desk_toshow_Score.text = "Score: " + 0;
    }

    // Update is called once per frame

    public void updateScore(int Score)
    {
        Desk_toshow_Score.text = "Score: " + Score.ToString();
    }

    public void updateLive(int health)
    {
        Desk_toshow_lives.sprite = Lives[health];//而影响照片的因素是血量，因此我们将三者结合成这一行代码
    }
}
