using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldController : MonoBehaviour
{
    [SerializeField]
    float lifespan = 60f;

    float timeElapsed;

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
        }
    }
}
