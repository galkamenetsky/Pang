using UnityEngine;



public static class PlayerPrefManager
{
    private const string lifeString = "Life";
    private const string scoreString = "Score";
    private const string volumeBgString = "VolumeBG";
    private const string volumeInGameString = "VolumeInGame";
    private const string openAppString = "OpenApp";

    // High Score
    public static int Life
    {
        get => PlayerPrefs.GetInt(lifeString);
        set => PlayerPrefs.SetInt(lifeString, value);
    }

    public static int Score
    {
        get => PlayerPrefs.GetInt(scoreString);
        set => PlayerPrefs.SetInt(scoreString, value);
    }
    public static float VolumeBG
    {
        get => PlayerPrefs.GetFloat(volumeBgString);
        set => PlayerPrefs.SetFloat(volumeBgString, value);
    }
    public static float VolumeInGame
    {
        get => PlayerPrefs.GetFloat(volumeInGameString);
        set => PlayerPrefs.SetFloat(volumeInGameString, value);
    }
    public static bool FirstOpenApp
    {
        get => PlayerPrefs.GetInt(openAppString) == 0;
        set => PlayerPrefs.SetInt(openAppString, value?0:1);
    }
    // Reset all player prefs
    public static void ResetPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
    }
}
