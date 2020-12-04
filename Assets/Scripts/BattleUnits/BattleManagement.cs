using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManagement : MonoBehaviour
{
    public static List<Enemy> Enemies;
    private void Awake()
    {
        Enemies = new List<Enemy>();
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

//An abstract class holding Health, Attack damage, and Reward given after destroying
public abstract class BattleUnit : MonoBehaviour
{
    public float MaxHealth;
    public float Health;
    public float Damage;
    public int Reward;
    [SerializeField]
    protected float TriggerDistance; // Distance at which some activity is triggered

    public static BattleUnit UltimateTarget;

    public virtual void OnAttacked() { }

    public virtual void OnDestroyed() { }
}
