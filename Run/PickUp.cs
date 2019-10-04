using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour {
	GameManager Stat;
	[SerializeField]string Type;
	public int Count;

	void Start () {
		Stat = GameObject.Find ("Game").GetComponent<GameManager> ();
	}

	void OnTriggerEnter (Collider col) {
		
		if (col.tag == "Player") {

			switch(Type){
			case "Food":
				Stat.Food += Count;
				break;
			case "Wood":
				Stat.Wood += Count;
				break;
			case "Stone":
				Stat.Stone += Count;
				break;
			}
			Destroy (gameObject);
		}
	}
}
