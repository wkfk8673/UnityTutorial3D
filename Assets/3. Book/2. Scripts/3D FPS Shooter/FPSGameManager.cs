using System.Collections;
using TMPro;
using UnityEngine;

public class FPSGameManager : Singleton<FPSGameManager>
{
    public enum GameState { Ready, Run, GameOver }
    public GameState gState;

    public GameObject gameLabel;
    private TextMeshProUGUI gameText;

    private PlayerMovement player;

    private void Start()
    {
        gState = GameState.Ready;
        gameText = gameLabel.GetComponent<TextMeshProUGUI>();

        gameText.text = "Ready. . .";
        gameText.color = new Color32(255, 185, 0, 255);

        player = GameObject.Find("Player").GetComponent<PlayerMovement>();

        StartCoroutine(ReadyToStart());
    }

    void Update()
    {
        if(player.hp <= 0)
        {
            player.GetComponentInChildren<Animator>().SetFloat("MoveMotion", 0f); // 게임오버 시 움직임 없음

            gameLabel.SetActive(true);
            gameText.text = "Game Over";
            gameText.color = new Color32(255, 0, 0, 255);

            gState = GameState.GameOver;
        }
    }

    IEnumerator ReadyToStart()
    {
        yield return new WaitForSeconds(2f);
        gameText.text = "Go!";

        yield return new WaitForSeconds(0.5f);
        gameLabel.SetActive(false);
        gState = GameState.Run;
    }
}