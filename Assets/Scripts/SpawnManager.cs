using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private bool startSpawnEnemy = true;
    private bool startSpawnTriple = true;
    [SerializeField]
    private GameObject enemy;
    [SerializeField]
    private GameObject TripleShot_PowerUp;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemy());
        StartCoroutine(spawnTriple());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator spawnEnemy()
    {
        while (startSpawnEnemy == true)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-15.5f, 15.5f), 7.8464151f, 0);
            Instantiate(enemy, spawnPosition, Quaternion.identity);
            yield return new WaitForSeconds(0.6f);
        }
    }
    IEnumerator spawnTriple()
    {
        while (startSpawnTriple == true)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-15.5f, 15.5f), 7.8464151f, 0);
            Instantiate(TripleShot_PowerUp, spawnPosition, Quaternion.identity);
            yield return new WaitForSeconds(10);
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
}
