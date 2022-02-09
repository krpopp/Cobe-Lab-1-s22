using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class FileIO : MonoBehaviour
{
    const string FILE_NAME = "Week3Save.txt";

    // Start is called before the first frame update
    void Start()
    {
        StreamWriter writer = new StreamWriter(FILE_NAME, false);
        writer.Write("hello i just wrote to this text file yay!");
        writer.Close();

        StreamReader reader = new StreamReader(FILE_NAME);
        string content = reader.ReadLine();
        Debug.Log(content);
        reader.Close();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
