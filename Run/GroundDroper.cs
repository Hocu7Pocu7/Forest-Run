using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDroper : MonoBehaviour {
	int i;
	Quaternion first;
	Quaternion second;
	Transform character;
	[SerializeField]float dist = 1.5f;

	void Start(){
		first = Quaternion.Euler (0,10,0);
		second = Quaternion.Euler (0, -10, 0);
		character = GameObject.Find("Character").GetComponent<Transform>();
	}

	void OnTriggerEnter(Collider col){
		if (col.tag == "Ground" || col.tag == "Obj" || col.tag == "Tree" || col.tag == "Stone" || col.tag == "Animal") {
			col.gameObject.GetComponent<GroundPhysic> ().enabled = true;
			i++;
			if (i == 5) {
				if (transform.rotation == first)
					transform.rotation = second;
				else
					transform.rotation = first;
				i = 0;
			}
		}
	}

	void Update(){
		transform.position = new Vector3 (transform.position.x, transform.position.y,character.position.z-dist);
	}
}
