using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsController : MonoBehaviour
{
    [SerializeField]
    private GameObject easySign, mediumSign, hardSign;
    void Start()
    {
        SetTheDifficulty();
    }

    void setInitialDifficulty(string diff)
    {
        switch (diff)
        {
            case "easy":
                easySign.SetActive(true);
                mediumSign.SetActive(false);
                hardSign.SetActive(false);
                break;
            case "medium":
                easySign.SetActive(false);
                mediumSign.SetActive(true);
                hardSign.SetActive(false);
                break;
            case "hard":
                easySign.SetActive(false);
                mediumSign.SetActive(false);
                hardSign.SetActive(true);
                break;
        }
    }

    void SetTheDifficulty()
    {
        if (GamePreferences.GetEeasyDifficulty() == 1)
        {
            setInitialDifficulty("easy");
        }
        if (GamePreferences.GetMediumDifficulty() == 1)
        {
            setInitialDifficulty("medium");
        }
        if (GamePreferences.GetHardDifficulty() == 1)
        {
            setInitialDifficulty("hard");
        }
    }

    public void EeasyDificulty()
    {
        easySign.SetActive(true);
        mediumSign.SetActive(false);
        hardSign.SetActive(false);

        GamePreferences.SetEeasyDifficulty(1);
        GamePreferences.SetMediumDifficulty(0);
        GamePreferences.SetHardDifficulty(0);
    }
    public void MediumDificulty()
    {
        easySign.SetActive(false);
        mediumSign.SetActive(true);
        hardSign.SetActive(false);

        GamePreferences.SetEeasyDifficulty(0);
        GamePreferences.SetMediumDifficulty(1);
        GamePreferences.SetHardDifficulty(0);
    }
    public void HardDificulty()
    {
        easySign.SetActive(false);
        mediumSign.SetActive(false);
        hardSign.SetActive(true);

        GamePreferences.SetEeasyDifficulty(0);
        GamePreferences.SetMediumDifficulty(0);
        GamePreferences.SetHardDifficulty(1);
    }
    public void GoBackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
