using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager:MonoBehaviour
{
    public static int CurrentWave=0;
    public static void StartNewWave()
    {
        CurrentWave++;
        SpawnManager.Instance.SpawnEnemies(CurrentWave + Random.Range(0, 11));
    }
}
