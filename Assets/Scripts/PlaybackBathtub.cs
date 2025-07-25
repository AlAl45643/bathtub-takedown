/*
 * This script should be placed onto a bathtub bot gameobject.
 *
 * To properly set this script up you:
 * a) Create a valid BotData gameObject with RecordBathtub.cs and BotData.cs
 * b) Create a Bot gameObject from the player gameObject, remove any conflicting scripts, and put both the Player and Bot Game Objects in two different layers and set them to not collide in the Layer Collision Matrix.
 * c) Add this script to the Bot gameObject and add the valid BotData gameObject to the botData field.
 */
using UnityEngine;

public class PlaybackBathtub : MonoBehaviour
{
    [SerializeField] public BotData botData;
    private int counter = 0;
    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = gameObject.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (counter < botData.velocities.Count)
        {
            _rigidbody.linearVelocity = botData.velocities[counter];
            _rigidbody.angularVelocity = botData.angularVelocities[counter];
            gameObject.transform.rotation = botData.rotations[counter];
            counter++;
        }
    }
}
