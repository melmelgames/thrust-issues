using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Score
{
    private static int score;
    public static int GetScore()
    {
        return score;
    }

    public static void AddScore(int value)
    {
        score += value;
    }

    public static void InitializeStatic()
    {
        score = 0;
    }
    public static int GetHighScore()
    {
        return PlayerPrefs.GetInt("highscore", 0);
    }

    public static void TrySetNewHighScore(int score)
    {
        int highscore = GetHighScore();
        if (score > highscore)
        {
            PlayerPrefs.SetInt("highscore", score);
            PlayerPrefs.Save();
        }
    }
}
