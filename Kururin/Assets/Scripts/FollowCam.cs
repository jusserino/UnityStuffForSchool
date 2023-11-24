using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    public GameObject cameraObject;
    private float xOffset;
    private float yOffset;
    // Start is called before the first frame update
    void Start()
    {
        xOffset = transform.position.x;
        yOffset = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(cameraObject.transform.position.x + xOffset, cameraObject.transform.position.y + yOffset);
    }
}
