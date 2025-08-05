using System;
using System.Collections;
using UnityEngine;

public class SwingController : MonoBehaviour
{

    private Animator anim;
    private bool isSwing;

    public Action OnStartSwing;
    public Action OnEndSwing;

    void Start()
    {
        anim = GetComponent<Animator>();

        OnStartSwing += SwingStart;
        OnEndSwing += SwingEnd;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!isSwing)
            {
                StartCoroutine(SwingRoutine());
            }
        }
    }

    IEnumerator SwingRoutine()
    {
        isSwing = true;
        anim.SetTrigger("Swing");
        OnStartSwing?.Invoke();

        float animLength = anim.GetCurrentAnimatorClipInfo(0).Length;
        yield return new WaitForSeconds(animLength);

        OnEndSwing?.Invoke();
        isSwing = false;
    }

    private void SwingStart()
    {
        Debug.Log("스윙 시작");
    }

    private void SwingEnd()
    {
        Debug.Log("스윙 종료");
    }
}
