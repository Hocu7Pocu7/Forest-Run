using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlingLine : MonoBehaviour
{
    [SerializeField] Transform[] points;

    LineRenderer LR;

    void Start()
    {
        LR = GetComponent<LineRenderer>();
    }

    
    void Update()
    {
        if (gameObject.activeSelf)
        {
            LR.SetPosition(0,points[0].position);
            LR.SetPosition(1, points[1].position);
            LR.SetPosition(2, points[2].position);
        }
    }
}
