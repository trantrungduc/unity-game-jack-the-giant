using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GamePreferences
{
    public static string EeasyDifficulty = "EasyDifficulty";
    public static string MediumDifficulty = "MediumDifficulty";
    public static string HardDifficulty = "HardDifficulty";

    public static string EeasyDifficultyScore = "EeasyDifficultyScore";
    public static string MediumDifficultyScore = "MediumDifficultyScore";
    public static string HardDifficultyScore = "HardDifficultyScore";

    public static string EeasyDifficultyCoinScore = "EeasyDifficultyCoinScore";
    public static string MediumDifficultyCoinScore = "MediumDifficultyCoinScore";
    public static string HardDifficultyCoinScore = "HardDifficultyCoinScore";

    public static string isMusicOn = "isMusicOn";

    //0 - false, 1 = true
    public static void SetEeasyDifficulty(int diff)
    {
        PlayerPrefs.SetInt(EeasyDifficulty, diff);
    }

    public static int GetEeasyDifficulty()
    {
        return PlayerPrefs.GetInt(EeasyDifficulty);
    }

    public static void SetMediumDifficulty(int diff)
    {
        PlayerPrefs.SetInt(MediumDifficulty, diff);
    }

    public static int GetMediumDifficulty()
    {
        return PlayerPrefs.GetInt(MediumDifficulty);
    }

    public static void SetHardDifficulty(int diff)
    {
        PlayerPrefs.SetInt(HardDifficulty, diff);
    }

    public static int GetHardDifficulty()
    {
        return PlayerPrefs.GetInt(HardDifficulty);
    }

    public static void SetMusicState(int diff)
    {
        PlayerPrefs.SetInt(isMusicOn, diff);
    }

    public static int GetMusicState()
    {
        return PlayerPrefs.GetInt(isMusicOn);
    }

    public static void SetEeasyDifficultyScore(int diff)
    {
        PlayerPrefs.SetInt(EeasyDifficultyScore, diff);
    }

    public static int GetEeasyDifficultyScore()
    {
        return PlayerPrefs.GetInt(EeasyDifficultyScore);
    }

    public static void SetMediumDifficultyScore(int diff)
    {
        PlayerPrefs.SetInt(MediumDifficultyScore, diff);
    }

    public static int GetMediumDifficultyScore()
    {
        return PlayerPrefs.GetInt(MediumDifficultyScore);
    }

    public static void SetHardDifficultyScore(int diff)
    {
        PlayerPrefs.SetInt(HardDifficultyScore, diff);
    }

    public static int GetHardDifficultyScore()
    {
        return PlayerPrefs.GetInt(HardDifficultyScore);
    }
    //----------
    public static void SetEeasyDifficultyCoinScore(int diff)
    {
        PlayerPrefs.SetInt(EeasyDifficultyCoinScore, diff);
    }

    public static int GetEeasyDifficultyCoinScore()
    {
        return PlayerPrefs.GetInt(EeasyDifficultyCoinScore);
    }

    public static void SetMediumDifficultyCoinScore(int diff)
    {
        PlayerPrefs.SetInt(MediumDifficultyCoinScore, diff);
    }

    public static int GetMediumDifficultyCoinScore()
    {
        return PlayerPrefs.GetInt(MediumDifficultyCoinScore);
    }

    public static void SetHardDifficultyCoinScore(int diff)
    {
        PlayerPrefs.SetInt(HardDifficultyCoinScore, diff);
    }

    public static int GetHardDifficultyCoinScore()
    {
        return PlayerPrefs.GetInt(HardDifficultyCoinScore);
    }


}
