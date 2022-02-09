using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareCol : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //common errors:
    //one of gameobjects we're colliding with must have a rigidbody - even if you're just using triggers
    //2D and 3D physics systems both use similar ideas but run completely seperately (a 2D collider cannot hit a 3D collider and vice versa)
    //the collider and model/sprite are seperate! the way something looks is not connected to its body

    //collisions check if two things hit each other and will act like physical bodies
    //collision = the variable holding the info on the thing we collided with
    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("hit something");
    }

    //triggers check if two things are overlapping
    //one of the things we're checking must have "is trigger" checked
    //again, collision is the info on the thing we triggered (though it's of the type COLLIDER2D rather than Collision2D)
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("overlapped something");
    }

}
