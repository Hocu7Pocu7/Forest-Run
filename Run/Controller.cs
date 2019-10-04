using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class Controller : MonoBehaviour, IDragHandler, IBeginDragHandler, IPointerDownHandler, IPointerUpHandler {
	[SerializeField]private CharacterMotor character;
	[SerializeField]UseItem item;
    [SerializeField] float Sens;
    bool moved;
	float x,y;


	public void OnDrag(PointerEventData dat)
    {
        if (!moved)
        {
            x = dat.delta.x;
            y = dat.delta.y;


            if (Mathf.Abs(y) >= Mathf.Abs(x) && y < -5 * Sens)
                character.RemoveJump();

            if (Mathf.Abs(y) >= 0.8f*Mathf.Abs(x))
            {
                if (Mathf.Abs(y) > Sens)
                {
                    if (y > 0)
                    {
                        character.TopSwipe();
                        moved = true;
                    }
                }
            }
            else
            {
                if (Mathf.Abs(x) > Sens) {
                    if (x > 0)
                    {
                        character.RightSwipe();
                        moved = true;
                    }
                    else
                    {
                        character.LeftSwipe();
                        moved = true;
                    }
                }
            }
        }
	}

	public void OnPointerDown(PointerEventData dat){
        moved = false;
    }

	public void OnPointerUp(PointerEventData dat){
        if(!moved)
		item.Tap ();
	}

	public void OnBeginDrag(PointerEventData dat){
        
		
	}

}
