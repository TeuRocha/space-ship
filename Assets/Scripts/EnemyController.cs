using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 2f;
    public int scoreValue = 100;
    public float lifeTime = 4f; // Tempo em segundos antes de desaparecer

    public float floatAmplitude = 1f; // Altura da "onda" de flutuação
    public float floatFrequency = 1f; // Velocidade da "onda" de flutuação

    private Vector3 startPosition;

    void Start()
    {
        // Guarda a posição inicial para calcular a flutuação
        startPosition = transform.position;
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    
        // Movimento de flutuação (eixo Y)
        float newY = startPosition.y + Mathf.Sin(Time.time * floatFrequency) * floatAmplitude;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            GameManager.instance.AddScore(scoreValue);
            Destroy(gameObject); // Inimigo destruído
            Destroy(collision.gameObject); // Tiro destruído
        }
    }
}