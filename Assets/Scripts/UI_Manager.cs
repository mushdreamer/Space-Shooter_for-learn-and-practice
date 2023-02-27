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
    private Image Desk_toshow_lives;//这个相当于一个展示柜，我们将照片搬出来，然后放置在展示柜上.Let UI Manager know what we want to show exist

    [SerializeField]
    private Sprite[] Lives;//这个是照片的几种状态

    [SerializeField]
    private Text Desk_toshow_GameOver;

    [SerializeField]
    private Text Desk_toshow_Restart;
    // Start is called before the first frame update

    private GameManager gameOver;
    void Start()
    {
        gameOver = GameObject.Find("GameManager").GetComponent<GameManager>();
        Desk_toshow_Score.text = "Score: " + 0;
        Desk_toshow_GameOver.gameObject.SetActive(false);
        Desk_toshow_Restart.gameObject.SetActive(false);
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

    public void updateGameOver()
    {
        gameOver.GameOver();
        Desk_toshow_GameOver.gameObject.SetActive(true);
        Desk_toshow_Restart.gameObject.SetActive(true);
        StartCoroutine(gameOverFlicker());
    }

    IEnumerator gameOverFlicker()
    {
        while (true)
        {
            Desk_toshow_GameOver.text = "GAME OVER";
            Desk_toshow_Restart.text = "Press R to Restart";
            yield return new WaitForSeconds(0.5f);
            Desk_toshow_GameOver.text = "";
            Desk_toshow_Restart.text = "";
            yield return new WaitForSeconds(0.5f);
        }
    }
}
