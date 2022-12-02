using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private bool startSpawn = true;
    [SerializeField]
    private GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator spawn()
    {
        while (startSpawn == true)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-15.5f, 15.5f), 7.8464151f, 0);
            Instantiate(enemy, spawnPosition, Quaternion.identity);
            yield return new WaitForSeconds(1);
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
        startSpawn= false;
    }
}
