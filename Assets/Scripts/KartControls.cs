using UnityEngine;
using TMPro;

public class KartControls : MonoBehaviour
{
    [Header("Kart Properties")]
    public float kartMass = 1500f;
    public float motorTorque = 2000f;
    public float brakeTorque = 4000f;
    public float maxSpeed = 20f;
    public float steeringRange = 20f;
    public float steeringRangeAtMaxSpeed = 10f;
    public float centreOfGravityOffset = -1f;
    public int velocity;
    public TMP_Text vText;

    private WheelControls[] wheels;
    private Rigidbody rigidBody;

    private KartInputControls kartControls; // Reference to the new input system

    void Awake()
    {
        kartControls = new KartInputControls(); // Initialize Input Actions
    }
    void OnEnable()
    {
        kartControls.Enable();
    }

    void OnDisable()
    {
        kartControls.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        rigidBody.mass = kartMass;

        // Adjust center of mass to improve stability and prevent rolling
        Vector3 centerOfMass = rigidBody.centerOfMass;
        centerOfMass.y += centreOfGravityOffset;
        rigidBody.centerOfMass = centerOfMass;

        // Get all wheel components attached to the kart
        wheels = GetComponentsInChildren<WheelControls>();
    }

    // FixedUpdate is called at a fixed time interval
    void FixedUpdate()
    {
        // Read the Vector2 input from the new Input System
        Vector2 inputVector = kartControls.BathKart.Movement.ReadValue<Vector2>();

        // Get player input for acceleration and steering
        float vInput = -inputVector.y; // Forward/backward input, reversed as a temp fix
        float hInput = inputVector.x; // Steering input

        // Calculate current speed along the kart's forward axis
        float forwardSpeed = Vector3.Dot(transform.forward, rigidBody.linearVelocity);
        float speedFactor = Mathf.InverseLerp(0, maxSpeed, Mathf.Abs(forwardSpeed)); // Normalized speed factor
        velocity = (int)(rigidBody.linearVelocity.magnitude * 2.237);
        vText.text = velocity.ToString();
        // Reduce motor torque and steering at high speeds for better handling
        float currentMotorTorque = Mathf.Lerp(motorTorque, 0, speedFactor);
        float currentSteerRange = Mathf.Lerp(steeringRange, steeringRangeAtMaxSpeed, speedFactor);

        // Determine if the player is accelerating or trying to reverse
        bool isAccelerating = Mathf.Sign(vInput) == Mathf.Sign(forwardSpeed);

        foreach (var wheel in wheels)
        {
            // Apply steering to wheels that support steering
            if (wheel.steerable)
            {
                wheel.WheelCollider.steerAngle = hInput * currentSteerRange;
            }

            if (isAccelerating)
            {
                // Apply torque to motorized wheels
                if (wheel.motorized)
                {
                    wheel.WheelCollider.motorTorque = vInput * currentMotorTorque;
                }
                // Release brakes when accelerating
                wheel.WheelCollider.brakeTorque = 0f;
            }
            else
            {
                // Apply brakes when reversing direction
                wheel.WheelCollider.motorTorque = 0f;
                wheel.WheelCollider.brakeTorque = Mathf.Abs(vInput) * brakeTorque;
            }
        }
    }
}