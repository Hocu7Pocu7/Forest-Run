using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terminator : MonoBehaviour
{
    [SerializeField] string[] Tags;

    bool Checker;
    void Start()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        Checker = false;
        
        for (int i=0;i<Tags.Length;i++)
        {
            Debug.Log(Tags[i]+" "+other.tag);
            if (Tags[i] == other.tag)
            {
                Checker = true;
                break;
            }
        }

        if (Checker)
        {
            Destroy(other.gameObject);
        }
    }
}
