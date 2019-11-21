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
    protected float turnSpeed = 1f;

    [SerializeField]
    protected GameGlobal globalData;

    protected Rigidbody rb;
    protected GameObject player;

    protected Vector3 playerLocation;
    public float distanceFromPlayer;

    protected float levelSpeed = 0f;
    protected float elapsedLevelTime = 0f;

    Quaternion initialRotation;

    protected void Start()
    {
        globalData = GameObject.Find("GameManager").GetComponent<GameGlobal>();
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody>();
        initialRotation = transform.rotation;
        varySpeed();
        elapsedLevelTime = Time.deltaTime - (globalData.levelDuration * (globalData.level - 1));
    }

    protected void Update()
    {
        if (player != null)
        {
            playerLocation = player.transform.position;
            distanceFromPlayer = (transform.position - playerLocation).magnitude;
        }
        else
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
        handleLevelChange();
        dontFly();
    }

    private void dontFly()
    {
        if(transform.position.y > 0f)
        {
            transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        }
    }

    private void handleLevelChange()
    {
        if (elapsedLevelTime >= globalData.levelDuration - 10f)
        {
            Debug.Log("Increasing speed!");
            levelSpeed++;
            elapsedLevelTime = 0f;
        }
        elapsedLevelTime += Time.deltaTime;
    }

    private void varySpeed()
    {
        speed *= UnityEngine.Random.Range(0.8f, 1.2f);
        aggroSpeed *= UnityEngine.Random.Range(0.8f, 1.2f);
    }

    protected void move()
    {
        transform.Translate(Vector3.left * (speed + levelSpeed )* Time.deltaTime, Space.World);
        transform.rotation = Quaternion.Slerp(transform.rotation, initialRotation, turnSpeed * Time.deltaTime);
    }

    protected void moveTowardsSomething(Vector3 something)
    {
        transform.position = Vector3.MoveTowards(transform.position, something, (aggroSpeed + levelSpeed) * Time.deltaTime);
    }
    
    public void RotateToSomething(Vector3 somethingLocation)
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(somethingLocation - transform.position), turnSpeed * Time.deltaTime);
    }




}
