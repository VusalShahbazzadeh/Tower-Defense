using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceManagement : MonoBehaviour
{
    [SerializeField]
    Text GoldText;

    static int gold;
    public static int Gold
    {
        get => gold;
        set
        {
            gold = value;
            Instance.GoldText.text = "Gold: " + Gold;
        }
    }
    public static ResourceManagement Instance;
    private void Start()
    {
        Instance = this;
        Gold = 40;
    }


}
