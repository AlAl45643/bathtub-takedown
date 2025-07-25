using UnityEngine;

public class WheelControls : MonoBehaviour
{
    public Transform wheelModel;

    [HideInInspector] public WheelCollider WheelCollider;

    // Create properties for the KartControl script
    // (Can enable/disable via Editor Inspector window)
    public bool steerable;
    public bool motorized;

    Vector3 position;
    Quaternion rotation;

    // Start is called before the first frame update
    private void Start()
    {
        WheelCollider = GetComponent<WheelCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get the Wheel collider's world pose values and
        // use them to set the wheel model's position and rotation
        //disabled because of graphical issues, no idea how to solve them yet
        WheelCollider.GetWorldPose(out position, out rotation);
        //wheelModel.transform.position = position;
        //wheelModel.transform.rotation = rotation;
    }
}