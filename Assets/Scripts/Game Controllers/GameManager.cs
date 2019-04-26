using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameManager instance;
    [HideInInspector]
    public bool gameStartedFromMainMenu,gameRestartedAfterPlayerDied;

    [HideInInspector]
    public int score, coinScore, lifeScore;
    void Awake()
    {
        MakeSingleton();
    }

    void Start()
    {
        InitializeVariables();
    }

    void InitializeVariables()
    {
        /*if (!PlayerPrefs.HasKey("Game Initialized"))
        {*/
            GamePreferences.SetEeasyDifficulty(0);
            GamePreferences.SetEeasyDifficultyScore(0);
            GamePreferences.SetEeasyDifficultyCoinScore(0);

            GamePreferences.SetMediumDifficulty(1);
            GamePreferences.SetMediumDifficultyScore(0);
            GamePreferences.SetMediumDifficultyCoinScore(0);

            GamePreferences.SetHardDifficulty(0);
            GamePreferences.SetHardDifficultyScore(0);
            GamePreferences.SetHardDifficultyCoinScore(0);

            GamePreferences.SetMusicState(0);
            PlayerPrefs.SetInt("Game Initialized", 1);
        //}
    }
    void sceneLoaded()
    {
        if (SceneManager.GetActiveScene().name=="Gameplay")
        {
            if (gameRestartedAfterPlayerDied)
            {
                GamePlayController.instance.SetScore(score);
                GamePlayController.instance.SetLifeScore(lifeScore);
                GamePlayController.instance.SetCoinScore(coinScore);

                PlayerScore.scoreCount = score;
                PlayerScore.coinCount = coinScore;
                PlayerScore.lifeCount = lifeScore;
            }if (gameStartedFromMainMenu)
            {
                PlayerScore.scoreCount = 0;
                PlayerScore.coinCount = 0;
                PlayerScore.lifeCount = 2;

                GamePlayController.instance.SetScore(0);
                GamePlayController.instance.SetLifeScore(2);
                GamePlayController.instance.SetCoinScore(0);
            }
        }
    }

    // Update is called once per frame
    void MakeSingleton()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void CheckGameStatus(int score, int coinScore, int lifeScore)
    {
        if (lifeScore < 0)
        {
            if (GamePreferences.GetEeasyDifficulty() == 1)
            {
                int highScore = GamePreferences.GetEeasyDifficultyScore();
                int coinHighScore = GamePreferences.GetEeasyDifficultyCoinScore();
                if (highScore < score)
                {
                    GamePreferences.SetEeasyDifficultyScore(score);
                }
                if (coinHighScore < coinScore)
                {
                    GamePreferences.SetEeasyDifficultyCoinScore(coinScore);
                }
            }

            if (GamePreferences.GetMediumDifficulty() == 1)
            {
                int highScore = GamePreferences.GetMediumDifficultyScore();
                int coinHighScore = GamePreferences.GetMediumDifficultyCoinScore();
                if (highScore < score)
                {
                    GamePreferences.SetMediumDifficultyScore(score);
                }
                if (coinHighScore < coinScore)
                {
                    GamePreferences.SetMediumDifficultyCoinScore(coinScore);
                }
            }

            if (GamePreferences.GetHardDifficulty() == 1)
            {
                int highScore = GamePreferences.GetHardDifficultyScore();
                int coinHighScore = GamePreferences.GetHardDifficultyCoinScore();
                if (highScore < score)
                {
                    GamePreferences.SetHardDifficultyScore(score);
                }
                if (coinHighScore < coinScore)
                {
                    GamePreferences.SetHardDifficultyCoinScore(coinScore);
                }
            }
            gameStartedFromMainMenu = false;
            gameRestartedAfterPlayerDied = false;
            GamePlayController.instance.GameOverShowPanel(score,coinScore);
        }
        else
        {
            this.score = score;
            this.coinScore = coinScore;
            this.lifeScore= lifeScore;

            GamePlayController.instance.SetScore(score);
            GamePlayController.instance.SetLifeScore(lifeScore);
            GamePlayController.instance.SetCoinScore(coinScore);

            gameStartedFromMainMenu = false;
            gameRestartedAfterPlayerDied = true;

            GamePlayController.instance.PlayerRestartTheGame();
        }
    }
}
