using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] TMP_Text scoreText;
    int score = 0;
    public int Score => score;
    public void IncreaseScore(int points)
    {
        if (gameManager.GameOver) return;
        
        score += points;
        scoreText.text = score.ToString();
    }
}

