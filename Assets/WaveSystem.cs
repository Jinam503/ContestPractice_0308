using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class WaveSystem : MonoBehaviour
{
    public Wave[] waves;
    private int currentWave = -1;
    public StagePlayManager sPM;
    public GameObject[] enemies;
    private void Start()
    {
        
    }
    private void LateUpdate()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        StartWave();


    }
    public void StartWave()
    {
        if (enemies.Length == 0 && currentWave < waves.Length - 1)
        {
            currentWave++;
            sPM.StartWave(waves[currentWave]);
        }
    }
}
[System.Serializable]
public struct Wave
{
    public List<int> enemytypeNspawnPoint;
    
}