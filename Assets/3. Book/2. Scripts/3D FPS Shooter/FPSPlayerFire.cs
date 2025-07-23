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

            // ?????? ??????? ?????? ?????? ?????? ???
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
                    bulletEffect.transform.position = hitInfo.point; // ???????? ???? ????? ????? (?úô ???) ??????
                    bulletEffect.transform.forward = hitInfo.normal; // ??? ??????? forward ?????? ?¥å??? ?????? ????????? ??????? ?????? ?????¡Æ?? ???????
                    ps.Play();
                }
            }
        }

        if (Input.GetMouseButtonDown(1))// ???? ?????? ??? ???
        {
            GameObject bomb = Instantiate(bombFactory);
            bomb.transform.position = firePosition.transform.position;

            Rigidbody rb = bomb.GetComponent<Rigidbody>();
            rb.AddForce(Camera.main.transform.forward * throwPower, ForceMode.Impulse);
        }
    }


}
