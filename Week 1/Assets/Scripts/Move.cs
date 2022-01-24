using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed = 0; //a float is a number with a decimal 


    //these are other variable types!
    //string word = "this is a sentence"; //a string is a character, word, or phrase in quotations
    //int wholeNum = 5; //an int is a whole number
    //bool gameOver = false; //a bool is a boolean: TRUE or FALSE
    //double twoDigits = 2.31; //a double is a number with up to two digits (we don't often use these!)

    //enum states {mainMenu, gameScreen, gameOver}; //an enum is a custom, descrite piece of data

    //char character = 'a'; //a char is a single character in apostrophes

    //SpriteRenderer myRenderer; //we can also access components like we would a variable

    // Start is called before the first frame update
    void Start()
    {
       // Debug.Log("hello world");
        Debug.Log(speed); //print the speed variable to the console
    }

    // Update is called once per frame
    void Update()
    {
        //speed++; //increase speed by 1
        //Debug.Log(speed);

        Vector3 newPos = transform.position; //hold the gameobject's position as a variable

        if (Input.GetKey(KeyCode.UpArrow)) //if the up arrow key is pressed
        {
            newPos.y += Time.deltaTime * speed; //increase the y value of newPos by speed times Time.deltaTime
            //Debug.Log(speed);
        }

        transform.position = newPos; //set the position of our object to newPos
    }
}
