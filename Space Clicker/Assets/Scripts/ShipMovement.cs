using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    [SerializeField] private float speedX = 0;
    private float shipWidth;
    private float scale;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(-speedX * Random.Range(6f, 13f), Random.Range(-4f, 5f), transform.position.z);
        scale = Random.Range(0.5f, 1.5f);
        speedX += Random.Range(-1f, 1f);
        transform.localScale = new Vector3(scale, scale, scale);
        shipWidth = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + new Vector3(speedX * Time.deltaTime, 0f, 0f);
        if ((transform.position.x + shipWidth / 2f < 0 && speedX < 0) || (transform.position.x + shipWidth / 2f > 23f && speedX > 0))
        {
            transform.position = transform.position - new Vector3(speedX * Random.Range(10f, 30f), 0f, 0f);
            transform.position = new Vector3(transform.position.x, Random.Range(-4f, 5f), transform.position.z);
            scale = Random.Range(0.5f, 1.5f);
            transform.localScale = new Vector3(scale, scale, scale);
        }
    }
    private void OnMouseDown()
    {
        transform.position = transform.position - new Vector3(speedX * UnityEngine.Random.Range(50f, 60f), 0f, 0f);
        transform.position = new Vector3(transform.position.x, UnityEngine.Random.Range(-4f, 5f), transform.position.z);
        scale = Random.Range(0.5f, 1.5f);
        transform.localScale = new Vector3(scale, scale, scale);
    }
}
