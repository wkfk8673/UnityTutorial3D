using UnityEngine;

/// <summary>
/// 기능 실행 행위 캡슐화에 목적이 있음
/// </summary>
public interface ICommand
{
    void Excute();

    void Cancel();
}
