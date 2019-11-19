using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float mouseSensitivity = 1f;
    [SerializeField] float forceAmount = 1f;
    [SerializeField] float rotateAmount = 1f;

    // Camera Fields
    // used https://answers.unity.com/questions/29741/mouse-look-script.html
    enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
    RotationAxes axes = RotationAxes.MouseXAndY;
    float rotationX = 0f;
    float rotationY = 0f;
    float minimumX = -360F;
    float maximumX = 360F;
    float minimumY = -60F;
    float maximumY = 60F;
    Quaternion originalRotation;

    // movement fields
    Rigidbody rb;
    bool canMove = true;
    GameObject fan;
    GameObject recepticle;

    // Start is called before the first frame update
    void Start()
    {
        originalRotation = Quaternion.identity;
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        Physics.gravity = new Vector3(0f, -1f, 0f);
        fan = GameObject.Find("SpinController");
        recepticle = GameObject.Find("Recepticle");
    }
    
    // Update is called once per frame
    void Update()
    {
        lookAround();
        MoveInDirection();
        AnimateFan();
        Debug.Log(canMove);
    }

    private void AnimateFan()
    {
        if (fan != null)
        {
            float speed = rb.velocity.magnitude;
            fan.transform.Rotate(0, -rotateAmount * speed * Time.deltaTime, 0, Space.Self);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.tag == "GameZone")
        {
            Physics.gravity = new Vector3(0f, -9.8f, 0f);
            rb.drag = 0.5f;
            canMove = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "GameZone")
        {
            Physics.gravity = new Vector3(0f, -1f, 0f);
            rb.drag = 1f;
            canMove = true;
        }
    }

    void OnCollisionEnter (Collision collision)
    {
        if(collision.gameObject.tag == "Gold")
        {
            var goldpiece = collision.gameObject;
            goldpiece.transform.SetParent(this.transform);
            goldpiece.transform.localPosition = recepticle.transform.localPosition;

            var goldpieceRb = goldpiece.GetComponent<Rigidbody>();
            goldpieceRb.isKinematic = true;
            goldpieceRb.detectCollisions = false;
        }
    }

    private void MoveInDirection()
    {
        if (Input.GetButtonDown("Fire1") && canMove) { 
            Vector3 thrust = forceAmount * transform.forward;
            rb.AddForce(thrust, ForceMode.Impulse);
        }
    }

    private void lookAround()
    {
        if (axes == RotationAxes.MouseXAndY)
        {
            rotationX += Input.GetAxis("Mouse X") * mouseSensitivity;
            rotationY += Input.GetAxis("Mouse Y") * mouseSensitivity;
            rotationX = ClampAngle(rotationX, minimumX, maximumX);
            rotationY = ClampAngle(rotationY, minimumY, maximumY);
            Quaternion xQuaternion = Quaternion.AngleAxis(rotationX, Vector3.up);
            Quaternion yQuaternion = Quaternion.AngleAxis(rotationY, -Vector3.right);

            transform.localRotation = originalRotation * xQuaternion * yQuaternion;

        }
        else if (axes == RotationAxes.MouseX)
        {
            rotationX += Input.GetAxis("Mouse X") * mouseSensitivity;
            rotationX = ClampAngle(rotationX, minimumX, maximumX);
            Quaternion xQuaternion = Quaternion.AngleAxis(rotationX, Vector3.up);
            transform.localRotation = originalRotation * xQuaternion;
        }
        else
        {
            rotationY += Input.GetAxis("Mouse Y") * mouseSensitivity;
            rotationY = ClampAngle(rotationY, minimumY, maximumY);
            Quaternion yQuaternion = Quaternion.AngleAxis(-rotationY, Vector3.right);
            transform.localRotation = originalRotation * yQuaternion;
        }
    }

    public static float ClampAngle(float angle, float min, float max)
    {
        if (angle <= -360f)
         angle += 360f;
        if (angle >= 360f)
         angle -= 360f;
        return Mathf.Clamp(angle, min, max);
    }


}
