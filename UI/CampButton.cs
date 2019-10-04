using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CampButton : MonoBehaviour
{
    [SerializeField] GameObject Loading;
    [SerializeField] Text RequiredWood;
    [SerializeField] Text RequiredStone;

    CharacterMotor CM;
    GameManager GM;

    public int woodNeeded;
    public int stoneNeeded;

    bool isCamped;

    void Awake()
    {
        CM = GameObject.Find("Character").GetComponent<CharacterMotor>();
        GM = GameObject.Find("Game").GetComponent<GameManager>();

        if (PlayerPrefs.GetInt("Perk8") != 0)
        {
            woodNeeded -= PlayerPrefs.GetInt("Perk8");
            stoneNeeded -= PlayerPrefs.GetInt("Perk8");
        }
    }

    
    public void Click()
    {
        if(GM.Wood>=woodNeeded && GM.Stone >= stoneNeeded && !isCamped)
        {
            GM.Wood -= woodNeeded;
            GM.Stone -= stoneNeeded;

            Loading.SetActive(true);

            CM.SlowDown();
            isCamped = true;
        }
    }

    private void Update()
    {
        RequiredStone.text = stoneNeeded.ToString();
        if (GM.Stone < stoneNeeded)
            RequiredStone.color = Color.red;
        else
            RequiredStone.color = Color.white;

        RequiredWood.text = woodNeeded.ToString();
        if (GM.Wood < woodNeeded)
            RequiredWood.color = Color.red;
        else
            RequiredWood.color = Color.white;
    }

    public void UnCamp()
    {
        isCamped = false;
    }
}
