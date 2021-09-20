using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public Transform ShipModel;

    public float MinSpeed = 2f;
    public float MaxSpeed = 10f;
    float CurrentSpeed;

    public float MaxAngle = 30f;
    float CurrentAngle = 0;

    float targetSpeed = 0f;

    void Start()
    {
        
    }

    
    void Update()
    {
        // target velocity

        if (Input.GetKey(KeyCode.W))
        {
            targetSpeed = MaxSpeed;
        } else if ((Input.GetKey(KeyCode.S))) {
            targetSpeed = -MaxSpeed;
        } else {
            targetSpeed = MinSpeed;
        }

        //var targetSpeed = Input.GetKey(KeyCode.W) ? MaxSpeed : MinSpeed;
        CurrentSpeed = Mathf.Lerp(CurrentSpeed, targetSpeed, Time.deltaTime);

        // target angle
        var targetAngle = 0f;

        if (Input.GetKey(KeyCode.A))
            targetAngle = -MaxAngle;

        if (Input.GetKey(KeyCode.D))
            targetAngle = MaxAngle;

        CurrentAngle = Mathf.Lerp(CurrentAngle, targetAngle, Time.deltaTime/2);
        

        // movement
        var rigidbody = GetComponent<Rigidbody>();
        rigidbody.rotation *= Quaternion.Euler(Vector3.up * CurrentAngle * Time.deltaTime);
        rigidbody.velocity = rigidbody.rotation * Vector3.forward * CurrentSpeed;

        // model's rotation
        var rotationX = Mathf.Sin(Time.timeSinceLevelLoad * 1.5f) * 2f;
        var rotationZ = -CurrentAngle / 2f;

        ShipModel.localRotation = Quaternion.Euler(rotationX, 0, rotationZ);
    }
}
