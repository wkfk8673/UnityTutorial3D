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

            currentScoreUI.text = "���� ���� : " + currScore;

            if (currScore >= bestScore)
            {
                bestScore = currScore;
                bestScoreUI.text = "�ְ� ���� : " + bestScore;
                PlayerPrefs.SetInt("BestScore", bestScore);
            }
        }
    }

    private void Awake()
    {
        if (Instance == null)
        {
            // �ڱ� �ڽ��� �ν��Ͻ��� ������ ��� �ܺο��� ���� ��������
            Instance = this;
        }
    }

    private void Start()
    {
        bestScore = PlayerPrefs.GetInt("BestScore", 0);
        bestScoreUI.text = "�ְ� ���� : " + bestScore;
    }
}
