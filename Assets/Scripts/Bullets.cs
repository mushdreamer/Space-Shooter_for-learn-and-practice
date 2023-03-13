using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    private float Speed = 7.0f;

    private bool isEnemyBullets = false;

    // Update is called once per frame
    void Update()
    {
        if (isEnemyBullets == false)
        {
            MoveUp();
        }
        else
        {
            MoveDown();
        }
    }
    private void MoveUp()
    {
        transform.Translate(Vector3.up * Speed * Time.deltaTime);
        /*概念
          Destroy
          Removes a GameObject, component or asset.使一个GameObject在unity中消失
          this.gameObject
          this特指这个script中的game object也就是bullets*/
        if (transform.position.y > 7.7f)
        {

            /*概念
              Parent
              Parent是一个Gameobject的概念，任何Gameobject都可以成为其它Gameobject的Parent或Child，他们之间的关系就像身体，胳膊，以及手一样，身体就像是胳膊的
              Parent，而胳膊是身体的Child同时也是手的Parent，而手是胳膊的Child。具有这种关系的Gameobject互相继承特性，想要查询Gameobject的relationship只需要
              在unity中的prefab中点击一个Gameobject然后open即可看到Hierarchy，Child会被Parent折叠起来
              当TripleShot移动的时候，根据定义它的Child Bullet也会移动，因此我们在Bullet超过7.7f时检测这个Bullet是否有Parent，如果有的话直接destroy*/
            if (transform.parent != null)
            {
                Destroy(transform.parent.gameObject);
            }
            Destroy(this.gameObject);
        }
    }
    private void MoveDown()
    {
        transform.Translate(Vector3.down * Speed * Time.deltaTime);
        /*概念
          Destroy
          Removes a GameObject, component or asset.使一个GameObject在unity中消失
          this.gameObject
          this特指这个script中的game object也就是bullets*/
        if (transform.position.y > 7.7f)
        {

            /*概念
              Parent
              Parent是一个Gameobject的概念，任何Gameobject都可以成为其它Gameobject的Parent或Child，他们之间的关系就像身体，胳膊，以及手一样，身体就像是胳膊的
              Parent，而胳膊是身体的Child同时也是手的Parent，而手是胳膊的Child。具有这种关系的Gameobject互相继承特性，想要查询Gameobject的relationship只需要
              在unity中的prefab中点击一个Gameobject然后open即可看到Hierarchy，Child会被Parent折叠起来
              当TripleShot移动的时候，根据定义它的Child Bullet也会移动，因此我们在Bullet超过7.7f时检测这个Bullet是否有Parent，如果有的话直接destroy*/
            if (transform.parent != null)
            {
                Destroy(transform.parent.gameObject);
            }
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            Destroy(this.gameObject);
            /*Destroy(other.gameObject);*/
        }
    }
    public void PlayerBullets()
    {
        isEnemyBullets = true;
    }
}
