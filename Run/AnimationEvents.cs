using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEvents : MonoBehaviour
{

    CharacterMotor CM;
    CampManager Camp;
    UISwitch UI;

    private void Awake()
    {
        CM = GameObject.Find("Character").GetComponent<CharacterMotor>();
        Camp = GameObject.Find("Game").GetComponent<CampManager>();
        UI = GameObject.Find("UI").GetComponent<UISwitch>();
    }

    public void StartGame()
    {
        CM.StartGame();
        GameManager.isPlaying = true;
    }

    public void SpawnCamp()
    {
        Camp.SpawnCamp();
        UI.ToCamp();
    }

    public void FromCamp()
    {
        CM.Accelerate();
    }

    public void EndGamePanelShow()
    {
        Camp.gameObject.GetComponent<EndGame>().Calculating = true;
    }
}
