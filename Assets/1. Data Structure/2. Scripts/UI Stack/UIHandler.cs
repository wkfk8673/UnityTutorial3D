using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIHandler : MonoBehaviour, IPointerDownHandler, IDragHandler
{
    //UI 오브젝트는 모두 RectTransform 을 가지고있음
    private RectTransform parentRect;
    private Vector2 basePos; // 초기 위치
    private Vector2 startPos; // 드래그 시작 위치
    private Vector2 moveOffset; // 드래그 거리


    private void Awake()
    {
        // 부모의 위치를 받아와서 초기화
        parentRect = transform.parent.GetComponent<RectTransform>();

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        parentRect.SetAsLastSibling(); // 가장 마지막 호출한 ui 가 위에 그려지도록 설정

        basePos = parentRect.anchoredPosition; // 기존 UI의 위치
        startPos = eventData.position; // 시작 지점
    }
    public void OnDrag(PointerEventData eventData)
    {
        moveOffset = eventData.position - startPos; // 드래그한 상태의 Dir
        parentRect.anchoredPosition = basePos + moveOffset;
    }
}
