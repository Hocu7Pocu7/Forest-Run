using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PerkInfo : MonoBehaviour
{
    [SerializeField] int StartCost;
    [SerializeField] int ID;
    [SerializeField] int MaxLevel;

    [Space(20)]
    [Header("UI Elements")]

    [SerializeField] Text CostUI;
    [SerializeField] Text ProgressUI;
    [SerializeField] Image ProgressBar;
    [SerializeField] GameObject UpgradeButton;

    int CurrentLevel;
    int Cost;


    void Awake()
    {
        UpdateUI();
    }


    void Update()
    {
        if (CostUI!=null)
        {
            if (Cost > PlayerPrefs.GetInt("Coins"))
            {
                CostUI.color = Color.red;
                UpgradeButton.SetActive(false);
            }
            else
            {
                CostUI.color = Color.white;
                UpgradeButton.SetActive(true);
            }
        }
    }

    void UpdateUI ()
    {
        CurrentLevel = PlayerPrefs.GetInt("Perk" + ID.ToString());
        ProgressUI.text = CurrentLevel.ToString() + "/" + MaxLevel.ToString();
        ProgressBar.fillAmount = (float)CurrentLevel / (float)MaxLevel;
        Cost = StartCost + StartCost * CurrentLevel;

        if (CurrentLevel < MaxLevel)
        {
            CostUI.text = Cost.ToString();
        }
        else
        {
            Destroy(CostUI.gameObject);
            Destroy(UpgradeButton);
        }
    }

    public void Upgrade()
    {
        PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins")-Cost);
        PlayerPrefs.SetInt("Perk"+ID.ToString(), PlayerPrefs.GetInt("Perk" + ID.ToString()) + 1);
        UpdateUI();
        
    }

    
}
