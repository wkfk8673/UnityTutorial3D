using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 5f;
    private Vector3 dir;

    public GameObject particleFactory;

    private void OnEnable()
    {
        int ranValue = UnityEngine.Random.Range(0, 10);
        if (ranValue < 7) // 70%
        {
            GameObject target = GameObject.Find("Player");
            dir = target.transform.position - transform.position;
            dir.Normalize();
        }
        else
        {
            dir = Vector3.down;
        }
    }
    private void Update()
    {
        transform.position += dir * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision other)
    {

        /*
        GameObject smObject = GameObject.Find("ScoreManager");
        ScoreManager sm = smObject.GetComponent<ScoreManager>();

        var score = sm.GetScore() + 1;
        sm.SetScore(score);

        */

        // 싱글톤 기반 접근
        // ScoreManager.Instance.SetScore(ScoreManager.Instance.GetScore() + 1);

        // 싱글톤 + 프로퍼티
        ScoreManager.Instance.Score++;

        GameObject exlposion = Instantiate(particleFactory);
        exlposion.transform.position = transform.position;

        if (other.gameObject.name.Contains("Bullet"))
        {
            //PlayerFire player = GameObject.Find("Player").GetComponent<PlayerFire>();
            other.gameObject.SetActive(false);
            PlayerFire.Instance.bulletObjectPool.Enqueue(other.gameObject); // Awake 에서 사용하면 안됨

            //other.gameObject.SetActive(false);
        }
        else
        {
            Destroy(other.gameObject); // 플레이어
        }
        EnemyManager.Instance.enemyObjectPool.Enqueue(gameObject);
        gameObject.SetActive(false);
    }
}
