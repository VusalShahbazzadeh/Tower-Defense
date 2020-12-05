using System;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject GameOverPanel;
    public Text TotalKilled, Wave;
    public static GameManager Instance;

    private void Start()
    {
        //Game is unpaused
        Pause(false);
        //Singleton
        Instance = this;
    }

    //Setting timescale to 0 is paused and to 1 if it is unpaused
    public void Pause(bool pause)
    {
        Time.timeScale = pause ? 0 : 1;
    }

    //GameOver 
    public static void GameOver()
    {
        //Game Over Panel is activated
        Instance.GameOverPanel.SetActive(true);
        //Game is paused
        Instance.Pause(true);
        //Number of totalKilled and last wave index is shown
        Instance.TotalKilled.text = ""+ BattleManagement.EnemiesKilled;
        Instance.Wave.text = "" + WaveManager.CurrentWave;
        //CallBack
        OnGameOver();
    }

    public static Action OnGameOver = ()=> { };
}
