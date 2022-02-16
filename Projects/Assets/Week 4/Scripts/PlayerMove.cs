using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKey(KeyCode.W))
        //{
        //    gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, moveSpeed, 0);
        //}
        //move the player using our custom function
        Move(KeyCode.W, 0, moveSpeed);
        Move(KeyCode.S, 0, -moveSpeed);
        Move(KeyCode.A, -moveSpeed, 0);
        Move(KeyCode.D, moveSpeed, 0);
    }

    void Move(KeyCode key, float xMove, float yMove) //takes 3 arguments: the key we're looking for, the x velocity and the y velocity
    {
        if (Input.GetKey(key)) //if we hit that key
        {
            GetComponent<Rigidbody>().velocity = new Vector3(xMove, yMove, 0); //change the velocity of the game object
        }
    }
}
