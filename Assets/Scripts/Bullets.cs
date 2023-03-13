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
        /*����
          Destroy
          Removes a GameObject, component or asset.ʹһ��GameObject��unity����ʧ
          this.gameObject
          this��ָ���script�е�game objectҲ����bullets*/
        if (transform.position.y > 7.7f)
        {

            /*����
              Parent
              Parent��һ��Gameobject�ĸ���κ�Gameobject�����Գ�Ϊ����Gameobject��Parent��Child������֮��Ĺ�ϵ�������壬�첲���Լ���һ������������Ǹ첲��
              Parent�����첲�������ChildͬʱҲ���ֵ�Parent�������Ǹ첲��Child���������ֹ�ϵ��Gameobject����̳����ԣ���Ҫ��ѯGameobject��relationshipֻ��Ҫ
              ��unity�е�prefab�е��һ��GameobjectȻ��open���ɿ���Hierarchy��Child�ᱻParent�۵�����
              ��TripleShot�ƶ���ʱ�򣬸��ݶ�������Child BulletҲ���ƶ������������Bullet����7.7fʱ������Bullet�Ƿ���Parent������еĻ�ֱ��destroy*/
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
        /*����
          Destroy
          Removes a GameObject, component or asset.ʹһ��GameObject��unity����ʧ
          this.gameObject
          this��ָ���script�е�game objectҲ����bullets*/
        if (transform.position.y > 7.7f)
        {

            /*����
              Parent
              Parent��һ��Gameobject�ĸ���κ�Gameobject�����Գ�Ϊ����Gameobject��Parent��Child������֮��Ĺ�ϵ�������壬�첲���Լ���һ������������Ǹ첲��
              Parent�����첲�������ChildͬʱҲ���ֵ�Parent�������Ǹ첲��Child���������ֹ�ϵ��Gameobject����̳����ԣ���Ҫ��ѯGameobject��relationshipֻ��Ҫ
              ��unity�е�prefab�е��һ��GameobjectȻ��open���ɿ���Hierarchy��Child�ᱻParent�۵�����
              ��TripleShot�ƶ���ʱ�򣬸��ݶ�������Child BulletҲ���ƶ������������Bullet����7.7fʱ������Bullet�Ƿ���Parent������еĻ�ֱ��destroy*/
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
