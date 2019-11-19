using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shark : Enemy
{
    [SerializeField]
    float sharkSpeed = 5f;

    void Start()
    {
        speed = sharkSpeed;
    }
}
