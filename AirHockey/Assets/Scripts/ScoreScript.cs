using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public enum Score
    {
        BotScore, PlayerScore
    }

    public Text BotScoreText, PlayerScoreText;

    public UiManager uiManager;

    public int maxScore;

    #region Scores
    private int botScore, playerScore;

    private int BotScore { get { return botScore; } set { botScore = value; if (value == maxScore) uiManager.ShowRestartCanvas(true); } }
    private int PlayerScore { get { return playerScore; } set { playerScore = value; if (value == maxScore) uiManager.ShowRestartCanvas(false); } }
    #endregion

    public void Increment(Score whichScore)
    {
        if (whichScore == Score.BotScore)
            BotScoreText.text = (++BotScore).ToString();
        else
            PlayerScoreText.text = (++PlayerScore).ToString();
    }

    public void ResetScores()
    {
        BotScore = PlayerScore = 0;
        BotScoreText.text = PlayerScoreText.text = "0";
    }
}
