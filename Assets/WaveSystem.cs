using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class WaveSystem : MonoBehaviour
{
    public Wave waves;
    public StagePlayManager sPM;
}
[System.Serializable]
public struct Wave
{
    public List<int> enemytypeNspawnPoint;
    public int enemyCount;
    
}