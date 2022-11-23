using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float speed = 3.5f;//��һ�������ٶ�
    /*������Ұ����������������ҵ��ƶ��������������������ܰ�������������unity���趨������Ұ��ϼ����Ҽ�ʱ�᷵��1���¼�������᷵��-1����������������������Ұ���
     ������һ�����򸺵��ٶ����������������ƶ�*/
    float getHorizontal;
    float getVertical;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        /* ����
        * Input.GetAxis
        * Returns the value of the virtual axis identified by axisName.����unity������İ�������
        * The value will be in the range -1...1 for keyboard and joystick input devices.ͨ��Input.GetAxis��ʵ�ּ�¼��Ұ�������1��-1�Ĳ���
        * Vector3
        * Representation of 3D vectors and points.�����ƶ�����
        * This structure is used throughout Unity to pass 3D positions and directions around. It also contains functions for doing common vector operations.
        * deltaTime
        * It is done by calling a timer every frame per second that holds the time between now and last call in milliseconds. 
        * Thereafter the resulting number (delta time) is used to calculate how far, for instance, a video game character would have travelled during that time.
        * ��һ����ʱ��������һ��ʱ�����ڼ���������ϷҪ�� 
        * Transform
        * The Transform is used to store a GameObject��s position, rotation, scale and parenting state
          ����Position,Rotation,Scale
        * transform.Translate
          Moves the transform in the direction�ƶ����� */

        /* �ٶȹ�ʽ 1�������ٶȣ�float speed��* ����GetAxis��* ʱ�䣨deltaTime��* λ�ò����������ڼ��㣬����Ҫ��λ�ò�����������������ƶ���Ҫ�õ���*/
        /*        transform.Translate(Vector3.right * Time.deltaTime * speed * getHorizontal);
                transform.Translate(Vector3.up * Time.deltaTime * speed * getVertical);*/
        /*�ٶȹ�ʽ 2����λ�ò������ڲ�������xy��ķ��򷵻�ֵ��* ʱ�� * �����ٶ�*/
        /*transform.Translate(new Vector3(getHorizontal, getVertical, 0) * Time.deltaTime * speed);*/



        /*�ٶȹ�ʽ 3���ڵڶ����ٶȹ�ʽ�Ļ����Ͻ���λ�ò����ĳ�һ���µı���,ʵ���ٶ�=����*ʱ��*�����ٶ�*/
        getHorizontal = Input.GetAxis("Horizontal");
        getVertical = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(getHorizontal, getVertical, 0);

        transform.Translate(direction * speed * Time.deltaTime);

        //��������ƶ���Χ����Ļ��
        /*����
          transform.position
          The position property of a GameObject��s Transform, which is accessible in the Unity Editor and through scripts. 
          Alter this value to move a GameObject. Get this value to locate the GameObject in 3D world space.�����ڵ���λ�ò���*/
        /*if (transform.position.y>=7.82087f)
        {
            transform.position = new Vector3(transform.position.x, 7.82087f, 0);
        }
        else if(transform.position.y<=-7.82087f)
        {
            transform.position = new Vector3(transform.position.x, -7.82087f, 0);
        }
        if (transform.position.x >= 17.20577f)
        {
            transform.position = new Vector3(17.20577f, transform.position.y, 0);
        }
        else if (transform.position.x <= -17.20577f)
        {
            transform.position = new Vector3(-17.20577f, transform.position.y, 0);
        }*/

        /*������Ļ�߼����Ӿ�Ч����ʵ�ʹ�����
          ����������ұ���Ļ��ʱ������Ҵ���߳��֡���֮������������Ļʱ������Ҵ��ұ߳���
          ���������������Ļʱ���������������֣���ֳ�������������Ļʱ������Ҵ��������*/
        if (transform.position.y >= 7.82087f)
        {
            transform.position = new Vector3(transform.position.x, -5.807765f, 0);
        }
        else if (transform.position.y <= -5.80628f)
        {
            transform.position = new Vector3(transform.position.x, 7.8464151f, 0);
        }
        if (transform.position.x >= 17.20577f)
        {
            transform.position = new Vector3(-17.20577f, transform.position.y, 0);
        }
        else if (transform.position.x <= -17.20577f)
        {
            transform.position = new Vector3(17.20577f, transform.position.y, 0);
        }
    }
}
