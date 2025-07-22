using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : Singleton<PlayerFire>
{
    public GameObject bulletFactory;
    public GameObject firePosition;

    public int poolSize = 10;
    //public GameObject[] bulletObjectPool;
    //public List<GameObject> bulletObjectPool;
    public Queue<GameObject> bulletObjectPool;

    private void Start()
    {
        //bulletObjectPool = new GameObject[poolSize];
        bulletObjectPool = new Queue<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject bullet = Instantiate(bulletFactory);
            //bulletObjectPool[i] = bullet;
            //bulletObjectPool.Add(bullet);
            bulletObjectPool.Enqueue(bullet);
            bullet.SetActive(false); // 아직 사용 전이므로 풀에 넣을 때는 보통 꺼둠
        }
    }

    private void Update()
    {
#if UNITY_STANDARDALONE
        if (Input.GetButtonDown("Fire1"))
        {
            if(bulletObjectPool.Count > 0)
            {
                GameObject bullet = bulletObjectPool.Dequeue();
                bullet.SetActive(true);
                bullet.transform.position = firePosition.transform.position;
            }
            /* 리스트 방식
            if (bulletObjectPool.Count > 0)
            {
                GameObject bullet = bulletObjectPool[0];
                bullet.SetActive(true);

                bulletObjectPool.Remove(bullet); // Pool 에서 오브젝트 제거
                bullet.transform.position = firePosition.transform.position;
            }
            */
        }
#endif
    }
}
