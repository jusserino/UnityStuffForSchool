using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonChecker : MonoBehaviour
{
    public Button[] buttons;
    private bool allAreEnabled = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Button checker in buttons)
        {
            if (!checker.activated)
            {
                allAreEnabled = false;
            }
        }
        if (allAreEnabled)
        {
            gameObject.SetActive(false);
        }
        allAreEnabled = true;
    }
}
