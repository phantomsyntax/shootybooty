using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Enemy Spawn Settings")]
    [SerializeField] private SOActorObject enemyActorObject;
    [SerializeField] private float spawnRate = 1.0f;
    [SerializeField] [Range(1,10)] private int enemiesPerSpawn;
    [SerializeField] private GameObject enemySpawnPoint;
                     private Transform enemySpawnPointTransform;
                     private WaitForSeconds enemySpawnWaitTime;

    private void Start()
    {
        NullChecks();

        enemySpawnPointTransform = enemySpawnPoint.transform;
        enemySpawnWaitTime = new WaitForSeconds(spawnRate);
        StartCoroutine(SpawnEnemies(spawnRate, enemiesPerSpawn));
    }

    private void NullChecks()
    {
        if (!enemySpawnPoint)
        {
            Debug.LogWarning($"[EnemySpawner] - No enemySpawnPoint Object is loaded!");
        }
    }

    public GameObject CreateNewEnemy()
    {
        GameObject newEnemy = Instantiate(enemyActorObject.actorPrefab, enemySpawnPointTransform.position, enemyActorObject.actorPrefab.transform.rotation);
        newEnemy.GetComponent<IActorProperties>().PopulateStats(enemyActorObject);
        newEnemy.name = enemyActorObject.actorName.ToString();
        return newEnemy;
    }

    IEnumerator SpawnEnemies(float rate, int quantity)
    {
        for (int enemy = 0; enemy < quantity; enemy++)
        {
            GameObject spawnedEnemy = CreateNewEnemy();
            yield return enemySpawnWaitTime;
        }
        yield return null;
    }
}