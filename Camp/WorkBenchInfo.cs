using UnityEngine;
using UnityEngine.UI;

public class WorkBenchInfo : MonoBehaviour
{
    public int Wood;
    public int Food;
    public int Stone;
    public int Iron;

    [SerializeField] int ID;
    [SerializeField] Button BenchButton;
    [SerializeField] RectTransform TeasingPanel;
    [SerializeField] Image Preview;

    CampManager CM;
    GameManager GM;
    Button Butt;
    Vector2 TeasingPos;

    Image[] ButtonElement;

    void Awake()
    {
        CM = GameObject.Find("Game").GetComponent<CampManager>();
        GM = CM.gameObject.GetComponent<GameManager>();
        Butt = GetComponentInChildren<Button>();
        ButtonElement = Butt.gameObject.GetComponentsInChildren<Image>();
        TeasingPos = TeasingPanel.localPosition;
    }

    public void BuildThis()
    {
        CM.BuildWorkBench(ID,Wood,Food,Stone,Iron);
        Preview.color = Color.white;
    }
    
    void Update()
    {
        if (CM.WorkBenchs[ID] != 1)
        {
            BenchButton.interactable = false;
            ButtonElement[0].enabled = true;
            ButtonElement[1].enabled = true;
            TeasingPanel.localPosition = TeasingPos;

            if (GM.Wood >= Wood && GM.Food >= Food && GM.Stone >= Stone && GM.Iron >= Iron)
                Butt.interactable = true;
            else
                Butt.interactable = false;

        }
        else
        {
            Butt.interactable = false;
            ButtonElement[0].enabled = false;
            ButtonElement[1].enabled = false;
            BenchButton.interactable = true;
            TeasingPanel.localPosition = TeasingPos + Vector2.right * Screen.width * 10;
        }
    }
}
