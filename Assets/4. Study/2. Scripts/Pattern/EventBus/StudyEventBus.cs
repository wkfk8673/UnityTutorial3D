using System;
using UnityEngine;

public static class StudyEventBus
{
    // 어디서든 접근 가능한 bus static 으로 선언
    // class 가 static 할 경우 객체로 존재하지 못하므로, 유니티 런타임에 들어가야하는 monobehabior 를 선언 불가

    public static event Action onStart; // 외부에서 직접 접근하는 걸 막고, eventbus 의 함수로 접근하도록 제한
    public static event Action<int> onScoreChanged;

    public static void StartEvent()
    {
        onStart?.Invoke();
    }

    public static void ScoreChaged(int newScore)
    {
        onScoreChanged?.Invoke(newScore);
    }
}
