using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Button : MonoBehaviour
{
    public Sprite pressed;
    public bool activated = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            activated = true;
            GetComponent<SpriteRenderer>().sprite = pressed;
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
