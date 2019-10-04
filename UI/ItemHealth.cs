using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemHealth : MonoBehaviour
{
    [SerializeField]Image ProgressBar;
    [SerializeField] Image img;
    [SerializeField] Sprite[] sprites;

    void Start()
    {
        
    }

    public void SetItem(int ID)
    {
       img.sprite = sprites[ID - 1];
    }

    public void UpdateUI(int Value, int MaxValue)
    {
        ProgressBar.fillAmount = (float)Value / (float)MaxValue;
    }

    public void Switch()
    {
        if (gameObject.activeSelf)
            gameObject.SetActive(false);
        else
            gameObject.SetActive(true);
    }
}
