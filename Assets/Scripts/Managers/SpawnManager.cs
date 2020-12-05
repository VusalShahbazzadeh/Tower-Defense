using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    Transform[] SpawnPoints;
    [SerializeField]
    GameObject Prefab;
    [SerializeField]
    float SpawnRate;//Time which is waited inbetween spawning prefabs
    public static SpawnManager Instance;
    [SerializeField]
    GameObject[] BlankSpaces;
    private void Start()
    {
        Instance = this;
    }

    public void StartWaves()
    {
        foreach (GameObject go in BlankSpaces)
        {
            if (go != null)
            {
                go.GetComponent<Button>().interactable = false;
            }
        }
        WaveManager.StartNewWave();
    }

    public void SpawnEnemies(int NumberOfEnemies) => StartCoroutine(SpawnEnemiesCor(NumberOfEnemies));

    public IEnumerator SpawnEnemiesCor(int NumberOfEnemies)
    {
        //As there are several SpawnPoints number of enemies per point is calculated
        int NumberOfEnemiesPerPoint = Mathf.FloorToInt(NumberOfEnemies / SpawnPoints.Length);

        //Loop runs until number of enemies per point is spawned in each spawnPoint and waits some given time inbetween
        for (int i = 0; i < NumberOfEnemiesPerPoint; i++)
        {
            foreach (Transform transform in SpawnPoints)
            {
                Instantiate(Prefab, transform);
                yield return new WaitForSeconds(SpawnRate);
            }
        }

        //As there are remained after calculating number of enemies per point this remained is calculated and spawned in first of spawnpoints
        for (int i = 0; i < NumberOfEnemies - NumberOfEnemiesPerPoint * SpawnPoints.Length; i++)
        {
            Instantiate(Prefab, SpawnPoints[0]);
            yield return new WaitForSeconds(SpawnRate);
        }
    }
}
