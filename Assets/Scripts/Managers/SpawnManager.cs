using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    Transform[] SpawnPoints; //SpawnPoints which also holds Path
    public GameObject Prefab;
    [SerializeField]
    float SpawnRate;//Time which is waited inbetween spawning prefabs
    public static SpawnManager Instance; //singleton instance
    [SerializeField]
    GameObject[] BlankSpaces;// Reference to Spaces where towers can be added
    private void Start()
    {
        //Making SpawnManager singleton
        Instance = this;
    }

    //Game Loop is started
    public void StartWaves()
    {
        //Blank spaces are disabled so new towers can't be added
        foreach (GameObject go in BlankSpaces)
        {
            if (go != null)
            {
                go.GetComponent<Button>().interactable = false;
            }
        }
        //New wave is started
        WaveManager.StartNewWave();
    }

    //Enemies are spawned in coroutine so they instantiate after each other and there are distance between them
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
