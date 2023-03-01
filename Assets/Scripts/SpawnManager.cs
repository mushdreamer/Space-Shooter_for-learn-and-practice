using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private bool startSpawnEnemy = true;
    private bool startSpawnPowerUp = true;
    [SerializeField]
    private GameObject enemy;
    [SerializeField]
    private GameObject[] PowerUp;
    [SerializeField]
    private bool find_Asteroid;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemy());
        StartCoroutine(spawnPowerUp());
        find_Asteroid = GameObject.Find("Asteroid").GetComponent<Asteroid>();

    }

    // Update is called once per frame
    void Update()
    {
/*        find_Asteroid = if_Asteroid_Alive;*/
    }
    IEnumerator spawnEnemy()
    {
        while (startSpawnEnemy == true && find_Asteroid == false)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-9.866952f, 10.6117f), 7.0f, 0);
            Instantiate(enemy, spawnPosition, Quaternion.identity);
            yield return new WaitForSeconds(1.0f);
        }
    }
    IEnumerator spawnPowerUp()
    {
        while (startSpawnPowerUp == true)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-9.866952f, 10.6117f), 4.716207f, 0);
            /*概念
              Random.range包括左边的数但是不包括右边的数字
              也就是说，Random.Range(0,3)是0，1，2*/
            int SpawnNumber = Random.Range(0, 3);
            Instantiate(PowerUp[SpawnNumber], spawnPosition, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(5.001f, 10.0f));
        }
    }
    /*在玩家死亡后停止生成敌人
      首先敌人生成的逻辑是startSpawn为true时一直生成，而默认startSpawn为true
      我们引入一个函数nomoreEnemy，使得在一旦调用这个函数startSpawn就会变成false从而禁用spawn函数从而停止生成敌人
      逻辑是玩家死亡时会调用nomoreEnemy函数，因此要让这个函数被玩家死亡playerDeath调用，而playerDeath函数理所当然写在player文件里，因此要在player文件里access SpawnManager文件才能调用
      因此我们需要在player文件里创建一个variable使其能够找到SpawnManager文件
      写法：
      private SpawnManager（文件名） spawnManager（variable名）
      spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>()*/
    public void nomoreEnemy()
    {
        startSpawnEnemy = false;
    }

    public void nomorePowerUp()
    {
        startSpawnPowerUp = false;
    }

/*到底行不行啊！！*/
}
