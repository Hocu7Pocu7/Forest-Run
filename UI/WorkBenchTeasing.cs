using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class WorkBenchTeasing : MonoBehaviour
{
    GameManager GM;
    Text txt;

    [SerializeField] WorkBenchInfo WBinfo;
    [SerializeField] ItemInfo ItInfo;
    [SerializeField] InfoType infoType;
    [SerializeField] Type type;


    void Awake()
    {
        txt = GetComponent<Text>();
        GM = GameObject.Find("Game").GetComponent<GameManager>();

      
    }

    
    void Update()
    {
        switch (type)
        {
            case Type.Wood:
                int wood;
                if (infoType == InfoType.WorkBench)
                    wood = WBinfo.Wood;
                else
                    wood = ItInfo.Wood;

                txt.text = wood.ToString();
                if (GM.Wood >= wood)
                {
                    txt.color = Color.white;
                }
                else
                {
                    txt.color = Color.red;
                }
                break;

            case Type.Food:
                int food;
                if (infoType == InfoType.WorkBench)
                    food = WBinfo.Food;
                else
                    food = ItInfo.Food;

                txt.text = food.ToString();
                if (GM.Food >= food)
                {
                    txt.color = Color.white;
                }
                else
                {
                    txt.color = Color.red;
                }
                break;

            case Type.Stone:
                int stone;
                if (infoType == InfoType.WorkBench)
                    stone = WBinfo.Stone;
                else
                    stone = ItInfo.Stone;

                txt.text = stone.ToString();
                if (GM.Stone >= stone)
                {
                    txt.color = Color.white;
                }
                else
                {
                    txt.color = Color.red;
                }
                break;

            case Type.Iron:
                int iron;
                if (infoType == InfoType.WorkBench)
                    iron = WBinfo.Iron;
                else
                    iron = ItInfo.Iron;

                txt.text = iron.ToString();
                if (GM.Iron >= iron)
                {
                    txt.color = Color.white;
                }
                else
                {
                    txt.color = Color.red;
                }
                break;
        }
    }

    public enum Type
    {
        Wood,
        Food,
        Stone,
        Iron
    }

    public enum InfoType
    {
        WorkBench,
        Item
    }
}
