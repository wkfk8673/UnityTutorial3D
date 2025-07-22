using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController cc;
    private Animator anim;

    public float moveSpeed = 7f;

    private float gravity = -20f;
    private float yVelocity = 0f;

    public float jumpPower = 10f;
    public bool isJumping = false;

    public int hp = 60;

    private int maxHp = 60;
    public Slider hpSlider;

    public GameObject HitEffect;

    private void Start()
    {
        cc = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
        hpSlider.value = (float)hp / (float)maxHp;
    }

    private void Update()
    {
        if (FPSGameManager.Instance.gState != FPSGameManager.GameState.Run)
            return;

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(h, 0, v); // 크기와 방향이 있는 벡터
        anim.SetFloat("MoveMotion", dir.magnitude); // 벡터 크기값 (distance)
        dir = dir.normalized; // 방향 벡터



        // 카메라의 트랜스폼을 기준점으로 변환. (wasd 이동의 중심)
        dir = Camera.main.transform.TransformDirection(dir);


        //중력 적용
        yVelocity += gravity * Time.deltaTime;
        dir.y = yVelocity;

        // 캐릭터 컨트롤러에 내장된 이동 기능
        cc.Move(dir * moveSpeed * Time.deltaTime);

        if (cc.collisionFlags == CollisionFlags.Below)
        {
            if (isJumping)
            {
                isJumping = false;
            }
            yVelocity = 0f;
        }

        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            isJumping = true;
            yVelocity = jumpPower;
        }
    }

    public void DamageAction(int damage)
    {
        hp -= damage;
        hpSlider.value = (float)hp / (float)maxHp;

        if (hp > 0)
        {
            StartCoroutine(PlayHitEffect());
        }
    }


    IEnumerator PlayHitEffect()
    {
        HitEffect.SetActive(true);

        yield return new WaitForSeconds(0.3f);

        HitEffect.SetActive(false);

    }
}
