using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemInfo : MonoBehaviour
{
    public int Wood;
    public int Food;
    public int Stone;
    public int Iron;

    [SerializeField] Type type;
    [SerializeField] int ID;
    [SerializeField] Sprite hammer;
    [SerializeField] Sprite mark;
    [SerializeField] Text Res1;
    [SerializeField] Text Res2;
    [SerializeField] ResType FirstRes;
    [SerializeField] ResType SecondRes;

    CampManager CM;
    GameManager GM;
    Button Butt;

    Image[] ButtonElement;

    void Awake()
    {
         
        CM = GameObject.Find("Game").GetComponent<CampManager>();
        GM = CM.gameObject.GetComponent<GameManager>();
        Butt = GetComponentInChildren<Button>();
        ButtonElement = Butt.gameObject.GetComponentsInChildren<Image>();

        switch(FirstRes)
        {
            case ResType.Wood:
                Res1.text = Wood.ToString();
                break;
            case ResType.Food:
                Res1.text = Food.ToString();
                break;
            case ResType.Stone:
                Res1.text = Stone.ToString();
                break;
            case ResType.Iron:
                Res1.text = Iron.ToString();
                break;
        }
        switch (SecondRes)
        {
            case ResType.Wood:
                Res2.text = Wood.ToString();
                break;
            case ResType.Food:
                Res2.text = Food.ToString();
                break;
            case ResType.Stone:
                Res2.text = Stone.ToString();
                break;
            case ResType.Iron:
                Res2.text = Iron.ToString();
                break;
        }
    }

    public void CraftThis()
    {
        switch (type)
        {
            case Type.Item:
            CM.CraftItem(ID, Wood, Stone, Iron);
                break;
            case Type.Medicine:
            CM.CraftMedicine(ID, Wood, Food, Iron);
                break;
            case Type.Hat:
                CM.CraftHat(ID, Wood,Stone,Iron);
                break;
        }
        
    }

    private void Update()
    {

        switch (FirstRes)
        {
            case ResType.Wood:
                if (GM.Wood >= Wood)
                    Res1.color = Color.white;
                else
                    Res1.color = Color.red;
                break;
            case ResType.Food:
                if (GM.Food >= Food)
                    Res1.color = Color.white;
                else
                    Res1.color = Color.red;
                break;
            case ResType.Stone:
                if (GM.Stone >= Stone)
                    Res1.color = Color.white;
                else
                    Res1.color = Color.red;
                break;
            case ResType.Iron:
                if (GM.Iron >= Iron)
                    Res1.color = Color.white;
                else
                    Res1.color = Color.red;
                break;
        }
        switch (SecondRes)
        {
            case ResType.Wood:
                if (GM.Wood >= Wood)
                    Res2.color = Color.white;
                else
                    Res2.color = Color.red;
                break;
            case ResType.Food:
                if (GM.Food >= Food)
                    Res2.color = Color.white;
                else
                    Res2.color = Color.red;
                break;
            case ResType.Stone:
                if (GM.Stone >= Stone)
                    Res2.color = Color.white;
                else
                    Res2.color = Color.red;
                break;
            case ResType.Iron:
                if (GM.Iron >= Iron)
                    Res2.color = Color.white;
                else
                    Res2.color = Color.red;
                break;
        }

        switch (type)
        {

            case Type.Item:
                if (CM.CurrentItem != ID)
                {

                    ButtonElement[0].enabled = true;
                    ButtonElement[1].sprite = hammer;

                    if (GM.Wood >= Wood && GM.Food >= Food && GM.Stone >= Stone && GM.Iron >= Iron)
                        Butt.interactable = true;
                    else
                        Butt.interactable = false;

                }
                else
                {
                    Butt.interactable = false;
                    ButtonElement[0].enabled = false;
                    ButtonElement[1].sprite = mark;
                }
                break;


            case Type.Hat:
                if (GM.HatID != ID)
                {

                    ButtonElement[0].enabled = true;
                    ButtonElement[1].sprite = hammer;

                    if (GM.Wood >= Wood && GM.Food >= Food && GM.Stone >= Stone && GM.Iron >= Iron)
                        Butt.interactable = true;
                    else
                        Butt.interactable = false;

                }
                else
                {
                    Butt.interactable = false;
                    ButtonElement[0].enabled = false;
                    ButtonElement[1].sprite = mark;
                }
                break;

            case Type.Medicine:

                if (GM.Wood >= Wood && GM.Food >= Food && GM.Stone >= Stone && GM.Iron >= Iron)
                    Butt.interactable = true;
                else
                    Butt.interactable = false;
                break;
        }

    }

    private enum ResType {
        Wood,
        Food,
        Stone,
        Iron
    }

     private enum Type {
        Item,
            Medicine,
            Hat
    }
}
