using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    [SerializeField] float Timer;
    void Start()
    {
        Destroy(gameObject,Timer);
    }

}
