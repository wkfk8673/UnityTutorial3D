using UnityEngine;

namespace Pattern
{
    public class ScoreManager : MonoBehaviour
    {
        private void OnEnable()
        {
            StudyEventBus.onScoreChanged += UpdateScore;
        }

        private void OnDisable()
        {
            StudyEventBus.onScoreChanged -= UpdateScore;
        }

        private void UpdateScore(int newScore)
        {
            Debug.Log($"현재점수 : {newScore}");
        }
    }
}
