using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayRotation : MonoBehaviour
{
    private bool clockwiseRotation = false;

    public Rigidbody2D objectRigidbody;
    // Start is called before the first frame update
    void Start()
    {
        if(Random.Range(0, 1) == 1)
        {
            clockwiseRotation = true;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (clockwiseRotation)
        {
            objectRigidbody.rotation -= 1f;
        }
        else
        {
            objectRigidbody.rotation += 1f;
        }
    }
}
