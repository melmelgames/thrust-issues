using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreWindow : MonoBehaviour
{
    public Text scoreText;
    public Text highscoreText;
    public Slider healthBar;
    private static ScoreWindow instance;

    private void Start()
    {
        instance = this;
        Hide();
    }
    private void Update()
    {
        UpdateScore();
        UpdateHealth();
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }

    public static void ShowStatic()
    {
        instance.Show();
    }

    private void UpdateScore()
    {
        scoreText.text = "SCORE: " + Score.GetScore().ToString();
        highscoreText.text = "HIGHSCORE: " + Score.GetHighScore().ToString();
    }

    public void UpdateHealth()
    {
        healthBar.value = Health.GetHealth();
    }
}
