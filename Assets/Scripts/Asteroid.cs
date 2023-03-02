using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{

    [SerializeField]
    private float rotate_speed = 5.0f;

    [SerializeField]
    private Animator Asteroid_Anim;

    [SerializeField]
    private SpawnManager SpawnEnemy;
    // Start is called before the first frame update
    void Start()
    {
        Asteroid_Anim = GetComponent<Animator>();
        SpawnEnemy = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(transform.forward * rotate_speed * Time.deltaTime);
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Bullets")
        {
            Asteroid_Anim.SetTrigger("Asteroid_Explosion");
            Destroy(this.gameObject, 2.633f);
            SpawnEnemy.startSpawning();
        }
        if (other.tag == "Player")
        {
            Asteroid_Anim.SetTrigger("Asteroid_Explosion");
            Destroy(this.gameObject, 2.633f);
            SpawnEnemy.startSpawning();
        }
    }
}
