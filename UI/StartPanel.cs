using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StartPanel : MonoBehaviour, IPointerDownHandler
{
    Animator anim;
    [SerializeField]GameObject[] UI;
    [SerializeField] Tutorial Tutor;

    void Awake()
    {
        anim = GameObject.Find("MrWhite").GetComponent<Animator>();
    }

   public void OnPointerDown(PointerEventData dat)
    {
        anim.SetTrigger("Start");
        for (int i=0;i<UI.Length;i++)
        {
            UI[i].SetActive(true);
        }
        Tutor.StartTutor();
        Destroy(gameObject);
    }
}
