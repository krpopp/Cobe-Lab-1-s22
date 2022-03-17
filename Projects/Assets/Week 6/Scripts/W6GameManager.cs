using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class W6GameManager : MonoBehaviour
{
    //singleton setup
    private static W6GameManager instance;

    public static W6GameManager FindInstance() {
        return instance;
    }

    public int cardCount; //number of cards in our deck

    public GameObject cardObj; //the card prefab

    //all potential game states
    public enum State {
        CreateCards,
        Deal,
        Select,
        CardChoosen,
        Resolve
    }

    public State currentState; //tracks the state the game is on now

    List<GameObject> deck = new List<GameObject>();

    public Vector3 handStartPos;

    public float enemyHealth;
    public Text enemyText;


    void Awake() {
        //singleton 
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else if (instance == null) {
            DontDestroyOnLoad(this);
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        enemyText.text = enemyHealth.ToString();
        TransitionStates(State.CreateCards); //start by creating cards
    }

    // Update is called once per frame
    void Update()
    {
        RunState();
    }

    public void TransitionStates(State newState)
    {
        currentState = newState;
        switch (newState) //check the newState
        { //if the newState is...
            case State.CreateCards: 
                for(int i = 0; i < cardCount; i++) //loop for every card we want in the deck
                {
                    GameObject newCard = Instantiate(cardObj); //make a card
                    Vector3 newPos = new Vector3( //make a new position
                        gameObject.transform.position.x,
                        gameObject.transform.position.y,
                        0);
                    newCard.transform.position = newPos; //set the card's position
                    deck.Add(newCard);
                }
                //once all the cards have been made
                TransitionStates(State.Deal); //go to the selection state
                break;
            case State.Deal:
                break;
            case State.Select:
                break;
            case State.CardChoosen:
                break;
            case State.Resolve:
                break;
            default:
                Debug.Log("this state doesn't exist");
                break;
        }
    }

    void RunState() {
        switch (currentState)
        {
            case State.Deal:
                for(int i = 0; i < deck.Count; i++)
                {
                    float step = 5.0f * Time.deltaTime;
                    Vector3 newPos = new Vector3(handStartPos.x + (i * 3), handStartPos.y, 0);
                    deck[i].transform.position = Vector3.MoveTowards(deck[i].transform.position, newPos, step);
                    if(i == deck.Count - 1 && Vector3.Distance(deck[i].transform.position, newPos) < 0.1f)
                    {
                        TransitionStates(State.Select);
                    }
                }
                break;
        }
    }
}
