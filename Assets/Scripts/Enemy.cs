using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float speed = 2.0f;

    private Animator Enemy_Anim;

    private Player player;

    private float canFire = -1;

    private float fireRate;

    [SerializeField]
    private AudioClip Enemy_Destroy;
    [SerializeField]
    private AudioSource Enemy_Destroy_Source;
    [SerializeField]
    private GameObject Enemy_Bullets;
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        Enemy_Destroy_Source = GetComponent<AudioSource>();
        Enemy_Destroy_Source.clip = Enemy_Destroy;

        Enemy_Anim = GetComponent<Animator>();
}

    // Update is called once per frame
    void Update()
    {
        calculateMovemnt();
        calculateBullets();

    }
    public void calculateMovemnt()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        if (transform.position.y < -4.296614f)
        {
            Destroy(this.gameObject);
        }
    }
    //�ÿ�ǹ״̬Ϊ-1������Ϸ��ʼʱʱ��Ϊ0������if���������Ϸʱ�����ڿ�ǹ״̬��ô�Ϳ��Է���һ���ӵ���һ��ʼ0>1��˿��Կ�ǹ��֮��ǹ���Ϊ3��7֮���������������
    //�ÿ�ǹ״̬���ڵ�ǰ����Ϸʱ�����Ͽ�ǹ����������ʱ��Ϸ�г�Ϊ20�룬��ǹʱ��Ϊ4�룬��ô��ǹ״̬�͵���24�룬Ҳ����˵��Ϸʱ��20��С�ڿ�ǹ״̬24�룬��ôҪ��24
    //��ʱ�ſ��Կ�ǹ���Ӷ�ʵ����4��Ŀ�ǹ��ȴ
    public void calculateBullets()
    {
        if(Time.time >= canFire)
        {
            fireRate = UnityEngine.Random.Range(3f, 7f);
            canFire = Time.time + fireRate;
            /*let's say you are creating a game where the player has to shoot down enemy spaceships. When an enemy spaceship is destroyed,
            it needs to release bullets that will fly in different directions. In this case, you would have a prefab for the enemy spaceship
            and a separate prefab for its bullets.

            To create the enemy bullets, you would use the Instantiate() function to create a new instance of the enemy bullet prefab at the
            current position of the enemy spaceship. The line of code GameObject EnemyBullets = Instantiate(Enemy_Bullets,transform.position,
            Quaternion.identity); does exactly this.

            After creating the enemy bullet object, you would then use the GetComponentsInChildren<Bullets>() function to get an array of all
            the child objects that have the "Bullets" component attached. This is useful because the enemy bullet object may have multiple
            child objects, each of which will need to perform some action.

            Finally, the for loop is used to loop through each child object that has the "Bullets" component and call the PlayerBullets()
            function on each of them. This function could be used to set the initial velocity of the bullets, give them a random direction
            to fly in, or any other behavior that you want the bullets to have.*/
            GameObject EnemyBullets = Instantiate(Enemy_Bullets, transform.position, Quaternion.identity);/*������ԭ�е��ӵ������ϣ��ִ�����һ���µľ����ӵ����ʵĵ����ӵ�*/
            Bullets[] bullets = EnemyBullets.GetComponentsInChildren<Bullets>();/*Ȼ��ÿһ�����ɵĵ����ӵ����洢��һ��Array��*/
            for (int i = 0; i < bullets.Length; i++)
            {
                bullets[i].PlayerBullets();
            }/*�������Arrayһһ������������,�������ǾͿ����ڲ�Ӱ�������ӵ���ǰ���£����Ƶ����ӵ�����Ϊ�����ԡ�*/
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
            Enemy_Anim.SetTrigger("On_Enemy_Death");
            speed = 0f;
            Enemy_Destroy_Source.Play();
            Destroy(GetComponent<Collider2D>());
            Destroy(this.gameObject, 2.633f);            
        }
        if (other.tag == "Bullets" && other.GetComponent<Bullets>().isEnemyBullets == false)
        {
            if(player != null)
            {
                player.addScore(10);//����������enemy�ķ����ͱ��10�ˣ���������ж���enemy���ǾͿ��Է��䲻ͬ�ķ������������Ƿ��䲻ͬ����Դ����
            }
            Enemy_Anim.SetTrigger("On_Enemy_Death");
            speed = 0f;
            Destroy(GetComponent<Collider2D>());
            Enemy_Destroy_Source.Play();
            Destroy(this.gameObject, 2.633f);
        }
    }
}
