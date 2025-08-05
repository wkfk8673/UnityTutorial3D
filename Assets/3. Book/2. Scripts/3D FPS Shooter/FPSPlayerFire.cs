using System.Collections;
using TMPro;
using UnityEngine;

public class FPSPlayerFire : MonoBehaviour
{
    private enum WeaponMode { Normal, Sniper }
    private WeaponMode wMode;
    public TextMeshProUGUI WModeText;
    public GameObject[] flash;

    private Animator anim;

    public GameObject firePosition;
    public GameObject bombFactory;

    public float throwPower = 10f;
    public int weaponPower = 5;


    public GameObject crossHair01;
    public GameObject crossHair02;
    public GameObject crossHair02_zoom;


    public GameObject bulletEffect;
    private ParticleSystem ps;

    private bool ZoomMode = false;

    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
        ps = bulletEffect.GetComponent<ParticleSystem>();

        wMode = WeaponMode.Normal;
    }

    private void Update()
    {
        if (FPSGameManager.Instance.gState != FPSGameManager.GameState.Run)
            return;

        #region 마우스 왼쪽 클릭 -> 총 발사

        if (Input.GetMouseButtonDown(0))
        {
            if (anim.GetFloat("MoveMotion") == 0)
            {
                anim.SetTrigger("Attack");
            }

            StartCoroutine(ShootEffectOn(0.05f));


            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            RaycastHit hitInfo = new RaycastHit();

            Debug.DrawRay(ray.origin, ray.direction * 100f);

            if (Physics.Raycast(ray, out hitInfo))
            {
                if (hitInfo.transform.gameObject.layer == LayerMask.NameToLayer("Enemy"))
                {
                    EnemyFSM eFsm = hitInfo.transform.GetComponent<EnemyFSM>();
                    eFsm.HitEnemy(weaponPower);
                }
                else
                {
                    bulletEffect.transform.position = hitInfo.point;
                    bulletEffect.transform.forward = hitInfo.normal;
                    ps.Play();
                }
            }
        }
        #endregion

        #region 마우스 오른쪽 클릭 -> 줌 전환

        if (Input.GetMouseButtonDown(1))
        {
            switch (wMode)
            {
                case WeaponMode.Normal: // 일반 모드 수류탄
                    GameObject bomb = Instantiate(bombFactory);
                    bomb.transform.position = firePosition.transform.position;

                    Rigidbody rb = bomb.GetComponent<Rigidbody>();
                    rb.AddForce((Camera.main.transform.forward + Camera.main.transform.up * 0.5f) * throwPower, ForceMode.Impulse);
                    break;
                case WeaponMode.Sniper: // 저격 모드 줌 확대
                    ZoomMode = !ZoomMode;// 토글기능

                    float fov = ZoomMode ? 15f : 60f;
                    Camera.main.fieldOfView = fov;

                    crossHair02_zoom.gameObject.SetActive(ZoomMode);
                    crossHair02.gameObject.SetActive(!ZoomMode);

                    break;
            }

        }

        #endregion

        #region 무기 변경

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            WModeText.text = "Normal Mode";
            wMode = WeaponMode.Normal;
            Camera.main.fieldOfView = 60f;


            crossHair01.SetActive(true);
            crossHair02.SetActive(false);
            crossHair02_zoom.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            WModeText.text = "Sniper Mode";
            wMode = WeaponMode.Sniper;

            crossHair01.SetActive(false);
            crossHair02.SetActive(true);
            crossHair02_zoom.SetActive(false);
        }

        #endregion
    }

    /// <summary>
    /// 총구 화약 이펙트
    /// </summary>
    /// <param name="duration"></param>
    /// <returns></returns>
    IEnumerator ShootEffectOn(float duration)
    {
        int num = Random.Range(0, flash.Length - 1);
        flash[num].SetActive(true);

        yield return new WaitForSeconds(duration);
        flash[num].SetActive(false);
    }

}
