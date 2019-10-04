using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour {
	[SerializeField]Transform[] point;
	[SerializeField]GameObject Cube;
	[SerializeField]int StartCount;
	[SerializeField]Transform Character;
	Transform parent;
	ForestSpawner forest;


	void Awake () {
		parent = GameObject.Find ("Ground").GetComponent<Transform> ();
		forest = gameObject.GetComponent<ForestSpawner> ();

		for (int i = 0; i < StartCount; i++) {
			forest.Spawn ();
			transform.position += Vector3.forward;
		}
          
	}
	

	void Update () {
		if (Vector3.Distance (transform.position, Character.position) < StartCount) {
			for (int j = 0; j < point.Length; j++) {
				Instantiate (Cube,point[j].position-Vector3.forward*(StartCount-5),point[j].rotation,parent);
                Debug.Log(point[j].position - Vector3.forward * (StartCount - 4));
			}
			forest.Spawn ();
			transform.position += Vector3.forward;
            Debug.Log("+");
		}
	}
}
