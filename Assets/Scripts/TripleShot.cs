using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TripleShot : MonoBehaviour
{
    [SerializeField]
    private float speed = 3.0f;
    private Player TripleShotReady;
    private Player SpeedUpReady;
    private Player ShieldReady;
    [SerializeField]
    private int PowerUpID;

    void Start()
    {
        TripleShotReady = GameObject.Find("Player").GetComponent<Player>();
        SpeedUpReady = GameObject.Find("Player").GetComponent<Player>();
        ShieldReady = GameObject.Find("Player").GetComponent<Player>();
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            /*概念
              Switch(choose)
              {
                 case 0;当choose等于0时
                 break;
                 case 1;当choose等于1时
                 break;
                 case 2;当choose等于2时
                 break;
            }*/
            switch (PowerUpID)
            {
                case 0:
                    TripleShotReady.tripleshotReady();
                    Destroy(this.gameObject);
                    break;
                case 1:
                    SpeedUpReady.speedupReady();
                    Destroy(this.gameObject);
                    break;
                case 2:
                    ShieldReady.shieldReady();
                    Destroy(this.gameObject);
                    break;
            }
        }
    }
}
