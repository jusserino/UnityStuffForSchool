using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reverse : MonoBehaviour
{
    public bool clockwiseRotator;
    public Movement movementScript;
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Spring"))
        {
            movementScript.clockwiseRotation = clockwiseRotator;
        }
    }
}
