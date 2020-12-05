using UnityEngine;

public class WaveManager:MonoBehaviour
{
    //Index of Wave
    public static int CurrentWave=0;

    private void Start()
    {
        //intially it is 0
        CurrentWave = 0;
    }
    public static void StartNewWave()
    {
        //Reference to Enemy Prefab to upgrade it as new waves arrive
        GameObject Prefab = SpawnManager.Instance.Prefab;
        Enemy enemy = Prefab.GetComponent<Enemy>();
        //Wave index increased as it is new wave
        CurrentWave++;
        //Enemy is upgraded
        enemy.Level = CurrentWave;
        enemy.MaxHealth = enemy.Level * 10;
        enemy.Health = enemy.MaxHealth;
        enemy.Reward = enemy.Level * 10;
        enemy.Damage = enemy.Level * 10;

        //upgraded enemy is set to prefab
        SpawnManager.Instance.Prefab = Prefab;
        
        //from k to k+10 enemies are spawned, where K is index of wave
        SpawnManager.Instance.SpawnEnemies(CurrentWave + Random.Range(0, 11));
    }
}
