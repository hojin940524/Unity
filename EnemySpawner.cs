using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] enemies;

    private float[] arrPosX = { -2.2f, -1.1f, 0f, 1.1f, 2.2f };

    [SerializeField]
    private float spawnInterval = 1.5f;

    [SerializeField]
    private int numberOfEnemies = 5;

    [SerializeField]
    private float enemySpawnDelay = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        StartEnemyRoutine();
    }

    void StartEnemyRoutine()
    {
        StartCoroutine("EnemyRoutine");
    }

    IEnumerator EnemyRoutine()
    {
        yield return new WaitForSeconds(3f);
        float moveSpeed = 5f;
        int spawnCount = 0;
        int enemyIndex = 0;

        while (true)
        {
            for (int i = 0; i < numberOfEnemies; i++)
            {
                float posX = arrPosX[Random.Range(0, arrPosX.Length)];
                SpawnEnemy(posX, enemyIndex, moveSpeed);
                yield return new WaitForSeconds(enemySpawnDelay);
            }

            spawnCount += numberOfEnemies;
            if (spawnCount % 8 == 0)
            {
                enemyIndex += 1;
                moveSpeed += 2;
            }

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnEnemy(float posX, int index, float moveSpeed)
    {
        Vector3 spawnPos = new Vector3(posX, transform.position.y, transform.position.z);
        if (Random.Range(0, 5) == 0)
        {
            index += 1;
        }
        if (index >= enemies.Length)
        {
            index -= enemies.Length - 1;
        }
        GameObject enemyObject = Instantiate(enemies[index], spawnPos, Quaternion.identity);
        Enemy enemy = enemyObject.GetComponent<Enemy>();
        enemy.SetMoveSpeed(moveSpeed);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
