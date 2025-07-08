using System.Collections;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    /// ��ź�� ������ ����
    /// ���� �ֺ����� ����� ���� (physics)
    /// �ش� ��� ���Ե� �ֵ��� ray�� ���� ��Ŵ
    /// ���� �ش� ������Ʈ ������� ������� ���� ����

    private Rigidbody bombRb;
    public float bombTime = 4f;
    public float bombRange = 10f;
    public LayerMask layerMask;
    private void Awake()
    {
        bombRb = GetComponent<Rigidbody>();
    }

    // ���ϴ� Ÿ�ֿ̹� ���� ȿ��
    IEnumerator Start()
    {
        yield return new WaitForSeconds(bombTime);
        BombForce();
    }

    private void BombForce()
    {
        // ������ ���� �Ŵ��� ��ü�� ����, ���̾� ó���ؼ� �ٴ��� ����
        Collider[] coliders = Physics.OverlapSphere(transform.position, bombRange, layerMask); 

        foreach(var col in coliders)
        {
            Rigidbody rb = col.GetComponent<Rigidbody>();

            //AddExplosionForce(���� �Ŀ�, ��ġ, ����, ����)
            rb.AddExplosionForce(500f, transform.position, bombRange, 1f);
        }

        Destroy(gameObject);
    }
}
