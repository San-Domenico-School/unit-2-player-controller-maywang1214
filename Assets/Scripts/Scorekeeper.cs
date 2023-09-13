using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/************************************************************************
* This class is a component of the Scorekeeper GameObject, an in-world 
* UI Canvas.  It is designed to keeps track of and display the score for
* the game.  Functionalities are listed above each method declaration
************************************************************************/
public class Scorekeeper : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreboardText;  //Reference to the Scoreboard TextMeshProUGUI GameObject
    private float score;                                      //Player's current score
    private int penalty = 40;                                 //Penalty for running into an obstacle

    public static Scorekeeper Instance;                       //This script has a public static
                                                              //reference to itself so that other scripts can access it
                                                              //from anywhere without needing to find a reference to it

    //Called during the initialization of a script/component.
    void Awake()
    {
        //This is a common approach to handling a class with a reference to itself.
        //If instance variable doesn't exist, assign this object to it
        if (Instance == null)
            Instance = this;
        //Otherwise, if the instance variable does exist, but it isn't this object, destroy this object.
        //This is useful so that we cannot have more than one GameManager object in a scene at a time.
        else if (Instance != this)
            Destroy(this);
    }


    //Inputs vertical input value received from the playerController script to an exponential
    //function whose values range from 0.00 to 0.35 which is then added to the score before
    //calling the DisplayScore method
    public void AddToScore(float inputFromPlayer)
    {
        // Calculate the score increment based on the input
        float scoreIncrement = Mathf.Pow(inputFromPlayer, 2) * 0.35f;

        // Add the score increment to the current score
        score += scoreIncrement;

        // Call the method to display the updated score
        DisplayScore();
    }

    //Subtracts penalty from the score to no less than zero when the player runs into an obstacle.
    //before calling the DisplayScore method
    public void SubtractFromScore()
    {
        // Subtract the penalty from the score, ensuring it doesn't go below zero
        score = Mathf.Max(0, score - penalty);

        // Call the method to display the updated score
        DisplayScore();
    }

    //Displays score to UI rounded to nearest integer
    public void DisplayScore()
    {
        // Convert the score to an integer and update the TextMeshPro text
        scoreboardText.text = "Score: " + Mathf.RoundToInt(score).ToString();
    }
}