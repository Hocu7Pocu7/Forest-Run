using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] GameObject TutorQuestion;
    [SerializeField] GameObject MovementTutor;
    [SerializeField] GameObject PickUpTutor;
    [SerializeField] GameObject CampTutor;
    [SerializeField] GameObject CraftTutor;

    GameManager GM;

    void Awake()
    {
        GM = GameObject.Find("Game").GetComponent<GameManager>();
        if (PlayerPrefs.GetInt("TutorDone") == 1)
            Destroy(gameObject);
    }

    private void Update()
    {
        if(GM.Wood==10 && GM.Stone == 10)
        {
            StartCraftTT();
            Time.timeScale = 0;
        }
    }

    public void RemoveTutor()
    {
        Destroy(gameObject);
        PlayerPrefs.SetInt("TutorDone", 1);
        Time.timeScale = 1;
    }

    public void StartTutor()
    {
        if (TutorQuestion != null)
        {
            TutorQuestion.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void StartMovementTT()
    {
        MovementTutor.SetActive(true);
        Time.timeScale = 0;
    }

    public void StartPickUpTT()
    {
        PickUpTutor.SetActive(true);
        Time.timeScale = 0;
    }

        public void StartCampTT()
        {
        CampTutor.SetActive(true);
        }

    public void StartCraftTT()
    {
        CraftTutor.SetActive(true);
        GM.Wood = 200;
        GM.Stone = 200;
        GM.Iron = 200;
        GM.Food = 200;
    }

    public void StartTime()
    {
        Time.timeScale = 1;
    }
}
