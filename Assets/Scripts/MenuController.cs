using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class MenuController : MonoBehaviour
{
    public void RestartGame()
    {
        // Carrega a cena principal do jogo.
        // Certifique-se de que o nome "MainGameScene" corresponde ao nome da sua cena de jogo.
        Time.timeScale = 1f; // Garante que o tempo volte ao normal ao reiniciar
        SceneManager.LoadScene("SampleScene");
    }
}
