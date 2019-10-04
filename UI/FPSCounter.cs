using UnityEngine;

public class FPSCounter : MonoBehaviour
{
    GUIStyle style = new GUIStyle();
    int accumulator = 0;
    int counter = 0;
    float timer = 0f;
    float GameTime;
    int h, m, s;

    void Start()
    {
        style.normal.textColor = Color.white;
        style.fontSize = 20;
        style.fontStyle = FontStyle.Bold;
        GameTime = PlayerPrefs.GetFloat("GameTime");
    }

    void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 20), "Beta 0.1", style);
        GUI.Label(new Rect(100, 10, 100, 20), "FPS: " + counter, style);
        GUI.Label(new Rect(180, 10, 100, 20), "Time in game: " + h.ToString() + ":" + m.ToString() + ":" + s.ToString(), style);
    }

    void Update()
    {
        GameTime += Time.deltaTime;
        h = Mathf.FloorToInt(GameTime / 3600);
        m = Mathf.FloorToInt(GameTime / 60)-h*60;
        s = Mathf.FloorToInt(GameTime) - h * 3600 - m * 60;

        accumulator++;
        timer += Time.deltaTime;

        if (timer >= 1)
        {
            timer = 0;
            counter = accumulator;
            accumulator = 0;
        }
    }

    void OnApplicationFocus(bool hasFocus)
    {
        if (!hasFocus)
            PlayerPrefs.SetFloat("GameTime",GameTime);
    }

    void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus)
            PlayerPrefs.SetFloat("GameTime", GameTime);
    }
}