/*
 * This script is to be placed on a player object that will collide with a flag object that has the FlagChecker script. This script will check if the flagPassedCounter is equal to the totalNumberOfFlags every time the variable flagPassedCounter is set. If it is equal then it will run the CompletedCourse() function.
 * 
 * To properly set this script up you:
 * a) Will need to set up the FlagChecker script
 * b) Set the totalNumberOfFlags variable to the total number of flags in unity.
 * Note: This script is not placed on the Kart parent gameObject but its child the Bathtub_kart object.
 */
using System;
using UnityEngine;

public class FlagCounter : MonoBehaviour
{
    public GameObject lastFlagPassed;
    private int flagPassedCounter = 0;

    public int FlagPassedCounter
    {
        get { return flagPassedCounter; }
        set
        {
            if (value == flagPassedCounter + 1)
            {
                flagPassedCounter = value;
                if (flagPassedCounter == totalNumberOfFlags)
                {
                    CompletedCourse();
                }
                
            }
        }
    } 
    [SerializeField] private int totalNumberOfFlags = 1;
    private void CompletedCourse()
    {
        Debug.Log("Completed the course");
        throw new NotImplementedException();
    }

}
