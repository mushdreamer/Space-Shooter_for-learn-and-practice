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
}
