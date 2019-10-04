using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampManager : MonoBehaviour
{
    [SerializeField] UseItem item;

    [SerializeField] Transform CampFirePoint;
    [SerializeField] Transform[] WBPoints;

    [SerializeField] GameObject CampFire;
    [SerializeField] GameObject[] WBPrefabs;

    [HideInInspector]public short[] WorkBenchs = new short[4];
    [HideInInspector]public int CurrentItem;

    GameManager GM;
    /*
     WORKBENCHS ID:
     0 = SimpleWorkBench
     1 = Forge
     2 = MedicalWorkBench
     3 = HattingWorkBench

        ITEMS ID:
        0 = Empty
        1 = StoneAxe
        2 = IronAxe
        3 = StonePickAxe
        4 = IronPickAxe
        5 = StoneSpire
        6 = IronSpire
        7 = SlingShot
        8 = Sword
     */

    void Awake()
    {
        GM = GameObject.Find("Game").GetComponent<GameManager>();
        CurrentItem = -1;

    }


    public void CraftItem(int ID,int Wood, int Stone, int Iron)
    {

        GM.Wood -= Wood;
        GM.Stone -= Stone;
        GM.Iron -= Iron;

        item.SetItem(ID);
        CurrentItem = ID;
        
    }

    public void CraftMedicine(int Heal, int Wood, int Food, int Iron)
    {
        if (PlayerPrefs.GetInt("Perk7") != 0)
        {
            Wood = Mathf.RoundToInt(Wood - Wood*0.05f*PlayerPrefs.GetInt("Perk7"));
            Food = Mathf.RoundToInt(Food - Food * 0.05f * PlayerPrefs.GetInt("Perk7"));
            Iron = Mathf.RoundToInt(Iron - Iron * 0.05f * PlayerPrefs.GetInt("Perk7"));
        }

        GM.Wood -= Wood;
        GM.Food -= Food;
        GM.Iron -= Iron;

        GM.Heal(Heal);
    }

    public void CraftHat(int ID, int Wood, int Stone, int Iron)
    {
        GM.Wood -= Wood;
        GM.Stone -= Stone;
        GM.Iron -= Iron;

        GM.SetHat(ID);
    }

    public void BuildWorkBench(int ID, int Wood, int Food, int Stone, int Iron)
    {
        GM.Wood -= Wood;
        GM.Food -= Food;
        GM.Stone -= Stone;
        GM.Iron -= Iron;

        WorkBenchs[ID] = 1;
        Instantiate(WBPrefabs[ID], WBPoints[ID].position, WBPoints[ID].rotation);
    }

    public void SpawnCamp()
    {
        Instantiate(CampFire, CampFirePoint.position, CampFirePoint.rotation);
        
        if (WorkBenchs[0] == 1)
            Instantiate(WBPrefabs[0], WBPoints[0].position, WBPoints[0].rotation);
        if (WorkBenchs[1] == 1)
            Instantiate(WBPrefabs[1], WBPoints[1].position, WBPoints[1].rotation);
        if (WorkBenchs[2] == 1)
            Instantiate(WBPrefabs[2], WBPoints[2].position, WBPoints[2].rotation);
        if (WorkBenchs[3] == 1)
            Instantiate(WBPrefabs[3], WBPoints[3].position, WBPoints[3].rotation);
    }
}
