using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{

    private static GameManager instance;
    private static bool gameOver;
    private static bool isPaused;
    private static bool gameOn;

    private void Awake()
    {
        instance = this;
        gameOver = false;
        isPaused = false;
        gameOn = false;
        Time.timeScale = 0.0f;
        Health.InitializeStatic();
        Score.InitializeStatic();
    }

    private void Update()
    {
        int health = Health.GetHealth();
        if (health <= 0)
        {
            GameOver();
        }
        if (Input.GetKeyDown(KeyCode.P) && gameOn)
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else if (!isPaused)
            {
                PauseGame();
            }
        }
    }

    private void PauseGame()
    {
        isPaused = true;
        PauseWindow.ShowPauseWindowStatic();
        Time.timeScale = 0.0f;
    }

    private void GameOver()
    {
        Time.timeScale = 0.0f;
        gameOver = true;
        gameOn = false;
        Score.TrySetNewHighScore(Score.GetScore());
        GameOverWindow.ShowStatic();
    }

    public static void GameOverStatic()
    {
        instance.GameOver();
    }

    private void ResumeGame()
    {
        Time.timeScale = 1.0f;
        gameOver = false;
        isPaused = false;
        PauseWindow.HidePauseWindowStatic();
    }

    public static void ResumeGameStatic()
    {
        instance.ResumeGame();
        ScoreWindow.ShowStatic();
    }

    public static void StartGame()
    {
        gameOn = true;
    }


}