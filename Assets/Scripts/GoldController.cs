using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldController : MonoBehaviour
{
    [SerializeField]
    float lifespan = 60f;

    float timeElapsed;
    Light goldlight;

    void Start()
    {
        goldlight = GetComponentInChildren<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.parent == null)
        {
            timeElapsed += Time.deltaTime;
            if (timeElapsed > lifespan)
            {
                Destroy(gameObject);
            }
            goldlight.color = Color.Lerp(Color.yellow, Color.red, timeElapsed/lifespan);
        }
        else
        {
            GetComponentInChildren<Light>().enabled = false;
        }
    }
}
