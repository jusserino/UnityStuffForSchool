using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightStartup : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().angularVelocity = new Vector3(0f, 0.5f, 0f);
    }
}
