using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlankSpace : MonoBehaviour
{
    [SerializeField]
    TowerOptions TowerOptions;
    [SerializeField]
    GameObject TowerPrefab;
    [SerializeField]
    int Cost;

    private void Start()
    {
        if(TowerOptions.Instance == null)
            TowerOptions.Instance = TowerOptions;
    }

    public void AddTower()
    {
        if(Cost<= ResourceManagement.Gold)
        {
            ResourceManagement.Gold -= Cost;
            TowerOptions.Towers.Add(Instantiate(TowerPrefab,transform.position,transform.rotation, transform.parent).GetComponent<Tower>());
            Destroy(gameObject);
        }
    }

}
