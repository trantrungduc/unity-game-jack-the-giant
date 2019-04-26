using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HighScoreController : MonoBehaviour
{
    [SerializeField]
    private Text scoreText, coinText;
    void Start()
    {
        SetBasedOnDifficulty();
    }

    void SetScore(int Score, int coinScore)
    {
        scoreText.text = Score.ToString();
        coinText.text = coinScore.ToString();
    }

    void SetBasedOnDifficulty()
    {
        Debug.Log("AAAAAAAAAAAAAAAAAAAa"+GamePreferences.GetMediumDifficulty());

        if (GamePreferences.GetEeasyDifficulty() == 1)
        {
            SetScore(GamePreferences.GetEeasyDifficultyScore(), GamePreferences.GetEeasyDifficultyCoinScore());
        }
        if (GamePreferences.GetMediumDifficulty() == 1)
        {
            SetScore(GamePreferences.GetMediumDifficultyScore(), GamePreferences.GetMediumDifficultyCoinScore());
        }
        if (GamePreferences.GetHardDifficulty() == 1)
        {
            SetScore(GamePreferences.GetHardDifficultyScore(), GamePreferences.GetHardDifficultyCoinScore());
        }
    }

    public void GoBackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
