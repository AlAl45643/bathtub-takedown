/*
 * This script is to be placed on a flag game object that a player with the FlagCounter script collides with. If the colliding object has collided with the previous flag in the sequence then this object will:
 * a) Increase the FlagPassedCounter variable in the FlagCounter script of the colliding gameobject.
 * b) Set the lastFlagPassed variable in the FlagCounter script to this object.
 *
 * To properly set up this script you:
 * a) Set up the FlagCounter script
 * b) Assign the previousRequiredFlag variable to the previous flag in the sequence in unity.
 * Note: The first flag a player goes through cannot also be the last flag in the sequence, instead create another flag on top of the first flag.
 * Note: The first flag a player goes through must have previousRequiredFlag as null.
 */
using UnityEngine;

public class FlagChecker : MonoBehaviour
{
    [SerializeField]
    private GameObject previousRequiredFlag;
   private void OnTriggerEnter(Collider other)
   {
        if (other.GetComponent<FlagCounter>() != null)
        { 
            
            if (other.GetComponent<FlagCounter>().lastFlagPassed == previousRequiredFlag)
            {
                Debug.Log(other.name + " has validly passed flag: " + gameObject.name);
                other.GetComponent<FlagCounter>().FlagPassedCounter++;
                other.GetComponent<FlagCounter>().lastFlagPassed = gameObject;
            }

        }
    }

}
