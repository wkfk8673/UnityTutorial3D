using UnityEngine;

public class BombAction : MonoBehaviour
{
    public GameObject bombEffect;
    public int attackPower = 20;
    public float explosionRadius = 5f;

    private void OnCollisionEnter(Collision collision)
    {
        Collider[] cols = Physics.OverlapSphere(transform.position, explosionRadius, 1 << 9); // 1 << 10 : 시프트 연산, 10번 레이어 비트 1로 변경하겠다;

        Debug.Log(cols.Length);

        for(int i=0; i < cols.Length; i++)
        {
            cols[i].GetComponent<EnemyFSM>().HitEnemy(attackPower);
        }

        GameObject effect = Instantiate(bombEffect);
        effect.transform.position = transform.position;

        Destroy(gameObject);
    }
}
