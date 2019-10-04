using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalMovement : MonoBehaviour
{
    [SerializeField] float targetDist = 3;
    [SerializeField] float BoostValue;
    [SerializeField] float BrakeValue;
    [SerializeField] float RayLength;
    [SerializeField] Transform Raycaster;
    [SerializeField] float TimeToKill;
    [SerializeField] Animator anim;

    Transform Player;
    CharacterMotor CM;
    float PlayerZ, Z;
    float Speed;
    Vector3 movement;
    float timer;

    public int line;


    void Start()
    {

        Player = GameObject.FindGameObjectWithTag("Player").transform;
        CM = Player.GetComponent<CharacterMotor>();
        line = Mathf.RoundToInt(transform.position.x);
        timer = 0;
        transform.rotation = Quaternion.Euler(Vector3.zero);
    }

    void FixedUpdate()
    {
        PlayerZ = Player.position.z;
        Z = transform.position.z;

        LineMove();

        if (timer < TimeToKill)
        {
                if (Mathf.Round(Z) > Mathf.Round(PlayerZ + targetDist))
                {
                    //Speed = CM.GetSpeed() - BrakeValue;
                
                }
                else
                {
                    Speed = CM.GetSpeed();
                anim.SetBool("Run", true);
                timer += Time.deltaTime;
               
            }
            
        }
        else
        {
            Speed = CM.GetSpeed() + BoostValue;
        }
        movement = Vector3.forward * Speed * Time.deltaTime;
        transform.Translate(movement);
    }


    void LineMove()
    {
        if (transform.position.x != line)
        {
            Vector3 newPos = new Vector3(line, transform.position.y, transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, newPos, Time.deltaTime * Speed/2);
        }
    }

}
