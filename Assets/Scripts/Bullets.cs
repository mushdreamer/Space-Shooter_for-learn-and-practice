using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    private float Speed = 7.0f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * Speed * Time.deltaTime);
        /*概念
          Destroy
          Removes a GameObject, component or asset.使一个GameObject在unity中消失
          this.gameObject
          this特指这个script中的game object也就是bullets*/
        if (transform.position.y > 7.7f)
        {
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
}
