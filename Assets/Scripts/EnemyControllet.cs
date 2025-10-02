using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 2f;
    public int scoreValue = 100;

    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
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