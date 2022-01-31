using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class W2GameManager : MonoBehaviour
{

    //a public and static variable is a variable
    //this is accesible to all scripts
    //AND is shared amoung all instances of the class
    //so if we had multiple gamemanagers (which we do not)
    //all their scores would be the same
    public static float score;

    //a const is a variable that cannot be changed
    //we want to use a const for variables that should never
    //be able to be modified by anything
    public const float GRAVITY = 1.622f;


    //by default, variables are private unless otherwise stated
    //so this startHealth variable is private, even though I didn't make it private
    float startHealth;

    //this is similar, but I specifically said the variable is private
    //we may want to specify if a variable is public vs private
    //for the sake of clarity
    private int userId = 2;

    private int highScore;

    //because the highScore variable is private, we use this getter/setter pattern
    //to change it or read it
    //this is like adding another layer of security on our variable
    public int HighScore
    {
        get
        {
            return highScore;
        }
        set
        {
            highScore = value; //value is an IMPLICT VARIABLE
            //meaning it's a keyword that the complier reconizes
        }
    }

    public static float circleSpeed = 0;

    //this begins our singleton pattern
    //here we set a variable of the type W2GameManager (our GM class) and call it instance
    private static W2GameManager instance;

    //in some cases, if a variable of this game manager is NOT static, we'll need a reference to
    //the instance with the game manager
    //for example, in this case HighScore is not static
    //so, we still need an instance reference to find the game manager
    //this function will allow us to do that
    public static W2GameManager FindInstance() {
        return instance;
    }

    //awake runs right when this class is run
    //and never again
    //it also runs before anything else (including start)
    private void Awake()
    {
        //if we have already chosen a king game manager
        //(null literally means "nothing", so if instance is NOT nothing)
        //AND
        //if the king game manager is NOT this instance of the class
        //destroy this
        if(instance != null && instance != this)
        {
            //what we;re doing is ensuring that there can only
            //be one game manager in any scene
            Destroy(this);
        }
        else //otherwise, if we do not have a king game manager
        {
            //make this the king game manager
            instance = this;
            //and do not destroy this game object when we load new scenes
            DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //we can set highScore by using the HighScore getter/setter
        //when we use this line, the "value" implict variable from above
        //is 10
        HighScore = 10;
        circleSpeed = -0.5f;
        Debug.Log(highScore);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0)) //if we press the mouse button
        {
            SceneManager.LoadScene("Start"); //load the new scene
        }
    }

}
