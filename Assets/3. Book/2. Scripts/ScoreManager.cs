using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI currentScoreUI;
    public int currScore;

    public TextMeshProUGUI bestScoreUI;
    public int bestScore;

    private void Start()
    {
        bestScore = PlayerPrefs.GetInt("BestScore", 0);
        bestScoreUI.text = "�ְ� ���� : " + bestScore;
    }

    public void SetScore(int value)
    {
        currScore++;
        currentScoreUI.text = "���� ���� : " + currScore;

        if (currScore >= bestScore)
        {
            bestScore = currScore;
            bestScoreUI.text = "�ְ� ���� : " + bestScore;
            PlayerPrefs.SetInt("BestScore", bestScore);
        }
    }
    
    public int GetScore()
    {
        return currScore;
    }
}
