using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalHealth : MonoBehaviour
{
    [SerializeField] int MaxHealth = 3;
    [SerializeField] float HeartSpace = 0.15f;
    [SerializeField] GameObject Heart;
    [SerializeField] GameObject FoodDrop;
    [SerializeField] Animator anim;
    [SerializeField] AnimalMovement movement;
    [SerializeField] int Food;
    [SerializeField] Dangers Danger;
    [SerializeField] Collider col;
    [SerializeField] bool isBear;

    int Health;
    GameManager GM;
    GameObject[] Hearts;

    private void Awake()
    {
        GM = GameObject.Find("Game").GetComponent<GameManager>();
    }

    void Start()
    {
        Health = MaxHealth;
        Hearts = new GameObject[Health];
        for(int i=0; i<Health; i++)
        {
            Hearts[i] = Instantiate(Heart,transform.position+Vector3.right*HeartSpace*i,transform.rotation,transform);
            if (Health > 1)
            {
                if(!isBear)
                transform.localPosition += Vector3.up * HeartSpace / 2;
                else
                    transform.localPosition += Vector3.right * HeartSpace / 2;
            }
            
        }
    }


    public void Damage(int Value)
    {
        if (!isBear)
            Health -= Value;
        else
            Health -= Value / 2;


        if (Health <= 0)
        {
            anim.SetTrigger("Death");
            
            if(movement!=null)
            movement.enabled = false;

            GameObject instance = Instantiate(FoodDrop,transform.position,FoodDrop.transform.rotation);
            instance.GetComponent<PickUp>().Count = Food;
            GM.Food += Food;
            Danger.isBroken = true;
            col.enabled = false;
            Destroy(col.gameObject,10);
            Destroy(gameObject);
        }
        else
        {
            for(int i = 0; i < Value; i++)
            {
                Destroy(Hearts[Health + i]);
                transform.localPosition -= Vector3.up * HeartSpace / 2;
            }
        }
    }
}
