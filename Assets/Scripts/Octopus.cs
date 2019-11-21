using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Octopus : Enemy
{
    [SerializeField] float lifetime = 20f;
    float timeElapsed;

    new void Start()
    {
        base.Start();
    }

    new void Update()
    {
        base.Update();
        motionDecision();
        handleDespawn();
    }

    private void handleDespawn()
    {
        if(timeElapsed >= lifetime)
        {
            Destroy(gameObject);
        }
        timeElapsed += Time.deltaTime;
    }

    void motionDecision()
    {
        moveTowardsSomething(playerLocation);
        RotateToSomething(playerLocation);
    }
}
