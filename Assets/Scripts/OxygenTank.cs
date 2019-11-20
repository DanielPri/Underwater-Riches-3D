using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenTank : MonoBehaviour
{

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
        rb.detectCollisions = false;
    }

    // Update is called once per frame
    void Update()
    {
        updatePhysics();
    }

    private void updatePhysics()
    {
        if(transform.parent == null)
        {
            rb.isKinematic = false;
            rb.detectCollisions = true;

            if (transform.position.y >= 0)
            {
                transform.position = new Vector3(transform.position.x, 0, transform.position.z);
            }
        }
    }
}
