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
        StartCoroutine(workOfTower());
        GetComponent<Button>().onClick.AddListener(ShowOptions) ;
    }

    IEnumerator workOfTower()
    {
        Vector3 position = GetComponent<RectTransform>().transform.position;
        position = Camera.main.ScreenToWorldPoint(position);
        position -= Vector3.forward * position.z;
        while (true)
        {
            //Finding enemie which is enough close to trigger tower
            Enemy temp = BattleManagement.Enemies.Find(e => {  return (e.transform.position - position).magnitude < TriggerDistance; });
            
            //Attacking this enemy while it is within range
            while (temp != null && (temp.transform.position - position).magnitude < TriggerDistance)
            {
                BattleManagement.Attack(this, temp, out Reward);
                ResourceManagement.Gold += Reward;
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
        TowerOptions.Instance.Tower = this;
        TowerOptions.Instance.gameObject.SetActive(true);
    }
}
