using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TextureMovement : MonoBehaviour {
    [SerializeField] string Tex = "_NormalMap";

    Renderer Rend;
    [SerializeField] float speed;
	// Use this for initialization
	void Start () {
        Rend = GetComponent<Renderer>();
	}

    // Update is called once per frame
   private void Update() {
        Rend.material.SetTextureOffset(Tex, Rend.material.GetTextureOffset(Tex) + Vector2.right * speed * Time.deltaTime);
    }
}
