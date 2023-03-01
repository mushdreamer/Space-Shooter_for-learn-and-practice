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
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        
        Enemy_Anim = GetComponent<Animator>();
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
            Destroy(this.gameObject, 2.633f);            
        }
        if (other.tag == "Bullets")
        {
            if(player != null)
            {
                player.addScore(10);//这样子这种enemy的分数就变成10了，如果我们有多种enemy我们就可以分配不同的分数奖励，或是分配不同的资源奖励
            }
            Enemy_Anim.SetTrigger("On_Enemy_Death");
            speed = 0f;
            Destroy(this.gameObject, 2.633f);
        }
    }
}
