using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : Singleton<EnemyManager>
{
    public int poolSize = 10;

    //public GameObject[] enemyObjectPool;
    //public List<GameObject> enemyObjectPool;
    public Queue<GameObject> enemyObjectPool;

    public Transform[] spawnPoints;

    public GameObject enemyFactory;

    private float currentTime;
    private float minTime = 1; //积己 林扁
    private float maxTime = 5; //积己 林扁
    private float createTime = 1f; //积己 林扁


    private void Start()
    {
        enemyObjectPool = new Queue<GameObject>();

        createTime = Random.Range(minTime, maxTime);

        for (int i = 0; i < poolSize; i++)
        {
            GameObject enemy = Instantiate(enemyFactory);

            enemyObjectPool.Enqueue(enemy);
            //enemyObjectPool[i] = enemy;
            enemy.SetActive(false);
        }
    }

    private void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime > createTime)
        {
            if (enemyObjectPool.Count > 0)
            {
                currentTime = 0;
                createTime = Random.Range(minTime, maxTime);

                GameObject enemy = enemyObjectPool.Dequeue();
                if (!enemy.activeSelf)
                {
                    int ranIndex = Random.Range(0, spawnPoints.Length);
                    Transform spawnPoint = spawnPoints[ranIndex];

                    enemy.transform.position = spawnPoint.position;
                    enemy.SetActive(true);

                }
            }
        }
    }
}
