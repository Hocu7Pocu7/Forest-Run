using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISwitch : MonoBehaviour
{
    CharacterMotor motor;
    Animator anim;

    [SerializeField] RectTransform WorkBenchList;
    [SerializeField] RectTransform SimpleWorkBench;
    [SerializeField] RectTransform Forge;
    [SerializeField] RectTransform MedicalWorkBench;
    [SerializeField] RectTransform HattingWorkBench;
    [SerializeField] GameObject Loading;

    Tutorial Tutor;

    bool isCamped;

    void Awake()
    {
        motor = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterMotor>();
        Tutor = GameObject.Find("Tutorial").GetComponent<Tutorial>();
        anim = GetComponent<Animator>();
        isCamped = false;
    }

    public void ToCamp()
    {
        if (!isCamped)
        {
            anim.SetTrigger("ToCamp");
            Loading.SetActive(false);
            isCamped = true;

            if (Tutor != null)
            {
                Tutor.StartCraftTT();
            }
        }
    }

   public void FromCamp()
    {
        if (isCamped)
        {
            anim.SetTrigger("FromCamp");
            isCamped = false;
            GameManager.isCamped = false;
        }
    }

    public void ToCraft()
    {
        anim.SetTrigger("ToCraft");
    }

    public void FromCraft()
    {
        anim.SetTrigger("FromCraft");
    }

    public void SwitchWorkBench()
    {
        if(SimpleWorkBench.localPosition.x == 0)
        {
            SimpleWorkBench.localPosition += Vector3.right * Screen.width * 2;
            WorkBenchList.localPosition = new Vector2(0, WorkBenchList.localPosition.y);
        }
        else
        {
            SimpleWorkBench.localPosition = new Vector2(0,SimpleWorkBench.localPosition.y);
            WorkBenchList.localPosition += Vector3.right * Screen.width * 2;
        }
    }

    public void SwitchForge()
    {
        if (Forge.localPosition.x == 0)
        {
            Forge.localPosition += Vector3.right * Screen.width * 2;
            WorkBenchList.localPosition = new Vector2(0, WorkBenchList.localPosition.y);
        }
        else
        {
            Forge.localPosition = new Vector2(0, Forge.localPosition.y);
            WorkBenchList.localPosition += Vector3.right * Screen.width * 2;
        }
    }

    public void SwitchMedicalWorkBench()
    {
        if (MedicalWorkBench.localPosition.x == 0)
        {
            MedicalWorkBench.localPosition += Vector3.right * Screen.width * 2;
            WorkBenchList.localPosition = new Vector2(0, WorkBenchList.localPosition.y);
        }
        else
        {
            MedicalWorkBench.localPosition = new Vector2(0, MedicalWorkBench.localPosition.y);
            WorkBenchList.localPosition += Vector3.right * Screen.width * 2;
        }
    }

    public void SwitchHattingWorkBench()
    {
        if (HattingWorkBench.localPosition.x == 0)
        {
            HattingWorkBench.localPosition += Vector3.right * Screen.width * 2;
            WorkBenchList.localPosition = new Vector2(0, WorkBenchList.localPosition.y);
        }
        else
        {
            HattingWorkBench.localPosition = new Vector2(0, HattingWorkBench.localPosition.y);
            WorkBenchList.localPosition += Vector3.right * Screen.width * 2;
        }
    }


}
