using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBallShooter : MonoBehaviour
{
    public GameObject CannonBallPrefab;

    Vector3 SpawnPosition;
    Vector3 SpawnPositionFront;
    Vector3 SpawnPositionRear;
    Vector3 ShootDirection;

    public Vector3 LeftSpawnPositionFront;
    public Vector3 LeftSpawnPositionRear;
    public Vector3 LeftShootDirection;

    public Vector3 RightSpawnPositionFront;
    public Vector3 RightSpawnPositionRear;
    public Vector3 RightShootDirection;

    public Vector3 FrontSpawnPosition;
    public Vector3 FrontShootDirection;

    public float shootPeriod = 1f;
    float LastShootTime = 0;
    
    void Update()
    {
        if (!Input.GetKeyDown(KeyCode.Space)) return;

        if (Time.timeSinceLevelLoad - LastShootTime < shootPeriod) return;

        LastShootTime = Time.timeSinceLevelLoad;

        var camera = FindObjectOfType<Cam>();
        var direction = camera.GetCameraLookDirection();

        if (direction == CameraLookDirection.BACKWARD)
            return;

        var lookLeft = direction == CameraLookDirection.LEFT;
        var lookRight = direction == CameraLookDirection.RIGHT;

        if (lookLeft)
        {
            SpawnPosition = LeftSpawnPositionFront;
            ShootDirection = LeftShootDirection;
        } 
        else if (lookRight)
        {
            SpawnPosition = RightSpawnPositionFront;
            ShootDirection = RightShootDirection;
        }
        else
        {
            SpawnPosition = FrontSpawnPosition;
            ShootDirection = FrontShootDirection;
        }

        var ball = Instantiate(CannonBallPrefab);
        ball.transform.position = transform.position + transform.rotation * SpawnPosition;

        var rigidbody = ball.GetComponent<Rigidbody>();
        rigidbody.velocity = transform.rotation * ShootDirection;

        if (lookLeft)
        {

            SpawnPosition = LeftSpawnPositionRear;
            ShootDirection = LeftShootDirection;

            var ball2 = Instantiate(CannonBallPrefab);
            ball2.transform.position = transform.position + transform.rotation * SpawnPosition;

            var rigidbody2 = ball2.GetComponent<Rigidbody>();
            rigidbody2.velocity = transform.rotation * ShootDirection;
        }
        else if (lookRight)
        {
            SpawnPosition = RightSpawnPositionRear;
            ShootDirection = RightShootDirection;

            var ball2 = Instantiate(CannonBallPrefab);
            ball2.transform.position = transform.position + transform.rotation * SpawnPosition;

            var rigidbody2 = ball2.GetComponent<Rigidbody>();
            rigidbody2.velocity = transform.rotation * ShootDirection;
        }

    }
}
