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
    [SerializeField]
    private int PowerUpID;
    // Start is called before the first frame update
    void Start()
    {
        TripleShotReady = GameObject.Find("Player").GetComponent<Player>();
        SpeedUpReady = GameObject.Find("Player").GetComponent<Player>();
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
                    break;
            }
        }
    }
}
