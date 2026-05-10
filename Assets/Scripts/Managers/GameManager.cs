using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Gameplay Related")]
    [SerializeField] PlayerController playerController;
    [SerializeField] TMP_Text timeText;
    [SerializeField] float startTime = 5f;

    [Header("Game Over Related")]
    [SerializeField] RawImage RedBackgorund;
    [SerializeField] GameObject gameOverText;
    [SerializeField] GameObject gameOverStats;
    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text distanceText;

    float timeLeft;
    bool gameOver = false;

    // public bool GameOver { get { return gameOver; } }
    public bool GameOver => gameOver;
    LevelGenerator levelGenerator;
    ScoreManager scoreManager;
    
    void Start()
    {
        timeLeft = startTime;
        levelGenerator = FindFirstObjectByType<LevelGenerator>();
        scoreManager = FindFirstObjectByType<ScoreManager>();
    }

    void Update()
    {
        DecreaseTime();
        if (timeLeft <= 10f)
        {
            FadeInRedBackgorund();
        }
        else
        {
            SetRedBackgroundTransparent();
        }
    }

    private void DecreaseTime()
    {
        if (gameOver) return;

        timeLeft -= Time.deltaTime;
        timeText.text = timeLeft.ToString("F1");

        if (timeLeft <= 0f)
        {
            PlayerGameOver();
        }

    }

    public void IncreaseTime(float amount)
    {
        timeLeft += amount;
        timeText.text = timeLeft.ToString("F1");
    }

    void PlayerGameOver()
    {
        gameOver = true;
        playerController.enabled = false;

        gameOverText.gameObject.SetActive(true);
        gameOverStats.gameObject.SetActive(true);

        scoreText.text = $"Score: {scoreManager.Score} points";
        distanceText.text = $"Distance: {levelGenerator.DistanceRan:F1} meters";

        Time.timeScale = .1f;
    }

    void FadeInRedBackgorund()
    {
        float timeLeftPercentage = Mathf.Clamp01((10f - timeLeft) / 10f);
        Color c = RedBackgorund.color;
        c.a = Mathf.Lerp(0f, 0.5f, timeLeftPercentage);
        RedBackgorund.color = c;
    }

    void SetRedBackgroundTransparent()
    {
        if (RedBackgorund.color.a != 0)
        {
            Color c = RedBackgorund.color;
            c.a = 0;
            RedBackgorund.color = c;
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
