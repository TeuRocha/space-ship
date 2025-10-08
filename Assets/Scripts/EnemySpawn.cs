using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemyPrefab; // Arraste o Prefab do inimigo aqui
    public float spawnInterval = 4f; // Tempo em segundos entre cada inimigo
    public float spawnDelay = 2f; // Tempo antes de começar a spawnar

    void Start()
    {
        // Inicia a rotina de spawn de inimigos
        StartCoroutine(SpawnEnemiesRoutine());
    }

    private IEnumerator SpawnEnemiesRoutine()
    {
        // Espera um tempo inicial antes de começar
        yield return new WaitForSeconds(spawnDelay);

        // Loop infinito para continuar spawnando
        while (true)
        {
            // Instancia um inimigo na posição do Spawner
            Instantiate(enemyPrefab, transform.position, Quaternion.identity);

            // Espera pelo intervalo de tempo definido antes de spawnar o próximo
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}