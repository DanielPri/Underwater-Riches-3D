using System;
using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    protected float speed = 1f;

    void Update()
    {
        move();
    }

    private void move()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
