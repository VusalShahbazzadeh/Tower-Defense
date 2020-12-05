using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.Linq;

public class Tower : BattleUnit
{
    public float FireRate;//Time which is waited inbetween firing
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(ShowOptions) ;//When pressed on tower towerOptions will shop up
    }

    public void StartTower() => StartCoroutine(workOfTower()); // Towers StartToWork
    IEnumerator workOfTower()
    {
        //WorldSpace position of tower is calculated
        Vector3 position = GetComponent<RectTransform>().transform.position;
        position = Camera.main.ScreenToWorldPoint(position);
        position -= Vector3.forward * position.z;

        //Work loop
        while (true)
        {
            //Finding enemie which is enough close to trigger tower
            Enemy temp = BattleManagement.Enemies.Find(e => {  return (e.transform.position - position).magnitude < TriggerDistance; });
            
            //Attacking this enemy while it is within range
            while (temp != null && (temp.transform.position - position).magnitude < TriggerDistance)
            {
                BattleManagement.Attack(this, temp, out Reward);
                ResourceManagement.Gold += Reward;
                //If reward is higher than zero it means enemy was killed
                if (Reward > 0)
                {
                    BattleManagement.EnemiesKilled++;
                }
                yield return new WaitForSeconds(FireRate);
            }
            yield return null;
        }
    }

    private void ShowOptions()
    {
        //Passing reference of this tower to TowerOptions
        TowerOptions.Instance.Tower = this;
        //Showing TowerOptions panel
        TowerOptions.Instance.gameObject.SetActive(true);
    }
}
