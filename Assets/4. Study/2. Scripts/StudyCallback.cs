using System;
using System.Collections;
using UnityEngine;

public class StudyCallback : MonoBehaviour
{
    public Action bombAction;

    private void OnEnable()
    {
        bombAction += () =>
        {
            BombExplosion();
            BombDamage();
            BombEffect();
        };
    }

    IEnumerator Start()
    {
        Debug.Log("폭탄 카운트 다운 시작");
        yield return new WaitForSeconds(5f);

        bombAction?.Invoke();
    }

    private void BombExplosion()
    {
        Debug.Log("폭발!");
    }

    private void BombDamage()
    {
        Debug.Log("폭발 데미지 적용!");
    }

    private void BombEffect()
    {
        Debug.Log("폭발 이펙트 설정");
    }
}
