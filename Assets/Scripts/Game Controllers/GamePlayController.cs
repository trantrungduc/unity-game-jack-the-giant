using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GamePlayController : MonoBehaviour
{
    public static GamePlayController instance;

    [SerializeField]
    private Text scoreText, coinText, lifeText,gameOverScoreText,gameOverCoinText;

    [SerializeField]
    private GameObject pausePanel,gameOverPanel,readyButton;
    void Awake()
    {
        MakeInstance();
    }

    
    void Start()
    {
        Time.timeScale = 0f;
    }

    // Update is called once per frame
    void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void PauseTheGame()
    {
        Time.timeScale = 0f;
        pausePanel.SetActive(true);
    }

    public void ResumeTheGame()
    {
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
    }

    public void QuitGame()
    {
        Time.timeScale = 1f;
        pausePanel.SetActive(true);
        SceneManager.LoadScene("MainMenu");
    }

    public void SetScore(int Score)
    {
        scoreText.text = "x" + Score;
    }
    public void SetCoinScore(int Score)
    {
        coinText.text = "x" + Score;
    }
    public void SetLifeScore(int Score)
    {
        lifeText.text = "x" + Score;
    }

    public void GameOverShowPanel(int finalScore,int finalCoin)
    {
        gameOverScoreText.text = finalScore.ToString();
        gameOverCoinText.text = finalCoin.ToString();
        gameOverPanel.SetActive(true);
        StartCoroutine(GameOverLoadMainMenu());
    }

    IEnumerator GameOverLoadMainMenu()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("MainMenu");
    }

    public void PlayerRestartTheGame()
    {
        StartCoroutine(PlayerDiedRestart());
    }

    IEnumerator PlayerDiedRestart()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("Gameplay");
    }

    public void ReadyToPlayGame()
    {
        Time.timeScale = 1f;
        readyButton.SetActive(false);
    }
}
