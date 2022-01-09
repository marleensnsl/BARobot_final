using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRobot : MonoBehaviour

{
    [SerializeField]
    private bool move;
    private float moveSpeed;
    //Vector3 vector;
    public GameObject robot;


    // Start is called before the first frame update
    void Start()
    {
        
        move = false;
        //moveSpeed = 2f;

        Debug.Log("MoveRobot Start Function");
    }

    public void MoveWhenClicked()
    {
        robot.GetComponent<Renderer>().material.color = Color.red;
        move = true;
        Debug.Log("MoveRobot Button pressed");
    }
    // Update is called once per frame
    void Update()
    {
        if (move)
        {
            robot.transform.Translate(0, 0, 0.2f);
            move = false;
        }
    }
}
