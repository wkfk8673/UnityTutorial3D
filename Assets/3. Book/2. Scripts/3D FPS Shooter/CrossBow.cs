using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class CrossBow : MonoBehaviour
{
    /// 화살 발사 기능
    /// 화살
    /// 발사 타겟 위치
    /// 화살 이동

    public GameObject arrowPrefab;
    public Transform shootPos;
    public bool isShoot;

    private void Update()
    { 

        Ray ray = new Ray(shootPos.position, shootPos.forward);
        RaycastHit hit; // 레이저 닿은 대상

        bool isTargeting =  Physics.Raycast(ray,out hit);
        Debug.DrawRay(shootPos.position, shootPos.forward, Color.green);

        if (isTargeting && !isShoot)
        {
            StartCoroutine(ShootRoutine());
        }
    }

    IEnumerator ShootRoutine()
    {
        isShoot = true;

        GameObject arrow = Instantiate(arrowPrefab, transform);
        Quaternion rot = Quaternion.Euler(new Vector3(90, 0, 0));
        arrow.transform.SetPositionAndRotation(shootPos.position, rot);

        yield return new WaitForSeconds(3f);
        isShoot = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(shootPos.position, shootPos.forward);
    }

    /// 타인 감지
    /// 직선 감지
    /// 감지 시 화살 생성
    /// 생성한 화살 이동
}
