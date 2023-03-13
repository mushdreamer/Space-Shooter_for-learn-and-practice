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
    //让开枪状态为-1，而游戏开始时时长为0，根据if条件如果游戏时长大于开枪状态那么就可以发射一颗子弹，一开始0>1因此可以开枪，之后开枪间隔为3和7之间的任意数，我们
    //让开枪状态等于当前的游戏时长加上开枪间隔，假设此时游戏市场为20秒，开枪时长为4秒，那么开枪状态就等于24秒，也就是说游戏时长20秒小于开枪状态24秒，那么要等24
    //秒时才可以开枪，从而实现了4秒的开枪冷却
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
            GameObject EnemyBullets = Instantiate(Enemy_Bullets, transform.position, Quaternion.identity);/*我们在原有的子弹基础上，又创建了一个新的具有子弹性质的敌人子弹*/
            Bullets[] bullets = EnemyBullets.GetComponentsInChildren<Bullets>();/*然后将每一个生成的敌人子弹都存储在一个Array里*/
            for (int i = 0; i < bullets.Length; i++)
            {
                bullets[i].PlayerBullets();
            }/*遍历这个Array一一赋予他们性质,这样我们就可以在不影响其他子弹的前提下，控制敌人子弹的行为和属性。*/
        }
    }

    /*概念
      OnTriggerEnter
      用于trigger collider，other指的是除了Script的对象（在这里指的是Enemy，因此这个函数在Enemy里面写的）
      这个函数用于给Enemy创建collider，当玩家与Enemy碰撞时，玩家受到伤害掉血死亡(将写在Player里面)同时Enemy消失
      当子弹与Enemy碰撞时，子弹消失（将写在Bullets里面）同时Enemy消失*/
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
                player.addScore(10);//这样子这种enemy的分数就变成10了，如果我们有多种enemy我们就可以分配不同的分数奖励，或是分配不同的资源奖励
            }
            Enemy_Anim.SetTrigger("On_Enemy_Death");
            speed = 0f;
            Destroy(GetComponent<Collider2D>());
            Enemy_Destroy_Source.Play();
            Destroy(this.gameObject, 2.633f);
        }
    }
}
