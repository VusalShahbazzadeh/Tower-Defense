using System.Collections;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject GameOverPanel;
    public static GameManager Instance;

    private void Start()
    {
        Time.timeScale = 1;
        Instance = this;
    }

    public static void GameOver()
    {
        Instance.GameOverPanel.SetActive(true);
        Time.timeScale = 0f;
        OnGameOver();
    }

    public static Action OnGameOver;
}
