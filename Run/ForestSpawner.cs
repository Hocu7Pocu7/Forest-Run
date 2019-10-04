using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestSpawner : MonoBehaviour {
	int InLineCount;
	int[] SelectedPos = new int[5];
	[SerializeField]GameObject[] prefab;
    [SerializeField] GameObject GlowWorms;
    [SerializeField] GameObject[] Batterfly;
	[SerializeField]int LargeObj;
    [SerializeField, Range(0,1)]float AnimalSpawnProbability;
	Transform forest;
	bool Check;

	void Start () {
		forest = GameObject.Find ("Forest").GetComponent<Transform> ();
	}
	

	public void Spawn () {
		InLineCount = Random.Range (1,6);
		if (InLineCount < 3) {
			for (int i = 0; i < InLineCount; i++) {
				Check = false;
				while (Check == false) {
					SelectedPos [i] = Random.Range (0, 5);
					Check = true;
					for (int j = i - 1; j >= 0; j--) {
						if (SelectedPos [i] == SelectedPos [j]) {
							Check = false;
						}
					}
				}
			}

			for (int i = 0; i < InLineCount; i++)
            {
				Quaternion R = Quaternion.Euler (0, Random.Range (0, 360), 0);
				Vector3 pos = new Vector3 (SelectedPos[i],0,transform.position.z);
                int SelectedObj = Random.Range(0, prefab.Length - LargeObj);
                if (prefab[SelectedObj].tag != "Animal")
                {
                    Instantiate(prefab[SelectedObj], pos, R, forest);
                }
                else
                {
                    int Dice = Random.Range(0, 100);
                    if(Dice<=Mathf.RoundToInt(AnimalSpawnProbability*100))
                        Instantiate(prefab[SelectedObj], pos, prefab[SelectedObj].transform.rotation, forest);
                }
                string prefabName = prefab[SelectedObj].name;
                if (prefabName == "Rocks1" || prefabName == "Stump" || prefabName=="Mushrooms")
                {
                    int dice = Random.Range(0,3);
                    if(dice == 0 && (TimeOfDay.T>18||TimeOfDay.T<4))
                    Instantiate(GlowWorms, pos, R, forest);

                    if (dice == 0 && (TimeOfDay.T > 5 && TimeOfDay.T < 17))
                        Instantiate(Batterfly[Random.Range(0,2)], pos, R, forest);
                }
            }
				
		} else {
			if(InLineCount==5){
				int decision = Random.Range(0,10);
				if (decision == 9) {
					int selected = Random.Range (prefab.Length - 1 - LargeObj, prefab.Length);
					Vector3 pos = new Vector3 (0, 0, transform.position.z);
					Instantiate (prefab [selected], pos, transform.rotation, forest);
				}
			}
		}
	}
}
