using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

namespace Pattern
{
    public class Player : ISubject
    {
        private int score;

        public void AddScore(int score)
        {
            this.score += score;
            Debug.Log("현재 점수는 : " + score);

            NotifyObserver();
        }

        /*private void CheckQuest()
        {
            if (score >= 100 && !isQuestClear1)
            {
                isQuestClear1 = true;
                Debug.Log("100 점 달성");
            }
            else if (score >= 500 && !isQuestClear2)
            {
                isQuestClear2 = true;
                Debug.Log("500 점 달성");

            }
            else if (score >= 1000 && !isQuestClear3)
            {
                isQuestClear3 = true;
                Debug.Log("1000점 달성");
            }
        }
        */

        public List<IObserver> Observers { get; set; }

        public void AddObserver(IObserver observer)
        {
            Observers.Add(observer);
        }

        public void RemoveObserver(IObserver observer)
        {
            Observers.Remove(observer);
            
        }

        public void NotifyObserver()
        {
            foreach (var observer in Observers)
            {
                observer.Notify(score);
            }
        }
    }
}
