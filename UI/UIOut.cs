using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIOut : MonoBehaviour {
	[SerializeField]Text Food;
    [SerializeField] Text Wood;
    [SerializeField] Text Stone;
    [SerializeField] Text Iron;
    [SerializeField] Text Distance;
    [SerializeField] Text Day;
    [SerializeField] Text Health;

    [SerializeField] Image HealthBar;
    [SerializeField] RectTransform TimeVisual;

    GameManager stat;

	void Awake () {
		stat = GameObject.Find ("Game").GetComponent<GameManager> ();
        
	}
	

	void Update () {

        Food.text = stat.Food.ToString();
        Wood.text = stat.Wood.ToString();
        Stone.text = stat.Stone.ToString();
        Iron.text = stat.Iron.ToString();
        Distance.text = Mathf.Floor(stat.Dist).ToString() + "m";
        Day.text = "Day " + TimeOfDay.Day.ToString();
        Health.text = stat.Health.ToString();

        HealthBar.fillAmount = (float)stat.Health / (float)stat.MaxHealth;

        TimeVisual.rotation = Quaternion.Euler(0,0,-TimeOfDay.T/24*360);
	}
}
