using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StagePlayManager : MonoBehaviour
{
    private Wave currentWave;
    public Transform[] spawnPoint;
    public GameObject[] enemyType;
    public void StartWave(Wave wave)
    {
        currentWave = wave;
        StartCoroutine(SpawnEnemy());
    }
    private IEnumerator SpawnEnemy()
    {
        int spawnEnemyCount = 0;
        while ( spawnEnemyCount < currentWave.enemyCount)
        {
            if(currentWave.enemytypeNspawnPoint[spawnEnemyCount] > -1)
            {
                Vector2 v = new Vector2(spawnPoint[spawnEnemyCount].transform.position.x, spawnPoint[spawnEnemyCount].transform.position.y + 5);
                GameObject clone = Instantiate(enemyType[currentWave.enemytypeNspawnPoint[spawnEnemyCount]], v, spawnPoint[spawnEnemyCount].transform.rotation);
                clone.GetComponent<Enemy>().MoveToTarget(spawnPoint[spawnEnemyCount].transform);

                spawnEnemyCount++;
                yield return new WaitForSeconds(0.5f);
            }
        }
    }
}
