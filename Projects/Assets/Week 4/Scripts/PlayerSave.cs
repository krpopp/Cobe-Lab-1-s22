using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PlayerSave : MonoBehaviour
{
    public string fileName; //the file we're reading from

    const char delimiter = '|'; //the character we're looking for that means "break"

    // Start is called before the first frame update
    void Start()
    {
        StreamReader reader = new StreamReader(fileName); //open the stream reader
        string newPos = reader.ReadLine(); //read the file; it should be the position of the player we saved
        reader.Close(); //close the file
        Debug.Log(newPos); //show the line we read in the console

        string[] pos = newPos.Split(new char[] { delimiter }); //split the line based on our delimiter
        transform.position = new Vector3(float.Parse(pos[0]), float.Parse(pos[1]), float.Parse(pos[2])); //turn that line into a vector 3
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) //if we press space
        {
            StreamWriter writer = new StreamWriter(fileName); //open the file
            //write the player's position to the file
            writer.Write("" +
                transform.position.x + delimiter +
                transform.position.y + delimiter +
                transform.position.z);
            writer.Close(); //close the file
        }
    }
}
