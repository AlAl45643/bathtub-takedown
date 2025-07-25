/*
 * This script holds the velocities, angularVelocities, and rotations of the gameObject.
 *
 * To properly set this script you:
 * a) Create an empty gameobject
 * b) Add this script to the gameObject
 */
using System.Collections.Generic;
using UnityEngine;

public class BotData : MonoBehaviour
{
       public List<Vector3> velocities;
       public List<Vector3> angularVelocities;
       public List<Quaternion> rotations;

}
