using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody rb;
    public float force = 7.0f;
    public float turningForce = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //add a velocity in the forward direction in relation to the rotation of the car
        if (Input.GetButton("Fire3"))
        {
            rb.AddRelativeForce(new Vector3(-force, 0, 0));
        }
        //get the direction vector and 
        //rotate car
        rb.angularVelocity = new Vector3(0, turningForce * Input.GetAxis("Horizontal"), 0);
    }

    //TODO: clamps the speed of the car so it can't go too fast

    void ProcessInput()
    {
        float mh = Input.GetAxis("Horizontal");
        float mv = Input.GetAxis("Vertical");
    }

}
