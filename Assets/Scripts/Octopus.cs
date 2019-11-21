using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Octopus : Enemy
{
    new void Start()
    {
        base.Start();
    }

    new void Update()
    {
        base.Update();
        motionDecision();
    }

    void motionDecision()
    {
        moveTowardsSomething(playerLocation);
        RotateToSomething(playerLocation);
    }
}
