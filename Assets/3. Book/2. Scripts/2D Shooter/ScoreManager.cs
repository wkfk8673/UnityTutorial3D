using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance = null;

    public TextMeshProUGUI currentScoreUI;
    public TextMeshProUGUI bestScoreUI;

    public int currScore;
    public int bestScore;

    public int Score
    {
        get { return currScore; }
        set 
        { 
            currScore = value;

            currentScoreUI.text = "현재 점수 : " + currScore;

            if (currScore >= bestScore)
            {
                bestScore = currScore;
                bestScoreUI.text = "최고 점수 : " + bestScore;
                PlayerPrefs.SetInt("BestScore", bestScore);
            }
        }
    }

    private void Awake()
    {
        if (Instance == null)
        {
            // 자기 자신을 인스턴스로 선언할 경우 외부에서 접근 가능해짐
            Instance = this;
        }
    }

    private void Start()
    {
        bestScore = PlayerPrefs.GetInt("BestScore", 0);
        bestScoreUI.text = "최고 점수 : " + bestScore;
    }
}
