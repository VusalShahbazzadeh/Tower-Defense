using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManagement : MonoBehaviour
{
    public static List<Enemy> Enemies;
    public static int EnemiesKilled=0;

    //Each time Enemy list and number of killed enemies are refreshed
    private void Awake()
    {
        Enemies = new List<Enemy>();
        EnemiesKilled = 0;
    }
    // Decreases amount of health of attacked and returns if object was destroyed or not and sets a reward if it was destroyeds
    public static bool Attack(BattleUnit attacker, BattleUnit attacked, out int Reward)
    {
        attacked.Health -= attacker.Damage;
        attacked.OnAttacked();
        if (attacked.Health <= 0)
        {
            attacked.OnDestroyed();
            Reward = attacked.Reward;
            return true;
        }
        Reward = 0;
        return false;
    }
}

/// <summary>
/// All Classes that are more or less enroll in battles are derived from BattleUnit class, this class holds level, Health, Attack Damage, Reward when it is destroyed and working range(Trigger distance).
///Also Virtual callbacks when BattleUnit is attacked or its health is lower than 0
/// </summary>
public abstract class BattleUnit : MonoBehaviour
{
    public int Level;
    public float MaxHealth;
    public float Health;
    public float Damage;
    public int Reward;
    public float TriggerDistance; // Distance at which some activity is triggered

    public static BattleUnit UltimateTarget;

    public virtual void OnAttacked() { }

    public virtual void OnDestroyed() { }
}
