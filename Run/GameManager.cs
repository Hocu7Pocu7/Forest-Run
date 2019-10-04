using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    [Header("Stats")]
    public int Food;
    public int Wood;
    public int Stone;
    public int Iron;
    public int Health;

    [Space(20)]
    [Header("Other")]
    [SerializeField] float EatingTime;
                     public float HungerTime;
    [SerializeField] int EatingValue;
    [SerializeField] int EatingProgression;
                     public int EatingProgressionTime;
    [SerializeField] GameObject[] Hats;
    [SerializeField] GameObject[] RigidHats;

	Transform Character;

    [HideInInspector] public string DeadBy;
    [HideInInspector] public static bool isCamped;
	[HideInInspector] public float Dist;
    [HideInInspector] public static bool isPlaying;
    [HideInInspector] public int MaxHealth;

    [HideInInspector]public int HatID;
    int HatHealth;


    private void Awake()
    {
        MaxHealth = 5;
        Health = MaxHealth;
        Character = GameObject.Find("Character").transform;
        Time.timeScale = 1;
        EatingProgressionTime = Mathf.RoundToInt(EatingProgressionTime + EatingProgressionTime * 0.02f * PlayerPrefs.GetInt("Perk1"));
        HungerTime = Mathf.RoundToInt(HungerTime + HungerTime*0.05f*PlayerPrefs.GetInt("Perk2"));
       
    }

    void Start () {
        StartCoroutine(Eating());
        StartCoroutine(Hunger());
        StartCoroutine(IncreaseEating());
    }
	

	void Update () {
        Dist = Character.position.z;
        if (Health == 0 && isPlaying)
        {
            Death();
        }
	}

    public void SetHat(int ID)
    {
        HatID = ID;

        
            for (int i = 0; i < Hats.Length; i++)
                Hats[i].SetActive(false);

            if(ID!=0)
            Hats[ID-1].SetActive(true);


        switch (ID)
        {
            case 0:
                MaxHealth = 5;
                HatHealth = 0;
                break;
            case 1:
                MaxHealth = 7;
                HatHealth = 5;
                break;
            case 2:
                MaxHealth = 8;
                HatHealth = 10;
                break;
            case 3:
                MaxHealth = 10;
                HatHealth = 15;
                break;
        }
        if(PlayerPrefs.GetInt("Perk6")!=0 && ID!=0)
            HatHealth = Mathf.FloorToInt(HatHealth + HatHealth*0.2f*PlayerPrefs.GetInt("Perk6"));

        if (Health > MaxHealth)
            Health = MaxHealth;
    }

    public void HatDamage(int Value)
    {
        HatHealth -= Value;
        if(HatHealth<=0 && HatID!=0)
        {
            Instantiate(RigidHats[HatID-1],Hats[HatID-1].transform.position, Hats[HatID - 1].transform.rotation);
            SetHat(0);
        }
    }

    public void Heal(int Value)
    {
        if (Health + Value < MaxHealth)
            Health += Value;
        else
            Health = MaxHealth;
    }

    void Death()
    {
        isPlaying = false;
        GameObject.Find("Game").GetComponent<EndGame>().Calc((int)Dist,TimeOfDay.Day,DeadBy);
        Character.GetComponent<CharacterMotor>().Death();
    }

    IEnumerator Eating()
    {
        while (true)
        {
            yield return new WaitForSeconds(EatingTime);
            if (isPlaying && !isCamped) {
                if(Food>0)
                {
                    Food -= EatingValue;
                }
                else
                {
                    if (Wood >= 11 - PlayerPrefs.GetInt("Perk3") && PlayerPrefs.GetInt("Perk3") != 0)
                        Wood -= 11 - PlayerPrefs.GetInt("Perk3");
                    
                }
                if (Food < 0)
                    Food = 0;
            }
            
        }
    }

    IEnumerator Hunger()
    {
        while (true)
        {
            yield return new WaitForSeconds(HungerTime);
            if (Food == 0 && (Wood<11-PlayerPrefs.GetInt("Perk3") || PlayerPrefs.GetInt("Perk3")==0)  && isPlaying && !isCamped)
            {
                Health--;
                DeadBy = "Hunger";
            }
        }
        
    }

    IEnumerator IncreaseEating()
    {
        while(true)
        {
            yield return new WaitForSeconds(EatingProgressionTime);
            if (isPlaying && !isCamped)
            {
                EatingValue += EatingProgression;

            }
        }
    }

  
}
