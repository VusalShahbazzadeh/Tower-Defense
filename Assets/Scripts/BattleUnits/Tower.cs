using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Tower : BattleUnit
{
    [SerializeField]
    float FireRate;//Time which is waited inbetween firing
    private void Start()
    {
        StartTower();
        GameManager.OnGameOver += StopTower;
    }


    IEnumerator WorkOfTower; //variable to hold coroutine to stop it when needed

    public void StartTower() => StartCoroutine(WorkOfTower = workOfTower());

    public void StopTower() => StopCoroutine(WorkOfTower);

    IEnumerator workOfTower()
    {
        Vector3 position = GetComponent<RectTransform>().transform.position;
        position = Camera.main.ScreenToWorldPoint(position);
        position -= Vector3.forward * position.z;
        while (true)
        {
            Debug.Log("Here");
            //Finding enemie which is enough close to trigger tower
            Enemy temp = BattleManagement.Enemies.Find(e => {  return (e.transform.position - position).magnitude < TriggerDistance; });
            
            //Attacking this enemy while it is within range
            while (temp != null && (temp.transform.position - position).magnitude < TriggerDistance)
            {
                BattleManagement.Attack(this, temp, out Reward);
                ResourceManagement.Gold += Reward;
                yield return new WaitForSeconds(FireRate);
            }
            yield return null;
        }
    }
}
