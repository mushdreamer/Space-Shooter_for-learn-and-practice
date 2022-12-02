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

        if (transform.position.y < -5.80628f)
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
            Destroy(this.gameObject);
        }
        if (other.tag == "Bullets")
        {
            Destroy(this.gameObject);
        }
    }
}
