using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    [SerializeField] Animator Panel;
    [SerializeField] Text Distance;
    [SerializeField] Text BestDist;
    [SerializeField] Text Days;
    [SerializeField] Text Coins;
    [SerializeField] Image DeadBy;
    [SerializeField] Image ProgressBar;
    [SerializeField] Sprite[] DeadBySprite;
    [SerializeField] Color RedLight;
    [SerializeField] Color YellowLight;
    [SerializeField] Color GreenLight;
    [SerializeField] float CalcTime;

    int Dist;
    int Day;
    float timer;
   [HideInInspector] public bool Calculating;
    int DisplayDist;
    int lastBest;
    int Coin;


    private void Awake()
    {
        Calculating = false;
    }

    public void Calc(int dist, int days, string deadBy)
    {
        Debug.Log(dist);
        Panel.gameObject.SetActive(true);
        Panel.SetTrigger("Show");
        
        switch (deadBy)
        {
            case "Punch":
                DeadBy.sprite = DeadBySprite[2];
                break;

            case "Bear":
                DeadBy.sprite = DeadBySprite[1];
                break;

            case "Hunger":
                DeadBy.sprite = DeadBySprite[0];
                break;
        }
        timer = 0;
        Dist = dist;
        Day = days;
        lastBest = PlayerPrefs.GetInt("BestDistance");
        BestDist.text = lastBest.ToString() + " m";

        if (lastBest < Dist)
            PlayerPrefs.SetInt("BestDistance",Dist);

        Coin = Mathf.FloorToInt((float)Dist / 10);
        Coin = Mathf.FloorToInt(Coin + Coin*0.05f*PlayerPrefs.GetInt("Perk10"));
        PlayerPrefs.SetInt("Coins", Coin+PlayerPrefs.GetInt("Coins"));

    }

    private void Update()
    {
        if (Calculating)
        {
            if (timer < CalcTime)
            {
                timer += Time.deltaTime;
                DisplayDist = Mathf.FloorToInt((float)Dist * (timer / CalcTime));
                Distance.text = DisplayDist.ToString() + " m";
                Days.text = Mathf.FloorToInt((float)Day * timer / CalcTime).ToString();
                
                Coins.text = Mathf.FloorToInt((float)Coin * timer/CalcTime).ToString();
                
                if (DisplayDist<lastBest)
                {
                    ProgressBar.fillAmount = (float)DisplayDist / (float)lastBest;
                    if(ProgressBar.fillAmount < 0.5f)
                    {
                        ProgressBar.color = RedLight * (1 - ProgressBar.fillAmount / 0.5f) + YellowLight * (ProgressBar.fillAmount / 0.5f);
                    }
                    else
                    {
                        ProgressBar.color = YellowLight * (1 - (ProgressBar.fillAmount-0.5f) / 0.5f) + GreenLight * ((ProgressBar.fillAmount-0.5f) / 0.5f);
                    }
                }
                else
                {
                    BestDist.text = DisplayDist.ToString() + " m";
                    BestDist.color = GreenLight;
                    ProgressBar.fillAmount = 1;
                    ProgressBar.color = GreenLight;
                }

            }
            else
            {
                Distance.text = Dist.ToString() + " m";
                Days.text = Day.ToString();
                Coins.text = Coin.ToString();
                if (Dist > lastBest)
                {
                    BestDist.text = Dist.ToString() + " m";
                }
                else
                    BestDist.text = lastBest.ToString() + " m";
            }
        }
    }
}
