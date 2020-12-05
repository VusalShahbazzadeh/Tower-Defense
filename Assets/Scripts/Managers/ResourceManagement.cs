using UnityEngine;
using UnityEngine.UI;

public class ResourceManagement : MonoBehaviour
{
    [SerializeField]
    int InitialGold;
    [SerializeField]
    Text GoldText;

    static int gold;
    //When ever we set new gold value UI representing amount of gold is refreshed
    public static int Gold
    {
        get => gold;
        set
        {
            gold = value;
            Instance.GoldText.text = "Gold: " + Gold;
        }
    }
    //Singleton instance
    public static ResourceManagement Instance;
    private void Start()
    {
        //singleton
        Instance = this;
        //amount of gold is refreshed each time restarted
        Gold = InitialGold;
    }


}
