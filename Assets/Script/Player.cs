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
         �ٶȹ�ʽ�������ٶȣ�float speed��*����GetAxis��*ʱ�䣨deltaTime��*λ�ò����������ڼ��㣬����Ҫ��λ�ò�����������������ƶ���Ҫ�õ���*/
        getHorizontal = Input.GetAxis("Horizontal");
        getVertical = Input.GetAxis("Vertical");
        transform.Translate(Vector3.right * Time.deltaTime * speed * getHorizontal);
        transform.Translate(Vector3.up * Time.deltaTime * speed * getVertical);
    }
}
