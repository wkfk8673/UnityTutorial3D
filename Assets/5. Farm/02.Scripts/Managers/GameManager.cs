using TMPro;
using Unity.Cinemachine;
using UnityEngine;
using static FieldManager;

public enum CameraState { Outside, Field, House, Animal, Board, Juice }
public class GameManager : Singleton<GameManager>
{
    public FieldManager field;
    public UIManager ui;
    public ItemManager item;
    [SerializeField] private TextMeshProUGUI money;

    public static int cash = 0;

    public CameraState cameraState = CameraState.Outside;

    [SerializeField] private CinemachineClearShot clearShot;

    public void SetCameraState(CameraState newState)
    {
        if (cameraState != newState)
        {
            cameraState = newState;

            foreach(var c in clearShot.ChildCameras)
                c.Priority = 1;
            clearShot.ChildCameras[(int)cameraState].Priority = 10;
        }
    }

    public void UpdateMoneyUI()
    {
        money.text = cash.ToString();
    }
}
