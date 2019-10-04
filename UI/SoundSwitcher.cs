using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SoundSwitcher : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] Sprite[] sprite;

    Image Button;
    AudioSource Source;

    void Awake()
    {
        Button = GetComponent<Image>();
        Source = Camera.main.GetComponent<AudioSource>();
        if (PlayerPrefs.GetInt("Sound") == 0)
            Source.Pause();
        else
            Source.UnPause();
    }

    
    void Update()
    {
        Button.sprite = sprite[PlayerPrefs.GetInt("Sound")];
    }

    public void OnPointerDown(PointerEventData dat)
    {
        
        if (PlayerPrefs.GetInt("Sound") == 0)
        {
            PlayerPrefs.SetInt("Sound", 1);
            Source.Play();
        }
        else
        {
            PlayerPrefs.SetInt("Sound", 0);
            Source.Pause();
        }
        
    }
}
