using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ASCIILevelLoader : MonoBehaviour
{

    public string fileName; //the file name that has our level

    public float xOffset; //the x position of where our grid is starting (relative to the game object) 
    public float yOffset; //the y position of where our grid is starting (relative to the game object)

    // Start is called before the first frame update
    void Start()
    {
        StreamReader reader = new StreamReader(fileName); //open the file
        string contentOfFile = reader.ReadToEnd(); //read the whole file and store it to the variable
        reader.Close(); //close the file

        //Debug.Log(contentOfFile);

        char[] newLineChar = { '\n' }; //check for the line break character

        string[] level = contentOfFile.Split(newLineChar); //split based on \n

        for(int i = 0; i < level.Length; i++) //loop for each row in the level
        {
            MakeRow(level[i], -i); //create a row
        }
    }

    void MakeRow(string rowStr, float y) //takes 2 parameters, the characters of the row and the row's y position
    {
        //char c = contentOfFile[i];
        //if (c == 'X')
        //{
        char[] rowArray = rowStr.ToCharArray(); //turn the row into an array of characters
        for (int x = 0; x < rowStr.Length; x++) //loop for however many characters there are
        {
            char c = rowArray[x]; //store the current character as a variable called c
            if (c == 'X') //if the character is X
            {
                Debug.Log("make a cube");
                GameObject brick = Instantiate(Resources.Load("Brick")) as GameObject; //create a cube from the resources folder
                //set the position of the new game object
                brick.transform.position = new Vector3(
                    x * brick.transform.localScale.x + xOffset,
                    y * brick.transform.localScale.y + yOffset,
                    0
                    );
            } else if(c == 'C') //if the character is C
            {
                GameObject tube = Instantiate(Resources.Load("Tube")) as GameObject; //create a cylinder from the resources folder
                //set the position of the new game object
                tube.transform.position = new Vector3(
                    x * tube.transform.localScale.x + xOffset,
                    y * tube.transform.localScale.y + yOffset,
                    0
                    );
            } else if(c == 'O') //if the character is O
            {
                GameObject ball = Instantiate(Resources.Load("Ball")) as GameObject; //create a sphere from the resources folder
                //set the position of the new game object
                ball.transform.position = new Vector3(
                    x * ball.transform.localScale.x + xOffset,
                    y * ball.transform.localScale.y + yOffset,
                    0
                    ) ;
            }
            Debug.Log(y);
        }
       // }
    }
}
