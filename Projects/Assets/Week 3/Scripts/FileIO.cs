using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class FileIO : MonoBehaviour
{

    string content; //will hold the content of the file

    const char DELIMITER = '|'; //character that denotes "spaces" between chunks of the text we're reading

    //the data we're storing to the file
    string playerName = "karina popp";
    int score = 1000;
    string country = "US";

    const char COUNTRY_DELIMITER = '$';

    //the name of our file
    //we're making it a const because it's a variable that really never needs to change
    //you must include the file ending
    const string FILE_NAME = "Week3Save.txt";

    // Start is called before the first frame update
    void Start()
    {
        StreamWriter writer = new StreamWriter(FILE_NAME, false); //open the file
        //writer.Write("hello i just wrote to this text file yay!");
        writer.Write(playerName + DELIMITER + score); //write the player's name and score, which will look like: karina popp | 1000
        writer.Close(); //close the file

        StreamReader reader = new StreamReader(FILE_NAME); //open the file
        content = reader.ReadLine(); //read the file

        char[] delimiterChars = { '|' }; //add delimiters
        //the split funciton asks for an array of chars, even through right now we only need one
        string[] scoreSplit = content.Split(delimiterChars); //split the line based on our delimiter

        //two options for reading the contents of the line
        //% means "modulo"
        //it finds the remainder of two numbers

        //for(int i = 0; i < scoreSplit.Length; i++)
        //{
        //    if(i == 0)
        //    {
        //        if (i % 2 == 0)
        //        {
        //            Debug.Log("is a name");
        //        }
        //        else if (i % 2 == 1)
        //        {
        //            Debug.Log("is a score");
        //        }
        //        else if(i % 2 == 2)
        //        {
        //            Debug.Log("is country");
        //        }
        //    }
        //}

        //credit to Akshay for this one
        //which will find all the contents of one line together

        //for (int i = 0; i < scoreSplit.Length; i = i + 3)
        //{
        //    Debug.Log("Name : " + scoreSplit[i] + "     " + "Country : " + scoreSplit[i + 1] + "     " + "Score : " + scoreSplit[i + 2]);
        //}


        //int allHighScores = 100 + scoreSplit[1];

        int highScore = int.Parse(scoreSplit[1]); //turn the score (which is a string) into an int
        int allHighScores = 100 + highScore; //b/c it's now an int, we can use it as a number

        Debug.Log(allHighScores);

        Debug.Log("name: " + scoreSplit[0]);
        Debug.Log("score: " + scoreSplit[1]);

        //Debug.Log(content);
        reader.Close(); //close the file
    }

    // Update is called once per frame
    void Update()
    {
        
        //open the stream writer with the file we want to write to
        //if the file doesn't exist, the stream writer will create it
        //the bool at the end decides if we apend to the file
        //false == overwrite the file
        //true == add to the file
        StreamWriter writer = new StreamWriter(FILE_NAME, false);
        //write to the file
        writer.Write("hello i just wrote to this text file yay!");
        //close the stream writer
        writer.Close();

        //open the stream reader
        StreamReader reader = new StreamReader(FILE_NAME);
        //read the line the stream is on
        //lines end with /n in text
        //(we'll go over this in week 4)
        string content = reader.ReadLine();
        //print the line to the console
        Debug.Log(content);
        //close the reader
        reader.Close();
    }

}
