using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SrtButton : MonoBehaviour
{
    public string startLevel;
    public Sprite hoverOver;
    public Sprite notHoverOver;

    private bool mouseOver = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (mouseOver)
        {
            GetComponent<SpriteRenderer>().sprite = notHoverOver;
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = hoverOver;

        }
    }
    private void OnMouseDown()
    {
        SceneManager.LoadScene(startLevel);
    }
    private void OnMouseOver()
    {
        mouseOver = true;
    }
    private void OnMouseExit()
    {
        mouseOver = false;
    }
}
