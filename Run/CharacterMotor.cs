using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMotor : MonoBehaviour {
    CharacterController Controller;
    Vector3 Direction;
    [SerializeField] float Gravity;
    [SerializeField] float StartSpeed;
    [SerializeField] float speedMult;
    [SerializeField] float JumpHeight;
    [SerializeField] float JumpSpeed;
    [SerializeField] float AirTime;
    [SerializeField] Animator anim;

	public int line;
	bool Jump;
	bool inMove;
	float t;
    bool Stopping;
    bool camped;
    float JumpTimer;
    float speed;
    bool isStarted;
    float SpeedFrom;
    float JumpProgress;
    float JumpCurrentSpeed;
    bool ToCampAnimIsStarted;

	void Awake () {
		Controller = gameObject.GetComponent<CharacterController> ();
        speed = StartSpeed;
		line = 2;
        camped = false;
        isStarted = false;
	}
	

	void Update () {
        if (isStarted)
        {
            if (!Stopping && !camped)
            {
                if (speed <= StartSpeed)
                    speed = Mathf.Lerp(0, StartSpeed, 3);

                speed += Time.deltaTime * speedMult;
            }
            else
            {
                
                if (SpeedFrom == 0)
                    SpeedFrom = speed;
                else
                {
                    speed -= Time.deltaTime;

                    if (anim.speed > 0.5f)
                        anim.speed = speed / SpeedFrom;

                    if (speed / SpeedFrom < 0.5f)
                    {
                        anim.speed = Mathf.Lerp(0.5f, 1f, Time.deltaTime * 30);
                        if (!ToCampAnimIsStarted)
                        {
                            anim.SetTrigger("ToCamp");
                            speed = 0;
                            ToCampAnimIsStarted = true;
                        }
                    }

                    if (speed < 0)
                    {
                        speed = 0;
                        GetCamped();
                    }
                }
            }

            if (Controller.isGrounded || Jump) {
                Direction = Vector3.forward * Time.deltaTime * speed;
            }
            else
            {
                Direction += Vector3.down * Time.deltaTime * Gravity;
            }
            if (t <= 0 && Time.timeScale!=0)
                Controller.Move(Direction);

            if (line != transform.position.x) {
                Vector3 newPos = new Vector3(line, transform.position.y, transform.position.z);
                transform.position = Vector3.MoveTowards(transform.position, newPos, Time.deltaTime * speed);
            }

            if (Jump) {
                Vector3 JumpVector = new Vector3(transform.position.x, JumpHeight, transform.position.z);
                JumpProgress = (JumpHeight - transform.position.y) / JumpHeight;
                JumpCurrentSpeed = JumpSpeed * (JumpProgress);
                if(JumpCurrentSpeed>0.5f*JumpSpeed)
                transform.position = Vector3.MoveTowards(transform.position, JumpVector, JumpCurrentSpeed * Time.deltaTime);
                else
                    transform.position = Vector3.MoveTowards(transform.position, JumpVector, Time.deltaTime * JumpSpeed *0.5f);

                if (transform.position == JumpVector)
                    JumpTimer += Time.deltaTime;
                if (JumpTimer >= AirTime)
                {
                    RemoveJump();
                }
            }
        }
	}

	public void LeftSwipe(){
		if (line > 0)
			line--;
			inMove = true;

	}
	public void RightSwipe(){
		if (line < 4)
			line++;
			inMove = true;
	}
	public void TopSwipe(){
		if (transform.position.y<0.1f && !camped) {
			Jump = true;
            anim.SetBool("Jump", true);
        }
		
	}

    public void SlowDown()
    {
        if (speed > 0)
            Stopping = true;
    }

    public void Accelerate()
    {
        if (speed == 0 && camped)
        {
            camped = false;
            ToCampAnimIsStarted = false;
        }
    }

    public void GetCamped()
    {
            if (speed <= 0 && Stopping)
        {
            camped = true;
            GameManager.isCamped = true;
            Stopping = false;
            anim.speed = 1;
            SpeedFrom = 0;
        } 
        
    }
    

    public float GetSpeed()
    {
        return speed;
    }

    public void RemoveJump()
    {
        JumpTimer = 0;
        Jump = false;
        anim.SetBool("Jump",false);
    }

    public void StartGame()
    {
        isStarted = true;
    }

    public void Death()
    {
        speed = 0;
        this.enabled = false;
    }
}
