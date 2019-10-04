using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] int Damage;
    [SerializeField] bool Iron;

    Rigidbody RB;

    private void Start()
    {
        RB = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Animal")
        {
            AnimalHealth health = other.GetComponentInChildren<AnimalHealth>();
            if (health != null)
                health.Damage(Damage);
        }


    }

    private void Update()
    {
        if(RB.velocity.magnitude>0.1f)
        {
     
                transform.rotation = Quaternion.LookRotation(RB.velocity + transform.position);
        }
    }
}
