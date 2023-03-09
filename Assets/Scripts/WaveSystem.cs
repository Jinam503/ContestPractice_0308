using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WaveSystem : MonoBehaviour
{
    public Wave[] waves;
    private int currentWave = -1;
    public StagePlayManager sPM;
    public GameObject[] enemies;

    public Text waveText;

    

    private bool isChangingWave = false;

    
    private void LateUpdate()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        StartWave();

    }
    public void StartWave()
    {
        if (enemies.Length == 0 && currentWave < waves.Length - 1 && !isChangingWave)
        {
            currentWave++;
            isChangingWave = true;
            StartCoroutine(WaveText());
        }
    }
    IEnumerator WaveText()
    {
        waveText.gameObject.SetActive(true);
        waveText.text = "Wave " + (currentWave + 1);
        if (currentWave == waves.Length - 1) waveText.text = "BOSS";
        yield return new WaitForSeconds(2f);
        waveText.gameObject.SetActive(false);
        yield return new WaitForSeconds(1f);
        sPM.StartWave(waves[currentWave]);
        isChangingWave = false;
    }
}
[System.Serializable]
public struct Wave
{
    public List<int> enemytypeNspawnPoint;
    
}