using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseSwithcer : MonoBehaviour
{
    [SerializeField] GameObject[] OnPauseElements;
    [SerializeField] FromPauseStarter starter;
    [SerializeField] GameObject PauseButton;

    public void Play()
    {
        for(int i =0;i<OnPauseElements.Length;i++)
        {
            OnPauseElements[i].SetActive(false);
        }
        PauseButton.SetActive(true);
        starter.Play();
        
    }

    public void Pause()
    {
        for (int i = 0; i < OnPauseElements.Length; i++)
        {
            OnPauseElements[i].SetActive(true);
        }
        PauseButton.SetActive(false);
        Time.timeScale = 0;
    }

    void OnApplicationFocus(bool hasFocus)
    {
        if (!hasFocus)
            Pause();
    }

    void OnApplicationPause(bool pauseStatus)
    {
        if(pauseStatus)
        Pause();
    }
}
