using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class AnimalEvent : MonoBehaviour
{
    [SerializeField] private GameObject flag;
    [SerializeField] private GameObject followTarget;
    private BoxCollider boxCollider;

    private float timer;
    private bool isTimer;

    public static Action failAction;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
        failAction += SetRandomPos;
    }

    private void Update()
    {
        if (!isTimer) return;
        timer += Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isTimer = true;
            SetRandomPos();

            followTarget.SetActive(true);

            GameManager.Instance.SetCameraState(CameraState.Animal);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log($"깃발 찾는데 걸린 시간 : {timer:F1}초 입니다.");
            isTimer = false;
            timer = 0;

            SetFlag(Vector3.zero, false);

            GameManager.Instance.SetCameraState(CameraState.Outside);
            followTarget.SetActive(false);
        }
    }

    private void SetRandomPos()
    {
        float randomX = Random.Range(boxCollider.bounds.min.x, boxCollider.bounds.max.x);
        float randomZ = Random.Range(boxCollider.bounds.min.z, boxCollider.bounds.max.z);

        var randomPos = new Vector3(randomX, 0, randomZ);

        SetFlag(randomPos, true);
    }

    private void SetFlag(Vector3 position, bool isActive)
    {
        flag.transform.SetParent(transform);
        flag.transform.position = position;
        flag.SetActive(isActive);
    }
}
