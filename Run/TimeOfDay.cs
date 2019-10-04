using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class TimeOfDay : MonoBehaviour
{
    [SerializeField] float TimeSpeed;
    [SerializeField] Color[] SkyColors;
    [SerializeField]Camera Sky;
    [SerializeField] Material Stars;
    [SerializeField] float SunWhitness;
    [SerializeField] [Range(0, 1)] float Darkness;
    [SerializeField] Light ContrLight;

    public static float T = 8;
    public static int Day;

    Light Sun;
   
    PostProcessVolume postProcessing;

    void Awake()
    {
        Sun = GetComponent<Light>();
        
        T = 0f;
        Day = 0;
    }

 
    void Update()
    {
        if(GameManager.isPlaying)
        T += Time.deltaTime * TimeSpeed;
        if (T >= 24) {
            T = 0;
            Day++;
        }
        SetSkyColor(T);
       
    }

    void SetSkyColor(float Time) {
        float PartOfDay = Mathf.Floor(Time / 6)*6;
        float Percent = (Time - PartOfDay) / 6;
        Color CurrentColor;

        if (PartOfDay == 0)
        {
            Color StarColor = new Color(1,1,1,1-Percent);
            Stars.SetColor("_Tint", StarColor);
            
            //Sun.intensity = 0.2f + Percent / 1.25f;
            Sun.intensity = 0.2f + 1.3f*Percent;
            ContrLight.intensity = 0.25f * Percent;

        }
        
        if (PartOfDay == 18)
        {
            Color StarColor = new Color(1, 1, 1,Percent);
            Stars.SetColor("_Tint", StarColor);
            CurrentColor = SkyColors[(int)(PartOfDay / 6)] * (1 - Percent) + SkyColors[0] * Percent;
            //Sun.intensity = 1 - Percent / 1.25f;
            Sun.intensity = 1.5f - Percent*1.3f;
            ContrLight.intensity = 0.25f - Percent*0.25f;
        }
        else {
            CurrentColor = SkyColors[(int)(PartOfDay / 6)] * (1 - Percent) + SkyColors[(int)(PartOfDay / 6 + 1)] * Percent;
            
        }

        Sky.backgroundColor = CurrentColor;
            Sun.color = Color.white + CurrentColor*SunWhitness;
       
    }
}
