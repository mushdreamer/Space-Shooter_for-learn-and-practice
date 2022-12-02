using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float speed = 10.0f;//��һ�������ٶ�
    /*����������Ҫ���������ӵ�����ȴʱ�䣬�����ӵ����������Ϊ�����Player�ļ�����б༭��Bullets�������ӵ������ʵ��Ƿ����ӵ��������Ϊ��˲���Bullets�༭��
      ����fireRate�Ƿ���һ���ӵ�����ȴʱ�䣬���ǹ涨����һö�ӵ���0.5���ſ��Է�����һ���ӵ�
      ����
      Time.time
      The time at the beginning of this frame (Read Only).������Ϸһ�������˶��
      ��ȴʱ����߼�������������Ϸ�ܹ���ʱ��������һ����ȴϵͳ
      ����ͨ����ÿһ�ε���ȴʱ�䶼������Ϸ���е�ʱ���γɡ��µ���ȴʱ�䡱
      �á��µ���ȴʱ�䡱-����Ϸ���е�ʱ�䡱=0.5ʵ����Ϸʱ�������ӵ�����ȴ����0.5
      ���������Ҫ����һ���µı���canFire����ǹ״̬������¼������µ���ȴʱ�䡱
      ����Ϸ���е�ʱ�䡱���ڡ��µ���ȴʱ�䡱�͵ȼ��ڡ���Ϸ���е�ʱ�䡱-���µ���ȴʱ�䡱>0�͵ȼ�����Ϸʱ��-����Ϸʱ��+��ȴʱ�䣩>0�͵ȼ�����ȴʱ��<0�͵ȼ���û����ȴʱ������ǿ��Կ�ǹ��*/
    private float fireRate = 0.3f;//������ȴʱ��
    private float canFire;//�������µ���ȴʱ�䡱
    /*������Ұ����������������ҵ��ƶ��������������������ܰ�������������unity���趨������Ұ��ϼ����Ҽ�ʱ�᷵��1���¼�������᷵��-1����������������������Ұ���
     ������һ�����򸺵��ٶ����������������ƶ�*/
    float getHorizontal;/*����������*/
    float getVertical;/*����������*/
    private SpawnManager spawnManager;//��player���涨��һ��variableʹ���ܹ�ֱ��������Spawn Manager�ļ���
    /*����
      [SerializeField]
      ʹ��ʱ��ԭ�Ȳ���ʾ��inspector����unity�б༭GameObject�����Ե���壩�����private��������ʾ����*/
    [SerializeField]
    /*ʹ��private����bullets�Ͳ��ᱻ���������滻�������Ҳû��Ȩ�޷���bullets�����ԣ����Ӱ�ȫ*/
    /*��Player�������GameObject�ܹ������Ƕ���õ�Bullets�ϵ�Unity��Script�����������bullets GameObject��ʵ��GameObject bullets�ȼ���Unity Bullets*/
    private GameObject bullets;
    [SerializeField]
    private int health = 3;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);

        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();//����spawnManager���variable���ܹ�����SpawnManager�ļ�����ĺ�����
    }

    // Update is called once per frameÿ�붼Ҫ����״̬��д��update��
    void Update()
    {
        /*ÿ�붼Ҫ�ƶ����д������*/
        playerMovement();
        /*�����ÿһ�붼Ҫ��������ȴϵͳ���д������*/
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > canFire)
        {
            playerShoot();
        }
        playerDeath();
    }

    void playerMovement()
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
        getHorizontal = Input.GetAxis("Horizontal");/*������ļ�λ��ȡ*/
        getVertical = Input.GetAxis("Vertical");/*������ļ�λ��ȡ*/

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
    void playerShoot()
    {
            canFire = Time.time + fireRate;
            Instantiate(bullets, transform.position + new Vector3(0, 0.8f, 0), Quaternion.identity);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            health -= 1;
        }
    }
    void playerDeath()
    {
        if(health < 1)
        {
            spawnManager.nomoreEnemy();
            Destroy(this.gameObject);
        }
    }
}
