using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainBuilding : BattleUnit
{
    [SerializeField]
    Transform HealthBar; //Sprite that shrinks when health decreased

    //Main building is an Ultimate Target
    private void Start()
    {
        //Main building is set as UltimateTarget for all battle units, so enemies can attack it
        UltimateTarget = this; 
    }
    //Callback when MainBuilding gets attacked
    public override void OnAttacked()
    {
        //Healthbar shrinks when health is decreased
        HealthBar.localScale = new Vector3(Health/MaxHealth, HealthBar.localScale.y, HealthBar.localScale.z);
    }

    //Callback when MainBuilding's health is  lower than 0
    public override void OnDestroyed()
    {
        GameManager.GameOver();
    }
}
