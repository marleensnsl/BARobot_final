using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasButton : MonoBehaviour
{
    public GameObject object1;
    bool ispressed = false;
    

    public void CanvasButtonPressed()
    {
        ispressed = true;
        Debug.Log("it worked! CanvasButton pressed");
        object1.GetComponent<Renderer>().material.color = Color.red;
    }
    


    public void Update()
    {
        if(ispressed)
        {
            object1.transform.Translate(0.2f, 0, 0);
            ispressed = false;
        }


    }



}
