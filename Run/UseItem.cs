using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseItem : MonoBehaviour {
    public Item Itm;
    [SerializeField] Transform rayCaster;
    [SerializeField] Animator anim;
    [SerializeField] GameObject[] Items;
    [SerializeField] GameObject Rock;
    [SerializeField] Transform SlingShotTransform;
    [SerializeField] GameObject IronSpire;
    [SerializeField] GameObject StoneSpire;
    [SerializeField] Transform SpirePos;
    [SerializeField] float ShotPower;
    [SerializeField] ItemHealth UIOut;

    CampManager CM;
    int maxHealth;
    int health;
    int id;
    float CoolDown;

    


	void Awake () {
        CM = GameObject.Find("Game").GetComponent<CampManager>();
	}

    public void SetItem(int ID)
    {
        switch (ID)
        {
            case 0:
                Itm = Item.Empty;
                
                break;
            case 1:
                Itm = Item.Axe;
                maxHealth = 15;
                break;
            case 2:
                Itm = Item.Axe;
                maxHealth = 25;
                break;
            case 3:
                Itm = Item.PickAxe;
                maxHealth = 10;
                break;
            case 4:
                Itm = Item.PickAxe;
                maxHealth = 20;
                break;
            case 5:
                Itm = Item.SpireStone;
                maxHealth = 3;
                break;
            case 6:
                Itm = Item.SpireIron;
                maxHealth = 5;
                break;
            case 7:
                Itm = Item.Slingshot;
                maxHealth = 10;
                break;
            case 8:
                Itm = Item.Sword;
                maxHealth = 20;
                break;
        }

        if((ID == 1 || ID == 3 || ID==5 || ID == 7) && PlayerPrefs.GetInt("Perk4") != 0)
        {
                maxHealth = Mathf.FloorToInt(maxHealth + maxHealth*0.1f*PlayerPrefs.GetInt("Perk4"));
        }
        if ((ID == 2 || ID == 4 || ID == 6 || ID == 8) && PlayerPrefs.GetInt("Perk5") != 0)
        {
            maxHealth = Mathf.FloorToInt(maxHealth + maxHealth * 0.1f * PlayerPrefs.GetInt("Perk5"));
        }
        health = maxHealth;
        
        id = ID-1;
        for (int i= 0; i<Items.Length;i++)
        {
            Items[i].SetActive(false);
        }

        if (ID != 0)
        {
            UIOut.SetItem(ID);
            UIOut.Switch();
            UIOut.UpdateUI(health,maxHealth);
            Items[id].SetActive(true);
            Debug.Log(id);
            Debug.Log(Items[id].activeSelf);
        }
    }

	void Update () {
        if (CoolDown > 0)
            CoolDown -= Time.deltaTime;
	}

	public void Tap(){
        if (CoolDown <= 0 && !GameManager.isCamped)
        {

            RaycastHit hit;
            switch (Itm)
            {
                case Item.Axe:
                    anim.SetTrigger("Axe");
                    if (Physics.Raycast(rayCaster.position, rayCaster.position + Vector3.forward, out hit, 2))
                    {
                        if (hit.collider.tag == "Tree")
                        {
                            hit.collider.gameObject.GetComponent<Break>().Damge(1);
                            health--;
                        }

                    }
                    CoolDown = 0.2f;
                    break;

                case Item.PickAxe:
                    anim.SetTrigger("PickAxe");
                    if (Physics.Raycast(rayCaster.position, rayCaster.position + Vector3.forward, out hit, 2))
                    {
                        if (hit.collider.tag == "Stone")
                        {
                            hit.collider.gameObject.GetComponent<Break>().Damge(1);
                            health--;
                        }

                    }
                    CoolDown = 0.2f;
                    break;

                case Item.Slingshot:
                    anim.SetTrigger("SlingShot");
                    GameObject instance = Instantiate(Rock, SlingShotTransform.position, SlingShotTransform.rotation);
                    instance.GetComponent<Rigidbody>().AddForce(Vector3.forward * ShotPower, ForceMode.Impulse);
                    Debug.Log(instance.name);
                    health--;
                    CoolDown = 0.7f;
                    break;

                case Item.SpireStone:
                    anim.SetTrigger("Spire");
                    health--;
                    CoolDown = 1f;
                    GameObject instance1 = Instantiate(StoneSpire, SpirePos.position, StoneSpire.transform.rotation);
                    instance1.GetComponent<Rigidbody>().AddForce(Vector3.forward * ShotPower, ForceMode.Impulse);
                    break;

                case Item.SpireIron:
                    anim.SetTrigger("Spire");
                    health--;
                    CoolDown = 1f;
                    GameObject instance2 = Instantiate(IronSpire,SpirePos.position,IronSpire.transform.rotation);
                    instance2.GetComponent<Rigidbody>().AddForce(Vector3.forward* ShotPower, ForceMode.Impulse);
                    break;

                case Item.Sword:
                    anim.SetTrigger("Sword");
                    if (Physics.Raycast(rayCaster.position, rayCaster.position + Vector3.forward, out hit, 2))
                    {
                        if (hit.collider.tag == "Animal")
                        {
                            AnimalHealth AnimalHealth = hit.collider.GetComponentInChildren<AnimalHealth>();
                            if (AnimalHealth != null)
                                AnimalHealth.Damage(5);
                            
                        }

                        if (hit.collider.tag == "Tree")
                            hit.collider.gameObject.GetComponent<Break>().Damge(1);

                        health--;
                    }
                    CoolDown = 0.5f;
                    break;

            }
            
            UIOut.UpdateUI(health,maxHealth);
            if (health <= 0)
            {
                if (Itm != Item.Empty)
                    UIOut.Switch();
                CM.CurrentItem = 0;
                Itm = Item.Empty;
                Items[id].SetActive(false);
            }
        }
	}

	public enum Item{
		Axe,
        PickAxe,
		Slingshot,
        SpireStone,
        SpireIron,
        Sword,
        Empty
	}
}
