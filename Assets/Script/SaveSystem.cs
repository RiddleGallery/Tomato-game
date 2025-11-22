using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class SaveSystem
{
    private const string HighscoreKey = "HIGH_SCORE.sav";
    private const string EndingUnlocksKey = "ENDING_UNLOCKS.sav";

    private static string GetSavedHighscore()
    {
        return Path.Combine(Application.persistentDataPath, HighscoreKey);
    }

    public static void SaveHighscore(string highscore)
    {
        string path = GetSavedHighscore();
        File.WriteAllText(path, highscore);
    }

}