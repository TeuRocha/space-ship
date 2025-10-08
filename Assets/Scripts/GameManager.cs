using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public TextMeshProUGUI scoreText;
    private int score = 0;
    private bool slowTimeActivated = false; // Flag para garantir que ative apenas uma vez

    public int scoreToActivateSlowTime = 1000;
    public int scoreToWin = 2500;
    public float slowFactor = 0.5f; // Metade da velocidade normal
    public float slowDuration = 5f; // Duração do efeito em segundos

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void AddScore(int points)
    {
        score += points;
        scoreText.text = "Score: " + score;

        if (!slowTimeActivated && score >= scoreToActivateSlowTime)
        {
            slowTimeActivated = true; // Marca como ativado
            SlowTime(); // Chama o método para desacelerar o tempo
        }
        if (score >= scoreToWin)
        {
            SceneManager.LoadScene("WinScene");
        }
    }

    public void SlowTime()
    {
        Debug.Log("Slow time ativado!"); // Para teste
        Time.timeScale = slowFactor;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
        Invoke("RestoreTime", slowDuration);
    }

    void RestoreTime()
    {
        Time.timeScale = 1f;
        Time.fixedDeltaTime = 0.02f;
    }
}