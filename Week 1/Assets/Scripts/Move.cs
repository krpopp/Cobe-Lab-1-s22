using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{

    //a float is a number with a decimal 
    public float speed = 0;

    //string word = "this is a sentence";
    //int wholeNum = 5;
    //bool gameOver = false;
    //double twoDigits = 2.31;

    //enum states {mainMenu, gameScreen, gameOver};

    //char character = 'a';

    //SpriteRenderer myRenderer;

    // Start is called before the first frame update
    void Start()
    {
       // Debug.Log("hello world");
        Debug.Log(speed);
    }

    // Update is called once per frame
    void Update()
    {
        //speed++;
        //Debug.Log(speed);

        Vector3 newPos = transform.position;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            newPos.y += Time.deltaTime * speed;
            //Debug.Log(speed);
        }

        transform.position = newPos;
    }
}
