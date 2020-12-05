using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Placeholder UI to represent place where towers might be placed
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
        //TowerOptions are made singleton
        //It can't be done in TowerOptions class itself as in the start it is disabled
        if (TowerOptions.Instance == null)
            TowerOptions.Instance = TowerOptions;
        //Static list of towers are refreshed
        TowerOptions.Towers = new List<Tower>();
    }

    //When a new tower is requested
    public void AddTower()
    {
        //Checks if there are enough gold available
        if(Cost<= ResourceManagement.Gold)
        {
            //If yes cost is subtracted from gold
            ResourceManagement.Gold -= Cost;
            //A new tower is instantiated at the place of this current placeholder 
            Tower tower = Instantiate(TowerPrefab, transform.position, transform.rotation, transform.parent).GetComponent<Tower>();
            //and added to a list holding all tower references
            TowerOptions.Towers.Add(tower);
            //Current placeholder is destroyed
            Destroy(gameObject);
        }
    }

}
