using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camFollow : MonoBehaviour
{
    public Transform submarine;
    Vector3 offset;

    [Header("rotation")]
    public bool doRotaion;
    public float mRotation; //coefficient of rotation speed over angle differences

    float rotationSpeed;
    public float angleDiff;
    public float angleGate; //min speed for it

    public float subRot; //rotation of sub
    public float camRot; //rotation of camera

    float subAngle;

    void Start()
    {
        offset = transform.position;
    }

    void FixedUpdate()
    {
        transform.position = submarine.position + offset;

        if (doRotaion)
        {
            subRot = submarine.rotation[1];
            camRot = transform.rotation[1];

            angleDiff = camRot - subRot;

            if (angleDiff != 0f && Mathf.Abs(angleDiff) < angleGate)
                rotationSpeed = mRotation * angleGate * Mathf.Sign(camRot);

            //rotationSpeed = angleDiff * mRotation;
            if (angleDiff != 0f)
            {
                rotationSpeed = mRotation * Mathf.Sign(angleDiff);
            }

            transform.Rotate(Vector3.up * rotationSpeed * -1f, Space.World);
        }
    }
}
