using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Movement : MonoBehaviour
{
    private bool stopped = false;
    private int lives = 3;
    private float iFrames = 0;

    public float rotationspeed = 0.175f;
    public bool clockwiseRotation = false;
    public bool RotationPrimer;
    public bool ClockwisePrimer;
    public Finsher finishScript;
    public GameObject[] lifeCounter;
    public Sprite brokenHeart;
    public Sprite heart;
    public Rigidbody2D objectRigidbody;
    // Start is called before the first frame update
    void Start()
    {
    }

    private void Update()
    {
        if(iFrames > 0)
        {
            iFrames -= Time.deltaTime;
        }
    }

    void FixedUpdate()
    {
        if (!Input.GetKey("space"))
        {
            if (Input.GetKey("w"))
            {
                GetComponent<Rigidbody2D>().velocity += new Vector2(0f, 0.2f);
            }
            if (Input.GetKey("s"))
            {
                GetComponent<Rigidbody2D>().velocity += new Vector2(0f, -0.2f);
            }
            if (Input.GetKey("d"))
            {
                GetComponent<Rigidbody2D>().velocity += new Vector2(0.2f, 0f);
            }
            if (Input.GetKey("a"))
            {
                GetComponent<Rigidbody2D>().velocity += new Vector2(-0.2f, 0f);
            }
        }
        if (!stopped)
        {
            if (clockwiseRotation)
            {
                objectRigidbody.rotation -= 5f * rotationspeed;
            }
            else
            {
                objectRigidbody.rotation += 5f * rotationspeed;
            }
        }
        //if(rotationspeed < 0.2f)
        //{
        //    rotationspeed = 0.2f;
        //}
        //if(rotationspeed > 7f && !finishScript.attract)
        //{
        //    rotationspeed = 7f;
        //}
        //rotationspeed += Input.mouseScrollDelta.y / 5;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall") && iFrames <= 0)
        {
            lives--;
            lifeCounter[lives].GetComponent<SpriteRenderer>().sprite = brokenHeart;
            iFrames = 1;
            if (lives == 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                //transform.position = new Vector2(0, 0);
                //lives = 3;
                //charges = 3;
                //rotationspeed = 1;
                //clockwiseRotation = originalDirection;
                //foreach(GameObject ChargeObject in chargeCounter)
                //{
                //    ChargeObject.GetComponent<SpriteRenderer>().material = activation;
                //}
                //foreach(GameObject heartObject in lifeCounter)
                //{
                //    heartObject.GetComponent<SpriteRenderer>().sprite = heart;
                //}
            }
        }
        if (collision.gameObject.CompareTag("Finnish"))
        {
            finishScript.attract = true;
            finishScript.gameObject.GetComponent<CircleCollider2D>().enabled = false;
        }
    }
}
