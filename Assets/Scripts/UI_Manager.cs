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
    private Image Desk_toshow_lives;//����൱��һ��չʾ�����ǽ���Ƭ�������Ȼ�������չʾ����.Let UI Manager know what we want to show exist

    [SerializeField]
    private Sprite[] Lives;//�������Ƭ�ļ���״̬

    [SerializeField]
    private Text Desk_toshow_GameOver;
    // Start is called before the first frame update
    void Start()
    {
        Desk_toshow_Score.text = "Score: " + 0;
        Desk_toshow_GameOver.gameObject.SetActive(false);
    }

    // Update is called once per frame

    public void updateScore(int Score)
    {
        Desk_toshow_Score.text = "Score: " + Score.ToString();
    }

    public void updateLive(int health)
    {
        Desk_toshow_lives.sprite = Lives[health];//��Ӱ����Ƭ��������Ѫ����������ǽ����߽�ϳ���һ�д���
    }

    public void updateGameOver()
    {
        Desk_toshow_GameOver.gameObject.SetActive(true);
        Time.timeScale = 0;//pause the game
    }
}
