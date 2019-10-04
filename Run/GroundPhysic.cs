using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundPhysic : MonoBehaviour {
	[SerializeField]float Gravity;

	void Start () {
		
	}
	

	void Update () {
		transform.Translate (0, -Time.deltaTime * Gravity, 0);
		if (transform.position.y < -15)
			Destroy (gameObject);
	}
}
