using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ScrollMap : MonoBehaviour, IPointerDownHandler, IDragHandler {
	float InputDelta;
	[SerializeField]float min;
	[SerializeField]float max;
	float y;
	RectTransform map;

	void Start () {
		map = GetComponent<RectTransform> ();
		
	}
	

	public void OnPointerDown (PointerEventData dat) {
		
	}
	public void OnDrag (PointerEventData dat) {
		InputDelta = dat.delta.y;
		y = transform.localPosition.y + InputDelta;
		y = Mathf.Clamp (y,min,max);
		transform.localPosition = new Vector3 (transform.localPosition.x,y,0);
	}
}
