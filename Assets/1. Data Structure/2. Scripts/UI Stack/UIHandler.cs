using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIHandler : MonoBehaviour, IPointerDownHandler, IDragHandler
{
    //UI ������Ʈ�� ��� RectTransform �� ����������
    private RectTransform parentRect;
    private Vector2 basePos; // �ʱ� ��ġ
    private Vector2 startPos; // �巡�� ���� ��ġ
    private Vector2 moveOffset; // �巡�� �Ÿ�


    private void Awake()
    {
        // �θ��� ��ġ�� �޾ƿͼ� �ʱ�ȭ
        parentRect = transform.parent.GetComponent<RectTransform>();

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        parentRect.SetAsLastSibling(); // ���� ������ ȣ���� ui �� ���� �׷������� ����

        basePos = parentRect.anchoredPosition; // ���� UI�� ��ġ
        startPos = eventData.position; // ���� ����
    }
    public void OnDrag(PointerEventData eventData)
    {
        moveOffset = eventData.position - startPos; // �巡���� ������ Dir
        parentRect.anchoredPosition = basePos + moveOffset;
    }
}
