using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FramePlayer : MonoBehaviour
{
    public float frameRate;
    public Sprite[] frames;

    public float frameTime;
    private int frame;
    // Start is called before the first frame update
    void Start()
    {
        frameRate = 1000 / frameRate;
    }

    // Update is called once per frame
    void Update()
    {
        frameTime += Time.deltaTime * 1000;
        if (frameTime >= frameRate)
        {
            frameTime -= frameRate;
            frame++;
        }
        if (frame > frames.Length - 1)
        {
            frame = 0;
        }
        GetComponent<SpriteRenderer>().sprite = frames[frame];
    }
}
