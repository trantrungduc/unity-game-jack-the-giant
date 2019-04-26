using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    [SerializeField]
    private Button musicButton;

    [SerializeField]
    private Sprite[] musicIcons;
    void Start()
    {
        
    }

    void CheckToPlayTheMusic()
    {
        if (GamePreferences.GetMusicState() == 1)
        {
            MusicController.instance.PlayMusic(true);
            musicButton.image.sprite = musicIcons[1];
        }
        else
        {
            MusicController.instance.PlayMusic(false);
            musicButton.image.sprite = musicIcons[0];
        }
    }

    public void StartGame()
    {
        GameManager.instance.gameStartedFromMainMenu = true;
        SceneManager.LoadScene("Gameplay");   
    }

    public void HighScore()
    {
        SceneManager.LoadScene("HighScore");
    }

    public void Options()
    {
        SceneManager.LoadScene("Options");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Music()
    {
        if (GamePreferences.GetMusicState() == 0)
        {
            GamePreferences.SetMusicState(1);
            MusicController.instance.PlayMusic(true);
            musicButton.image.sprite = musicIcons[1];
        }
        else
        {
            GamePreferences.SetMusicState(0);
            MusicController.instance.PlayMusic(false);
            musicButton.image.sprite = musicIcons[0];
        }
    }
}
