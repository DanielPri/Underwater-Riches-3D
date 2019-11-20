using System;
using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    protected float speed = 1f;

    [SerializeField]
    protected float aggroSpeed = 5f;

    [SerializeField]
    protected float aggroDistance = 60f;

    [SerializeField]
    protected float turnSpeed = 1000f;

    protected Rigidbody rb;
    protected GameObject player;

    protected Vector3 playerLocation;
    public float distanceFromPlayer;

    Quaternion initialRotation;

    protected void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody>();
        initialRotation = transform.rotation;
    }

    protected void Update()
    {
        if (player != null)
        {
            playerLocation = player.transform.position;
            distanceFromPlayer = (transform.position - playerLocation).magnitude;
        }
    }

    protected void move()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
        transform.rotation = Quaternion.Slerp(transform.rotation, initialRotation, turnSpeed * Time.deltaTime);
    }

    protected void moveTowardsSomething(Vector3 something)
    {
        transform.position = Vector3.MoveTowards(transform.position, something, aggroSpeed * Time.deltaTime);
    }
    
    public void RotateToPlayer()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(playerLocation - transform.position), turnSpeed * Time.deltaTime);
    }




}
