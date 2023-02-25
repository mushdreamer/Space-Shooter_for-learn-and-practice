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
    private Image Desk_toshow_lives;//����൱��һ��չʾ�����ǽ���Ƭ�������Ȼ�������չʾ����

    [SerializeField]
    private Sprite[] Lives;//�������Ƭ�ļ���״̬
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
        Desk_toshow_lives.sprite = Lives[health];//��Ӱ����Ƭ��������Ѫ����������ǽ����߽�ϳ���һ�д���
    }
}
