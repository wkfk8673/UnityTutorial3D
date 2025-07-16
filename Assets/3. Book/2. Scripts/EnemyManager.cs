using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private float currentTime;


    private float minTime = 1; //积己 林扁
    private float maxTime = 5; //积己 林扁
    private float createTime = 1f; //积己 林扁

    public GameObject enemyFactory;

    private void Start()
    {
        createTime = Random.Range(minTime, maxTime);
    }

    private void Update()
    {
        currentTime += Time.deltaTime;

        if(currentTime > createTime)
        {
            GameObject enemy = Instantiate(enemyFactory);
            enemy.transform.position = transform.position;

            //鸥捞赣 檬扁拳
            currentTime = 0f;
        }
    }
}
