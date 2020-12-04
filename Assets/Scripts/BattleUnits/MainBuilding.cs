using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainBuilding : BattleUnit
{
    [SerializeField]
    Transform HealthBar;

    //Main building is an Ultimate Target
    private void Start()
    {
        UltimateTarget = this;
    }
    public override void OnAttacked()
    {
        HealthBar.localScale = new Vector3(Health/MaxHealth, HealthBar.localScale.y, HealthBar.localScale.z);
    }

    public override void OnDestroyed()
    {
        GameManager.GameOver();
    }
}
