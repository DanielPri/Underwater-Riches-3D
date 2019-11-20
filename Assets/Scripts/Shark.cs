using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shark : Enemy
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
        if(distanceFromPlayer <= aggroDistance)
        {
            moveTowardsSomething(playerLocation);
            RotateToPlayer();
        }
        else
        {
            move();
        }
    }
}
