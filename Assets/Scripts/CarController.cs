using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CarController : MonoBehaviour
{
    private const string H = "Horizontal";
    private const string V = "Vertical";

    //for controller input
    PlayerControls controls;

    public float horizontalInput;
    private float verticalInput;
    private float currentSteerAngle;
    private float currentBreakForce;
    private bool isBreaking;
    public SpeedometerDisplay speedometer;

    private Rigidbody rb;

    [SerializeField] private float motorForce;
    [SerializeField] private float breakForce;
    [SerializeField] private float downwardsForce;
    [SerializeField] private float maxSteerAngle;

    public float currentDownwardsForce;

    [SerializeField] private WheelCollider frontLeftWheelCollider;
    [SerializeField] private WheelCollider frontRightWheelCollider;
    [SerializeField] private WheelCollider backLeftWheelCollider;
    [SerializeField] private WheelCollider backRightWheelCollider;

    [SerializeField] private Transform frontLeftWheelTransform;
    [SerializeField] private Transform frontRightWheelTransform;
    [SerializeField] private Transform backLeftWheelTransform;
    [SerializeField] private Transform backRightWheelTransform;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        controls = new PlayerControls();

        //for accelerating
        controls.Gameplay.accelerate.started += ctx => verticalInput = 1.0f;
        controls.Gameplay.accelerate.canceled += ctx => verticalInput = 0.0f;
        //for deccelerating
        controls.Gameplay.deccelerate.started += ctx => verticalInput = -1.0f;
        controls.Gameplay.deccelerate.canceled += ctx => verticalInput = 0.0f;
        //for breaking
        controls.Gameplay.@break.started += ctx => isBreaking = true;
        controls.Gameplay.@break.canceled += ctx => isBreaking = false;
        //for steering
        controls.Gameplay.Turn.started += ctx => horizontalInput = ctx.ReadValue<float>();
        controls.Gameplay.Turn.canceled += ctx => horizontalInput = 0.0f;
    }

    private void Start()
    {
        frontLeftWheelCollider.ConfigureVehicleSubsteps(5f, 12, 15);
        frontRightWheelCollider.ConfigureVehicleSubsteps(5f, 12, 15);
        backLeftWheelCollider.ConfigureVehicleSubsteps(5f, 12, 15);
        backRightWheelCollider.ConfigureVehicleSubsteps(5f, 12, 15);

        rb.centerOfMass = new Vector3(0.0f, 0.1f, 0.2f);
    }

    private void OnEnable()
    {
        controls.Gameplay.Enable();
    }

    private void OnDisable()
    {
        controls.Gameplay.Disable();
    }

    private void Update() {

        speedometer.updateSpeed(rb.velocity.magnitude);

    }

    private void FixedUpdate()
    {
        GetInput();
        HandleMotor();
        HandleSteering();
        UpdateWheels();

        DownForce();
    }

    private void GetInput()
    {
        /*if (Input.GetButton("Jump"))
            verticalInput = 1.0f;
        if (Input.GetButton("Fire3"))
            verticalInput = -1.0f;

        // Change once we decide on button to break with
        */
    }

    private void HandleMotor()
    {
        frontLeftWheelCollider.motorTorque = verticalInput * motorForce;
        frontRightWheelCollider.motorTorque = verticalInput * motorForce;
        currentBreakForce = isBreaking ? breakForce : 0f;
        ApplyBreaking();
        
    }

    private void ApplyBreaking()
    {
        frontLeftWheelCollider.brakeTorque = currentBreakForce;
        frontRightWheelCollider.brakeTorque = currentBreakForce;
        backLeftWheelCollider.brakeTorque = currentBreakForce;
        backRightWheelCollider.brakeTorque = currentBreakForce;
    }

    private void HandleSteering()
    {
        currentSteerAngle = maxSteerAngle * horizontalInput;
        frontLeftWheelCollider.steerAngle = currentSteerAngle;
        frontRightWheelCollider.steerAngle = currentSteerAngle;
    }

    private void UpdateWheels()
    {
        UpdateSingleWheel(frontLeftWheelCollider, frontLeftWheelTransform);
        UpdateSingleWheel(frontRightWheelCollider, frontRightWheelTransform);
        UpdateSingleWheel(backLeftWheelCollider, backLeftWheelTransform);
        UpdateSingleWheel(backRightWheelCollider, backRightWheelTransform);
    }

    private void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform)
    {
        Vector3 pos;
        Quaternion rot;
        wheelCollider.GetWorldPose(out pos, out rot);
        wheelTransform.rotation = rot;
        wheelTransform.position = pos;
    }

    private void DownForce()
    {
        //use the velocity to set a downword velocity value
        currentDownwardsForce = Math.Abs(downwardsForce * rb.velocity.z);

        rb.AddRelativeForce(new Vector3(0, -(currentDownwardsForce), 0));
    }
}
