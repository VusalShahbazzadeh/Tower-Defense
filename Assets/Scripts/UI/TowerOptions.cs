using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerOptions : MonoBehaviour
{
    [SerializeField]
    Transform CurrentLevel, NextLevel;
    [SerializeField]
    Text Cost;
    [SerializeField]
    Button UpgradeButton;
    [HideInInspector]
    public Tower Tower;
    [SerializeField]
    GameObject YouDontHaveEnoughGold;

    public static List<Tower> Towers = new List<Tower>();
    public static TowerOptions Instance;

    private void OnEnable()
    {
        GameManager.Instance.Pause(true);
        string[] CurrentLevelTexts = new string[] {
            "Level " + Tower.Level,
            "DMG " + Tower.Damage,
            "Range " + Tower.TriggerDistance,
            "Rate " + 1/Tower.FireRate
        };
        for (int i = 0; i < CurrentLevel.childCount; i++)
        {
            CurrentLevel.GetChild(i).GetComponent<Text>().text = CurrentLevelTexts[i];
        }

        string[] NextLevelTexts = new string[]
        {
            "Level " + (Tower.Level +1),
            "" + (Tower.Level*10+10),
            ""+(Tower.Level*0.5f + 1.5f),
            ""+(Tower.Level+1)
        };
        for (int i = 0; i < NextLevel.childCount; i++)
        {
            NextLevel.GetChild(i).GetComponent<Text>().text = NextLevelTexts[i];
        }
        Cost.text = "" + Tower.Level * 10;
    }
    public void Upgrade()
    {
        if (ResourceManagement.Gold >= Tower.Level * 10)
        {
            ResourceManagement.Gold -= Tower.Level * 10;
            Tower.Level++;
            Tower.Damage = Tower.Level * 10;
            Tower.TriggerDistance = Tower.Level * 0.5f + 1;
            Tower.FireRate = 1f / Tower.Level;
            OnEnable();
        }
        else
        {
            YouDontHaveEnoughGold.SetActive(true);
        }
    }

    public void ActivateTowers()
    {
        foreach (Tower tower in Towers)
        {
            tower.GetComponent<Button>().interactable = true;
        }
    }
}
