using System.Collections;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject GameOverPanel;
    public Text TotalKilled, Wave;
    public static GameManager Instance;

    private void Start()
    {
        Pause(false);
        Instance = this;
    }

    public void Pause(bool pause)
    {
        Time.timeScale = pause ? 0 : 1;
    }

    public static void GameOver()
    {
        Instance.GameOverPanel.SetActive(true);
        Instance.Pause(true);
        Instance.TotalKilled.text = ""+ BattleManagement.EnemiesKilled;
        Instance.Wave.text = "" + WaveManager.CurrentWave;
        OnGameOver();
    }

    public static Action OnGameOver = ()=> { };
}
