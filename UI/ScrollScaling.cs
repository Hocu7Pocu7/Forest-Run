using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollScaling : MonoBehaviour {
	RectTransform trnsfrm;
	float scale;
	public float scaling = 1;

	void Start () {
		trnsfrm = GetComponent<RectTransform> ();
	}
	

	void Update () {
		if (Mathf.Abs (trnsfrm.position.y - Screen.height / 2) <= 1000) {
			scale = 1- Mathf.Abs (trnsfrm.position.y - Screen.height / 2) / 1000;
		}
		trnsfrm.localScale = new Vector2 (scale,scale)*scaling;
	}
}
