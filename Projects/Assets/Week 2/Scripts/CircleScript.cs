using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleScript : MonoBehaviour
{
    //if we need to reference the actual game manager that exists in the scene
    //we need a reference to that class
    W2GameManager myManager;

    // Start is called before the first frame update
    void Start()
    {
        //this is the old way of accessing a particular instance of a class
        //where we found the gameobject the class lived on
        //W2GameManager myManager = GameObject.Find("Game Manager").GetComponent<W2GameManager>();

        //we can access the score variable from the game manager directly
        //because it is public and static
        Debug.Log(W2GameManager.score);

        //we can also change the score variable directly
        //because it is public and static
        W2GameManager.score += 2;

        //here we are getting the instance of the game manager
        //we're doing this because the game manager uses the singleton pattern
        myManager = W2GameManager.FindInstance();


        //Debug.Log(score);
    }

    // Update is called once per frame
    void Update()
    {
        //we can directly access the utilscript's vector3modify function
        //because it is a static function
        //we use this function to move the circle;
        transform.position = UtilScript.Vector3Modify(transform.position, W2GameManager.circleSpeed, 0, 0);
        
        //because GRAVITY is const and static we can read it
        //but we cannot change it!
        Debug.Log("GRAVITY: " + W2GameManager.GRAVITY);

        //because highScore is a private variable, we cannot directly access it from this script
        //we use the getter and setter of HighScore to access it
        Debug.Log("High Score: " + myManager.HighScore);
    }
}
