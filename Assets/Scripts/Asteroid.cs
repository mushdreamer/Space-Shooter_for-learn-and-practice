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

    [SerializeField]
    private AudioClip Asteroid_Destroy;
    [SerializeField]
    private AudioSource Asteroid_Destroy_Source;
    // Start is called before the first frame update
    void Start()
    {
        Asteroid_Anim = GetComponent<Animator>();
        SpawnEnemy = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        Asteroid_Destroy_Source = GetComponent<AudioSource>();
        Asteroid_Destroy_Source.clip = Asteroid_Destroy;
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
            Destroy(GetComponent<Collider2D>());//消除碰撞体积这样在2.633秒内就不能再次攻击或被这个gameobject攻击了
            Destroy(this.gameObject, 2.633f);
            Asteroid_Destroy_Source.Play();
            SpawnEnemy.startSpawning();
        }
        if (other.tag == "Player")
        {
            Asteroid_Anim.SetTrigger("Asteroid_Explosion");
            Destroy(GetComponent<Collider2D>());
            Destroy(this.gameObject, 2.633f);
            Asteroid_Destroy_Source.Play();
            SpawnEnemy.startSpawning();
        }
    }
}
