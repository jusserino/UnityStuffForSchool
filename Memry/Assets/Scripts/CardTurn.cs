using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardTurn : MonoBehaviour
{
    private int cardType;

    public CardAssignment cardAssignment;
    public WhatCardsAreFlipped whatCardsAreFlipped;
    public bool grounded = false;
    public bool isFlipped;
    public int cardNumber;
    public bool forceFlip;
    public bool canFlip = true;
    public bool deactivate = false;
    public GameObject openFace;
    public Material[] images;
    // Start is called before the first frame update
    void Start()
    {
        cardType = cardAssignment.shuffledCardNumbersDoNotEdit[cardNumber];
        Debug.Log(cardType);
        openFace.GetComponent<Renderer>().material = images[cardType];
    }

    void Update()
    {
        
        //Debug.Log(transform.rotation.x);
        //detection for if card is open-faced or not
        if (((transform.rotation.x <= 1.1f && transform.rotation.x >= 0.9f) || (-transform.rotation.x <= 1.1f && -transform.rotation.x >= 0.9f)) && grounded)
        {
            if (!isFlipped)
            {
                isFlipped = true;
                Thread.Sleep(100);
            }
        }
        if (((transform.rotation.x <= 0.2f && transform.rotation.x >= -0.1f) || (-transform.rotation.x <= 0.2f && -transform.rotation.x >= -0.1f)) && grounded)
        {
            isFlipped = false;
        }
        if(forceFlip)
        {
            //making sure the card only flips if it's flipped
            if (((transform.rotation.x <= 1.1f && transform.rotation.x >= 0.9f) || (-transform.rotation.x <= 1.1f && -transform.rotation.x >= 0.9f)) && grounded && isFlipped)
            {
                GetComponent<Rigidbody>().velocity += new Vector3(0f, 5f, 0f);
                GetComponent<Rigidbody>().angularVelocity += new Vector3(-3f, Random.Range(-0.5f, 0.5f), 0f);
                isFlipped = false;
            }
            forceFlip = false;
        }
        if (deactivate)
        {
            gameObject.SetActive(false);
            isFlipped = false;
        }
        if (isFlipped)
        {
            whatCardsAreFlipped.flippedCards[cardNumber] = 1;
        }
        else
        {
            whatCardsAreFlipped.flippedCards[cardNumber] = 0;
        }
    }

    // Update is called once per frame
    private void OnMouseDown()
    {
        if (grounded && whatCardsAreFlipped.amountOfCardsFlipped != 2 && canFlip)
        {
            GetComponent<Rigidbody>().velocity += new Vector3(0f, 5f, 0f);
            //making sure the card rotation detector doesn't break
            //if ((transform.rotation.x <= 1.1f && transform.rotation.x >= 0.9f) || (-transform.rotation.x <= 1.1f && -transform.rotation.x >= 0.9f))
            //{
            //    GetComponent<Rigidbody>().angularVelocity += new Vector3(-3f, Random.Range(-0.5f, 0.5f), 0f);
            //}
            if ((transform.rotation.x <= 0.2f && transform.rotation.x >= -0.1f) || (-transform.rotation.x <= 0.2f && -transform.rotation.x >= -0.1f))
            {
                GetComponent<Rigidbody>().angularVelocity += new Vector3(3f, Random.Range(-0.5f, 0.5f), 0f);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Table")
        {
            grounded = true;
        }
    }


    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Table")
        {
            grounded = false;
        }
    }
}
