using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FromPauseStarter : MonoBehaviour
{
    Text text;
    int number;
    Button button;

    void Start()
    {
     
    }


    public void Play()
    {
        number = 3;
        text = GetComponent<Text>();
        text.gameObject.SetActive(true);
        button = GameObject.Find("PauseButton").GetComponent<Button>();
        button.interactable = false;
        StartCoroutine(Tik());
    }

    IEnumerator Tik()
    {
        do
        {
            text.text = number.ToString();
            Debug.Log(number);
            yield return new WaitForSecondsRealtime(1);
            number--;

            
        }
        while (number>0);
        text.gameObject.SetActive(false);
        button.interactable = true;
        Time.timeScale = 1;
    }
}
