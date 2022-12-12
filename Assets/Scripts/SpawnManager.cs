using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private bool startSpawnEnemy = true;
    private bool startSpawnTriple = true;
    private bool startSpawnSpeed = true;
    [SerializeField]
    private GameObject enemy;
    [SerializeField]
    private GameObject TripleShot_PowerUp;
    [SerializeField]
    private GameObject SpeedUp_PowerUp;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemy());
        StartCoroutine(spawnTriple());
        StartCoroutine(spawnSpeed());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator spawnEnemy()
    {
        while (startSpawnEnemy == true)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-9.866952f, 10.6117f), 4.716207f, 0);
            Instantiate(enemy, spawnPosition, Quaternion.identity);
            yield return new WaitForSeconds(1.0f);
        }
    }
    IEnumerator spawnTriple()
    {
        while (startSpawnTriple == true)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-9.866952f, 10.6117f), 4.716207f, 0);
            Instantiate(TripleShot_PowerUp, spawnPosition, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(5.001f, 10.0f));
        }
    }
    IEnumerator spawnSpeed()
    {
        while (startSpawnSpeed == true)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-9.866952f, 10.6117f), 4.716207f, 0);
            Instantiate(SpeedUp_PowerUp, spawnPosition, Quaternion.identity);
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

    public void nomoreTriple()
    {
        startSpawnTriple = false;
    }
    
    public void nomoreSpeed()
    {
        startSpawnSpeed = false;
    }
}
