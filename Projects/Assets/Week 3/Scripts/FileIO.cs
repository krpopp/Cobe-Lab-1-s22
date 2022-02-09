using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO; //to write to a file, we need the System.IO library

public class FileIO : MonoBehaviour
{
    //the name of our file
    //we're making it a const because it's a variable that really never needs to change
    //you must include the file ending
    const string FILE_NAME = "Week3Save.txt";

    // Start is called before the first frame update
    void Start()
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
