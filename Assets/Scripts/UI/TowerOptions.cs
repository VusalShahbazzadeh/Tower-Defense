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

    public static List<Tower> Towers;
    public static TowerOptions Instance;

    private void OnEnable()
    {
        //Game is paused
        GameManager.Instance.Pause(true);

        //Setting texts for panel ready for current level
        string[] CurrentLevelTexts = new string[] {
            "Level " + Tower.Level,
            "DMG " + Tower.Damage,
            "Range " + Tower.TriggerDistance,
            "Rate " + 1/Tower.FireRate
        };

        //Setting texts to UI for current level
        for (int i = 0; i < CurrentLevel.childCount; i++)
        {
            CurrentLevel.GetChild(i).GetComponent<Text>().text = CurrentLevelTexts[i];
        }

        //setting texts for planel ready for next level 
        string[] NextLevelTexts = new string[]
        {
            "Level " + (Tower.Level +1),
            "" + (Tower.Level*10+10),
            ""+(Tower.Level*0.5f + 1.5f),
            ""+(Tower.Level+1)
        };

        //Setting texts to ui for next level
        for (int i = 0; i < NextLevel.childCount; i++)
        {
            NextLevel.GetChild(i).GetComponent<Text>().text = NextLevelTexts[i];
        }

        //Setting cost to UI
        Cost.text = "" + Tower.Level * 10;
    }
    //Upgrades tower
    public void Upgrade()
    {
        //Checking if available gold is enough
        if (ResourceManagement.Gold >= Tower.Level * 10)
        {
            //If yes Cost is subtracted from Gold
            ResourceManagement.Gold -= Tower.Level * 10;
            //Tower is upgraded
            Tower.Level++;
            Tower.Damage = Tower.Level * 10;
            Tower.TriggerDistance = Tower.Level * 0.5f + 1;
            Tower.FireRate = 1f / Tower.Level;
            //UI is refreshed
            OnEnable();
        }
        else
        {
            //If no You don't have enough gold text will show up
            YouDontHaveEnoughGold.SetActive(true);
        }
    }

    public void ActivateTowers()
    {
        foreach (Tower tower in Towers)
        {
            tower.GetComponent<Button>().interactable = true;//Towers become interactable and can be upgraded
            tower.StartTower(); // Towers start to work
        }
    }
}
