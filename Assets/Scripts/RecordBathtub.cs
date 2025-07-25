/*
 * This script should placed onto a Bathtub gameObject that you would like to record. Once the game is run this script shall
 * a) Add the velocity of the gameObject to the botDataObject every physics update.
 * b) Add the angular velocity of the gameObject to the botDataObject every physics update.
 * c) Add the rotation of the gameObject to the botDataObject every physics update.
 *
 * To properly set this script you:
 * a) Set up the BotData.cs script
 * b) Add the gameObject with the BotData.cs script to the botDataObject field
 * c) Start the game and after you finish recording move the BotData.cs object from the Hierarchy menu into your Project Folder menu.
 */
using UnityEngine;

public class RecordBathtub : MonoBehaviour
{
    [SerializeField] public GameObject botDataObject;
    private BotData _botData;
    private Rigidbody _rigidbody;


    private void Start()
    {
        _rigidbody = gameObject.GetComponent<Rigidbody>();
        _botData = botDataObject.GetComponent<BotData>();
    }

    void FixedUpdate()
    {
        _botData.velocities.Add(_rigidbody.linearVelocity);
        _botData.angularVelocities.Add(_rigidbody.angularVelocity);
        _botData.rotations.Add(gameObject.transform.rotation);
    }
}



