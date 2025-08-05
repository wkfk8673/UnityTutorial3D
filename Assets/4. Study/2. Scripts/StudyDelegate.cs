using UnityEngine;
using static System.Runtime.CompilerServices.RuntimeHelpers;

public class StudyDelegate : MonoBehaviour
{
    // Delegate : 대리자
    // 함수 참조 역할

    public delegate void MyDelegate(int n = 0); // void 타입의 함수를 가리킬 예정
    public MyDelegate myDelegate; // delegate 에 접근 가능한 변수

    public delegate void KeyDelegate(); // void 타입의 함수를 가리킬 예정
    public KeyDelegate onKeyDown; // delegate 에 접근 가능한 변수

    public KeyCode keycode = KeyCode.Space;

    public float timer;
    public bool isTimer = true;

    private void Update()
    {
        if (isTimer)
        {
            timer += Time.deltaTime;
        }
        if (Input.GetKeyDown(keycode))
        {
            onKeyDown?.Invoke();
        }
    }


    private void Start()
    {
        // 과거 방식의 델리게이트 할당 (참조 방식)
        //myDelegate = new MyDelegate(MethodA);
        // 현재 표준 방식
        myDelegate = MethodA;

        // 델리게이트 체인 / 참조 추가
        myDelegate += MethodB;
        myDelegate += MethodC;

        myDelegate -= MethodB;
        myDelegate += MethodB;

        // 델리게이트 호출
        myDelegate?.Invoke(10);

        onKeyDown += Respond;
        onKeyDown += StopTimer;
        onKeyDown += StopBomb;
    }

    public void Respond()
    {
        Debug.Log("키가 눌렸습니다.");
    }

    private void StopTimer()
    {
        isTimer = false;
        Debug.Log("타이머 정지");
    }

    private void StopBomb()
    {
        Debug.Log("폭탄 기능 정지 ");
    }

    public void MethodA(int a)
    {
        Debug.Log($"Method A : {a}");
    }

    public void MethodB(int b)
    {
        Debug.Log($"Method B : {b}");
    }

    public void MethodC(int c)
    {
        Debug.Log($"Method C : {c}");
    }
}
