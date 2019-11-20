using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shark : Enemy
{
    GameObject distraction;
    float distanceFromDistraction = 999;

    new void Start()
    {
        base.Start();
    }

    new void Update()
    {
        base.Update();
        LookForDistraction();
        motionDecision();
    }

    private void LookForDistraction()
    {
        if (distraction == null)
        {
            distanceFromDistraction = 999;
            distraction = GameObject.FindGameObjectWithTag("Distraction");
            if (distraction != null)
            {
                Debug.Log("Got distracted!");
            }
        }
        else
        {
            distanceFromDistraction = (transform.position - distraction.transform.position).magnitude;
        }
    }

    void motionDecision()
    {
        if(distanceFromDistraction <= aggroDistance)
        {
            moveTowardsSomething(distraction.transform.position);
            RotateToSomething(distraction.transform.position);
        }
        else if(distanceFromPlayer <= aggroDistance)
        {
            moveTowardsSomething(playerLocation);
            RotateToSomething(playerLocation);
        }
        else
        {
            move();
        }
    }
}
