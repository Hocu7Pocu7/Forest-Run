using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Break : MonoBehaviour {
	[SerializeField]int Health;
	[SerializeField]Transform AnimatedTransform;
	[SerializeField]MovementType mvmntType;
	[SerializeField]ResourceType ResType;
	[SerializeField]int ResCount;
    [SerializeField]Transform PartsPos;
    [SerializeField] GameObject Parts;
    [SerializeField] GameObject Model;
	Dangers Danger;
	GameManager GM;


    private void Awake()
    {
        if (ResType == ResourceType.Iron && PlayerPrefs.GetInt("Perk9") != 0)
            ResCount += PlayerPrefs.GetInt("Perk9");
    }

    void Start (){
		Danger = GetComponent<Dangers> ();
		GM = GameObject.Find ("Game").GetComponent<GameManager> ();
	}
	

	void Update () {
		if (Health <= 0) {

			switch(mvmntType){
			case MovementType.Rotate:
				Quaternion Q = Quaternion.Euler (0, -90, 0);
					AnimatedTransform.rotation = Quaternion.Lerp (AnimatedTransform.rotation, Q,Time.deltaTime*3);
				break;

			case MovementType.Translate:
				if (AnimatedTransform.position.y > 10)
					AnimatedTransform.position -= Vector3.down;
				break;
			}
		}
	}

	public void Damge(int Value){
		Health-=Value;
		if(Health<=0)
		Death ();
	}

	void Death(){
		switch(ResType){
		case ResourceType.Food:
			GM.Food += ResCount;
			break;

		case ResourceType.Stone:
			GM.Stone += ResCount;
			break;

		case ResourceType.Wood:
			GM.Wood += ResCount;
			break;

            case ResourceType.Iron:
                GM.Iron += ResCount;
                break;
        }
		Danger.isBroken = true;
        if(Parts!=null && PartsPos!=null)
            Instantiate(Parts,PartsPos.position,PartsPos.rotation);

        if (Model != null)
            Destroy(Model);
	}

	public enum MovementType{
		Rotate,
		Translate
	}

	public enum ResourceType{
		Wood,
		Food,
		Stone,
        Iron
	}
}
