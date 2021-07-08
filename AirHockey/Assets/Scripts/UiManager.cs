using UnityEngine;

public class UiManager : MonoBehaviour
{

    [Header("Canvas")]
    public GameObject CanvasGame;
    public GameObject CanvasRestart;

    [Header("CanvasRestart")]
    public GameObject WinTxt;
    public GameObject LostTxt;

    [Header("Other")]
    public AudioManagerScript audioManager;

    public ScoreScript scoreScript;

    public PuckScript puckScript;
    public PlayerScript playerScript;
    public BotScript BotScript;

    public void ShowRestartCanvas(bool botWon)
    {
        Time.timeScale = 0;

        CanvasGame.SetActive(false);
        CanvasRestart.SetActive(true);

        if (botWon)
        {
            audioManager.PlayLostGame();
            WinTxt.SetActive(false);
            LostTxt.SetActive(true);
        }
        else
        {
            audioManager.PlayWonGame();
            WinTxt.SetActive(true);
            LostTxt.SetActive(false);
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1;

        CanvasGame.SetActive(true);
        CanvasRestart.SetActive(false);

        scoreScript.ResetScores();
        playerScript.ResetPosition();
        BotScript.ResetPosition();
    }
}
