using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : BattleUnit
{
    [SerializeField]
    float speed;

    Vector3 Direction = Vector3.zero;
    Transform CheckPoint;
    private void Start()
    {
        CheckPoint= transform.parent.GetChild(0); // Enemies and checkpoint is child of the same object
        BattleManagement.Enemies.Add(this);
    }
    private void Update()
    {
        //Finding vector from current unit to next Checkpoint
        Direction = (CheckPoint.position - transform.position);
        //Moving towards CheckPoint
        transform.position += Direction.normalized * speed * Time.deltaTime;
        //Each CheckPoint hold number of children which are next CheckPoints
        //If Distance is lower than trigger distance next checkpoint is selected randomly
        //otherwise it is final checkpoint and the Ultimate Target
        //Ultimate target is inside of BattleUnit script as static field and each unit "knows" it
        if (Direction.magnitude < TriggerDistance)
            if (CheckPoint.childCount > 0)
                CheckPoint = CheckPoint.GetChild(Random.Range(0, CheckPoint.childCount));
            else
            {
                BattleManagement.Attack(this, UltimateTarget, out int trash);
                OnDestroyed();
            }
    }

    //When enemy is attacked
    public override void OnAttacked()
    {
        transform.localScale = Health / MaxHealth * Vector3.one;
    }
    //When enemy's health is lower than 0
    public override void OnDestroyed()
    {
        //Enemy is removed from list of enemies
        BattleManagement.Enemies.Remove(this);

        //If there are no more enemies new wave starts immediately
        if (BattleManagement.Enemies.Count == 0)
            WaveManager.StartNewWave();

        //This current enemy's gameobject is removed from scene
        Destroy(gameObject);
    }
}
