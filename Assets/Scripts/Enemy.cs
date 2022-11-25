using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float speed = 6.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        if(transform.position.y < -5.80628f)
        {
            float randomX = Random.Range(-15.5f, 15.5f);
            transform.position = new Vector3(randomX, 7.8464151f, 0);
        }
    }

    /*����
      OnTriggerEnter
      ����trigger collider��otherָ���ǳ���Script�Ķ���������ָ����Enemy��������������Enemy����д�ģ�
      ����������ڸ�Enemy����collider���������Enemy��ײʱ������ܵ��˺���Ѫ����(��д��Player����)ͬʱEnemy��ʧ
      ���ӵ���Enemy��ײʱ���ӵ���ʧ����д��Bullets���棩ͬʱEnemy��ʧ*/
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(this.gameObject);
        }
        if (other.tag == "Bullets")
        {
            Destroy(this.gameObject);
        }
    }
}
