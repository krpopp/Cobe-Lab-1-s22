using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{

    DialogManager dialogManager;

    public int nextIndex;
    
    // Start is called before the first frame update
    void Start()
    {
        dialogManager = GameObject.Find("Canvas").GetComponent<DialogManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ContinueStory(){
        dialogManager.storyIndex = nextIndex;
        dialogManager.ProgressStory();
    }

}
