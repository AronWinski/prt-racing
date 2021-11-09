using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public class CarController : MonoBehaviour
{
    private const string H = "Horizontal";


    //for controller input
    PlayerControls controls;

    public float horizontalInput;
    [SerializeField] private float verticalInput;
    [SerializeField] private float verticalInputPos;
    [SerializeField] private float verticalInputNeg;

    private float currentSteerAngle;
    private float currentBreakForce;
    private bool isBreaking;

    private Rigidbody rb;

    public float currentDownwardsForce;
    private Vector3 currentVelocity;
    public float currentVelocityX;
    public float currentVelocityY;
    public float currentVelocityZ;

    [SerializeField] private float motorForce;
    [SerializeField] private float breakForce;
    [SerializeField] private float downwardsForce;
    [SerializeField] private float maxSteerAngle;



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

        currentVelocity = transform.InverseTransformDirection(Vector3.forward);
        currentVelocityZ = currentVelocity.z;

        //for accelerating
        controls.Gameplay.accelerate.started += ctx => verticalInputPos = ctx.ReadValue<float>();
        controls.Gameplay.accelerate.canceled += ctx => verticalInputPos = 0.0f;
        //for deccelerating
        controls.Gameplay.deccelerate.started += ctx => verticalInputNeg = -(ctx.ReadValue<float>());
        controls.Gameplay.deccelerate.canceled += ctx => verticalInputNeg = 0.0f;
        //for breaking
        controls.Gameplay.@break.started += ctx => isBreaking = true;
        controls.Gameplay.@break.canceled += ctx => isBreaking = false;
        //for steering
        controls.Gameplay.Turn.started += ctx => horizontalInput = ctx.ReadValue<float>();
        controls.Gameplay.Turn.canceled += ctx => horizontalInput = 0.0f;

    }
    private void Start()
    {
        //makes the ride smoother
        frontLeftWheelCollider.ConfigureVehicleSubsteps(5f, 12, 15);
        frontRightWheelCollider.ConfigureVehicleSubsteps(5f, 12, 15);
        backLeftWheelCollider.ConfigureVehicleSubsteps(5f, 12, 15);
        backRightWheelCollider.ConfigureVehicleSubsteps(5f, 12, 15);

        //lowers the center of mass so it doesn't flip as much
        rb.centerOfMass = new Vector3(0.0f, 0.1f, 0.2f);


    }

    private void FixedUpdate()
    {
        HandleMotor();
        HandleSteering();
        UpdateWheels();
        DownForce();
    }

    private void Update()
    {
        //updates verticalInput based on acc and dec
        verticalInput = verticalInputPos + verticalInputNeg;
    }

    private void HandleMotor()
    {
        frontLeftWheelCollider.motorTorque = verticalInput * motorForce;
        frontRightWheelCollider.motorTorque = verticalInput * motorForce;
        currentBreakForce = isBreaking ? breakForce : 0f;
        /*if (verticalInput < Math.Abs(0.01f) && !isBreaking)
        {
            currentBreakForce = 400f;
        }*/
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
        currentDownwardsForce = Math.Abs(downwardsForce * currentVelocityZ);

        rb.AddRelativeForce(new Vector3(0, -(currentDownwardsForce), -(currentDownwardsForce/30)));
    }

    /// <summary>
    /// Not important
    /// </summary>
    private void OnEnable()
    {
        controls.Gameplay.Enable();

    }

    private void OnDisable()
    {
        controls.Gameplay.Disable();
    }

 


}
