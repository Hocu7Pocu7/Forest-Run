using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dangers : MonoBehaviour {
	GameManager stat;
	CharacterMotor Character;
	[SerializeField]int height;
	public bool isBroken;
    Animator anim;

	void Awake () {
		stat = GameObject.Find ("Game").GetComponent<GameManager> ();
		Character = GameObject.Find ("Character").GetComponent<CharacterMotor> ();
        anim = GameObject.Find("MrWhite").GetComponent<Animator>();
	}
	

	void OnTriggerEnter (Collider col) {
		if (col.tag == "Player" && !isBroken)
        {
			
			stat.Health--;

            if (tag != "Animal")
                stat.DeadBy = "Punch";
            else
                stat.DeadBy = "Bear";

            stat.HatDamage(1);
			if (height == 1)
            {
				if (Character.line > 0 && Character.line < 4) {
					int selecter = Random.Range (0, 2);
                    if (selecter == 0)
                    {
                        Character.line--;
                        anim.SetTrigger("LeftTurn");
                    }
                    else
                    {
                        Character.line++;
                        anim.SetTrigger("RightTurn");
                      
                    }

                }
                else
                {
                    if (Character.line == 0)
                    {
                        Character.line = 1;
                        anim.SetTrigger("RightTurn");
                    }
                    else
                    {
                        Character.line = 3;
                        anim.SetTrigger("LeftTurn");
                    }
				}
			}
            else
            {
                anim.SetTrigger("Fall");
			}
		}
        if (col.tag == "Animal" && !isBroken)
        {
            Animator anim2 = col.GetComponentInChildren<Animator>();
            AnimalMovement animal = col.GetComponent<AnimalMovement>();
            if (height == 1)
            {
                if (animal.line == 0)
                {
                    animal.line++;
                    anim2.SetTrigger("RightTurn");
                }
                else
                {
                    if (animal.line == 4)
                    {
                        animal.line--;
                        anim2.SetTrigger("LeftTurn");
                    }
                    else
                    {
                        int selector = Random.Range(0, 2);
                        if (selector == 0)
                        {
                            animal.line++;
                            anim2.SetTrigger("RightTurn");
                        }
                        else
                        {
                            animal.line--;
                            anim2.SetTrigger("LeftTurn");
                        }
                    }
                }
            }
            else
            {
                anim2.SetTrigger("Jump");
            }
        }
	}
}
