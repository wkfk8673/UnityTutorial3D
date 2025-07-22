using UnityEngine;
using UnityEngine.EventSystems;

public class FPSPlayerFire : MonoBehaviour
{
    private Animator anim;

    public GameObject firePosition;
    public GameObject bombFactory;

    public float throwPower = 15f;
    public int weaponPower = 5;

    public GameObject bulletEffect;
    private ParticleSystem ps;

    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
        ps = bulletEffect.GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        if (FPSGameManager.Instance.gState != FPSGameManager.GameState.Run)
            return;

        if (Input.GetMouseButtonDown(0))
        {
            if (anim.GetFloat("MoveMotion") == 0)
            {
                anim.SetTrigger("Attack");
            }

            // 카메라의 위치에서 카메라의 앞으로 레이저 발사
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            RaycastHit hitInfo = new RaycastHit();

            Debug.DrawRay(ray.origin, ray.direction * 100f);

            if (Physics.Raycast(ray, out hitInfo))
            {
                if(hitInfo.transform.gameObject.layer == LayerMask.NameToLayer("Enemy"))
                {
                    EnemyFSM eFsm = hitInfo.transform.GetComponent<EnemyFSM>();
                    eFsm.HitEnemy(weaponPower);
                }
                else
                {
                    bulletEffect.transform.position = hitInfo.point; // 레이저를 맞은 대상의 포인트 (충돌 위치) 가져옴
                    bulletEffect.transform.forward = hitInfo.normal; // 피격 이펙트의 forward 방향을 부딪힌 지점의 법선벡터와 일치시켜 벽에서 터지는걸로 보이게함
                    ps.Play();
                }
            }
        }

        if (Input.GetMouseButtonDown(1))// 마우스 오른쪽 버튼 클릭
        {
            GameObject bomb = Instantiate(bombFactory);
            bomb.transform.position = firePosition.transform.position;

            Rigidbody rb = bomb.GetComponent<Rigidbody>();
            rb.AddForce(Camera.main.transform.forward * throwPower, ForceMode.Impulse);
        }
    }


}
