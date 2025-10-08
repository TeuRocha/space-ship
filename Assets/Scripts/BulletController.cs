using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed = 10f;
    public float lifeTime = 3f; // Tempo em segundos antes de desaparecer

    void Start()
    {
        // Agenda a destruição do objeto de tiro após 'lifeTime' segundos
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        // Move o tiro para a frente (direita, no eixo X positivo)
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject); // Tiro destruído ao colidir com a parede
        }
    }
}