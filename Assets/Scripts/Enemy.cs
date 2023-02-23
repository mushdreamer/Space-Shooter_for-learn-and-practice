using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float speed = 2.0f;

    private Player player;
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        if (transform.position.y < -4.296614f)
        {
            Destroy(this.gameObject);
        }

    }

    /*����
      OnTriggerEnter
      ����trigger collider��otherָ���ǳ���Script�Ķ���������ָ����Enemy��������������Enemy����д�ģ�
      ����������ڸ�Enemy����collider���������Enemy��ײʱ������ܵ��˺���Ѫ����(��д��Player����)ͬʱEnemy��ʧ
      ���ӵ���Enemy��ײʱ���ӵ���ʧ����д��Bullets���棩ͬʱEnemy��ʧ*/
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Destroy(this.gameObject);
        }
        if (other.tag == "Bullets")
        {
            if(player != null)
            {
                player.addScore(10);//����������enemy�ķ����ͱ��10�ˣ���������ж���enemy���ǾͿ��Է��䲻ͬ�ķ������������Ƿ��䲻ͬ����Դ����
            }
            Destroy(this.gameObject);
        }
    }
}
