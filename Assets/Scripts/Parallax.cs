using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    // Variáveis declaradas aqui, no nível da classe, ficam visíveis no Inspector se forem 'public'.
    public float parallaxEffect; // Esta é a velocidade do scroll

    private float length;
    private Vector3 startPosition;

    void Start()
    {
        // Guarda a posição inicial do sprite
        startPosition = transform.position;
        // Pega a largura do sprite
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        // Move a imagem para a esquerda constantemente
        transform.position += Vector3.left * parallaxEffect * Time.deltaTime;

        // Se a imagem saiu completamente da tela pela esquerda, reposiciona ela
        // para a direita para criar o efeito de loop.
        if (transform.position.x < startPosition.x - length)
        {
            transform.position = startPosition;
        }
    }
}