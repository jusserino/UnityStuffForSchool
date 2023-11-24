using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finsher : MonoBehaviour
{
    private Vector3 direction;

    public bool attract = false;
    public GameObject player;
    public string nextLevel;
    public Movement movement;
    void FixedUpdate()
    {
        if (attract)
        {
            direction = transform.position - player.transform.position;
            player.GetComponent<Rigidbody2D>().velocity = direction * 3;
        }
        if (player.transform.position.y > transform.position.y - 1 && player.transform.position.y < transform.position.y + 1 && player.transform.position.x > transform.position.x - 1 && player.transform.position.x < transform.position.x + 1)
        {
            movement.rotationspeed *= 1.075f;
            movement.gameObject.transform.localScale -= new Vector3(0.05f, 0.05f, 0.05f);
        }
        if (player.transform.position.y > transform.position.y - 0.2 && player.transform.position.y < transform.position.y + 0.2 && player.transform.position.x > transform.position.x - 0.2 && player.transform.position.x < transform.position.x + 0.2 && movement.rotationspeed >= 100 && movement.gameObject.transform.localScale.y <= 0)
        {
            SceneManager.LoadScene(nextLevel);
        }
    }
}
