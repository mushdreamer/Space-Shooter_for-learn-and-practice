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
            /*����
              Random.range������ߵ������ǲ������ұߵ�����
              Ҳ����˵��Random.Range(0,3)��0��1��2*/
            int SpawnNumber = Random.Range(0, 3);
            Instantiate(PowerUp[SpawnNumber], spawnPosition, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(5.001f, 10.0f));
        }
    }
    /*�����������ֹͣ���ɵ���
      ���ȵ������ɵ��߼���startSpawnΪtrueʱһֱ���ɣ���Ĭ��startSpawnΪtrue
      ��������һ������nomoreEnemy��ʹ����һ�������������startSpawn�ͻ���false�Ӷ�����spawn�����Ӷ�ֹͣ���ɵ���
      �߼����������ʱ�����nomoreEnemy���������Ҫ������������������playerDeath���ã���playerDeath����������Ȼд��player�ļ�����Ҫ��player�ļ���access SpawnManager�ļ����ܵ���
      ���������Ҫ��player�ļ��ﴴ��һ��variableʹ���ܹ��ҵ�SpawnManager�ļ�
      д����
      private SpawnManager���ļ����� spawnManager��variable����
      spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>()*/
    public void nomoreEnemy()
    {
        startSpawnEnemy = false;
    }

    public void nomorePowerUp()
    {
        startSpawnPowerUp = false;
    }

/*�����в��а�����*/
}
