using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 5f;
    private Vector3 dir;

    public GameObject particleFactory;

    private void Start()
    {
        int ranValue = UnityEngine.Random.Range(0, 10);
        if (ranValue < 3) // 30%
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


        GameObject smObject = GameObject.Find("ScoreManager");
        ScoreManager sm = smObject.GetComponent<ScoreManager>();

        var score = sm.GetScore() + 1;
        sm.SetScore(score);

        
        GameObject exlposion = Instantiate(particleFactory);
        exlposion.transform.position = transform.position;
        
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
