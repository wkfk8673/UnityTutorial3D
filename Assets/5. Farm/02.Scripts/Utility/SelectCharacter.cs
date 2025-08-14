using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SelectCharacter : MonoBehaviour
{
    [SerializeField] private Transform centerPivot;
    [SerializeField] private Button[] turnButton; //0 Left, 1 Right
    [SerializeField] private Button selectButton;

    [SerializeField] private Animator[] characteranims;

    private bool isTurn;
    private int currentIndex;

    private void Start()
    {

        turnButton[0].onClick.AddListener(() => Turn(true));
        turnButton[1].onClick.AddListener(() => Turn(false));

        selectButton.onClick.AddListener(Select);
    }

    private void Turn(bool isLeft)
    {
        if (!isTurn)
        {
            int value = isLeft ? -1 : 1;
            currentIndex += value;

            if (currentIndex < 0) currentIndex = 3;
            else if (currentIndex > 3) currentIndex = 0;

            float turnValue = value * 90;
            var targetRotation = centerPivot.rotation * Quaternion.Euler(0, turnValue, 0);

            isTurn = true;
            StartCoroutine(TurnRoutine(targetRotation));
        }

    }

    IEnumerator TurnRoutine(Quaternion targetRotation)
    {
        while (true)
        {
            yield return null;
            centerPivot.rotation = Quaternion.Slerp(centerPivot.rotation, targetRotation, 5f * Time.deltaTime);

            Debug.Log("Turn");

            var angle = Quaternion.Angle(centerPivot.rotation, targetRotation);
            if (angle <= 0.1f)
            {
                isTurn = false;
                centerPivot.rotation = targetRotation;
                Debug.Log("Completed Turn");

                yield break;
            }
        }

    }
    private void Select()
    {
        Debug.Log($"현재 선택한 캐릭터는 {currentIndex}번째 캐릭터 입니다.");

        LoadSceneManager.Instance.SetCharacterIndex(currentIndex);

        StartCoroutine(SelectRoutine());
        
    }

    IEnumerator SelectRoutine()
    {
        characteranims[currentIndex].SetTrigger("Select");

        yield return new WaitForSeconds(3f);

        LoadSceneManager.Instance.OnLoadScene();
    }

}
