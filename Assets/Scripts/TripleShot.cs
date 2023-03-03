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
    [SerializeField]
    private AudioClip PowerUp;
    [SerializeField]
    private AudioSource PowerUpSource;
    // Start is called before the first frame update
    void Start()
    {
        TripleShotReady = GameObject.Find("Player").GetComponent<Player>();
        SpeedUpReady = GameObject.Find("Player").GetComponent<Player>();
        ShieldReady = GameObject.Find("Player").GetComponent<Player>();
        PowerUpSource = GetComponent<AudioSource>();
        PowerUpSource.clip = PowerUp;
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
            /*����
              Switch(choose)
              {
                 case 0;��choose����0ʱ
                 break;
                 case 1;��choose����1ʱ
                 break;
                 case 2;��choose����2ʱ
                 break;
            }*/
            switch (PowerUpID)
            {
                case 0:
                    TripleShotReady.tripleshotReady();
                    PowerUpSource.Play();
                    Destroy(this.gameObject);
                    break;
                case 1:
                    SpeedUpReady.speedupReady();
                    PowerUpSource.Play();
                    Destroy(this.gameObject);
                    break;
                case 2:
                    ShieldReady.shieldReady();
                    PowerUpSource.Play();
                    Destroy(this.gameObject);
                    break;
            }
        }
    }
}
