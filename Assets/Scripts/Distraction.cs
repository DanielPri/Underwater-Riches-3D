using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Distraction : MonoBehaviour
{
    [SerializeField] float launchForce = 10f;
    [SerializeField] float lifespan = 10f;
    [SerializeField] GameGlobal globalData;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        globalData = GameObject.Find("GameManager").GetComponent<GameGlobal>();
        rb = GetComponent<Rigidbody>();
        rb.detectCollisions = false;
        rb.AddRelativeForce(Vector3.forward * (launchForce + globalData.velocity), ForceMode.Impulse);
        StartCoroutine(enableCollisions());
        StartCoroutine(live());
    }

    IEnumerator enableCollisions()
    {
        yield return new WaitForSeconds(0.5f);
        rb.detectCollisions = true;
    }

    IEnumerator live()
    {
        yield return new WaitForSeconds(lifespan);
        Destroy(gameObject);
    }


}
