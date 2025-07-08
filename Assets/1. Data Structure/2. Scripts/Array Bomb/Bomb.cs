using System.Collections;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    /// 폭탄이 터지는 순간
    /// 본인 주변으로 대상을 감지 (physics)
    /// 해당 대상에 포함된 애들을 ray에 포함 시킴
    /// 이후 해당 오브젝트 대상으로 사방으로 힘을 가함

    private Rigidbody bombRb;
    public float bombTime = 4f;
    public float bombRange = 10f;
    public LayerMask layerMask;
    private void Awake()
    {
        bombRb = GetComponent<Rigidbody>();
    }

    // 원하는 타이밍에 폭파 효과
    IEnumerator Start()
    {
        yield return new WaitForSeconds(bombTime);
        BombForce();
    }

    private void BombForce()
    {
        // 본인을 덮는 거대한 구체를 생성, 레이어 처리해서 바닥을 제외
        Collider[] coliders = Physics.OverlapSphere(transform.position, bombRange, layerMask); 

        foreach(var col in coliders)
        {
            Rigidbody rb = col.GetComponent<Rigidbody>();

            //AddExplosionForce(폭발 파워, 위치, 범위, 높이)
            rb.AddExplosionForce(500f, transform.position, bombRange, 1f);
        }

        Destroy(gameObject);
    }
}
