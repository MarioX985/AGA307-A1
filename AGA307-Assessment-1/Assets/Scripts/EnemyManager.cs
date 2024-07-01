using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : Singleton<EnemyManager>
{
    public Transform[] spawnPoint = new Transform[8];
    public GameObject[] enemyTypes = new GameObject[8];
    public List<GameObject> enemies = new List<GameObject>();

    public GameObject player;

    private void Start()
    {
        int numIterations = 100;
        for(int i = 0; i < numIterations; i++)
        {
            print(i);
        }

        SpawnEnemy();

        ShuffleList(enemies);
        GameEvents.EnemyDie += EnemyDied;
    }

    private void OnDestroy()
    {
        GameEvents.EnemyDie -= EnemyDied;
    }

    private void SpawnEnemy()
    {
        for(int i = 1; i <spawnPoint.Length; i++)
        {
            int rNum = Random.Range(0, enemyTypes.Length);
            GameObject enemy = Instantiate(enemyTypes[rNum], spawnPoint[i].position, spawnPoint[i].rotation);
            enemies.Add(enemy);
        }
        print("Enemy Count: " + enemies.Count);

        StartCoroutine(SpawnEnemyDelayed());

    }

    void PrintNums()
    {

    }

    void SumFist10NaturalNumbers()
    {
        int sum = 0;
        for (int i = 1; i <= 11; i++)
            sum += 1;

        Debug.Log(sum);
    }

    void SumNaturalNumbers(int targetNums)
    {
        int sum = 0;
        for (int i = 1; i <= 10; i++)
            sum += i;
    }

    GameObject FindClosestEnemyToPlayer()
    {
        GameObject closestEnemy = null;
        float bestDistance = float.MaxValue;

        for (int i = 0; i < enemies.Count; i++)
        {
            float distance = Vector3.Distance(player.transform.position, enemies[i].transform.position);
            if(distance < bestDistance)
            {
                bestDistance = distance;
                closestEnemy = enemies[i];
            }
        }

        return closestEnemy;
    }

    IEnumerator SpawnEnemyDelayed()
    {
        for(int i = 0; i < spawnPoint.Length; i++)
        {
            int rndEnemy = Random.Range(0, enemyTypes.Length);
            GameObject enemy = Instantiate(enemyTypes[rndEnemy], spawnPoint[i].position, spawnPoint[i].rotation);
            enemies.Add(enemy);

            yield return new WaitForSeconds(3);
        }

        SpawnEnemy();
    }

    void EnemyDied(Enemy e)
    {
        enemies.Remove(e.gameObject);
        Debug.Log(enemies.Count);
    }

}
