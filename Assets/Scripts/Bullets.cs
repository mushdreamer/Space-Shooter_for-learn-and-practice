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
        /*����
          Destroy
          Removes a GameObject, component or asset.ʹһ��GameObject��unity����ʧ
          this.gameObject
          this��ָ���script�е�game objectҲ����bullets*/
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
