using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class propeller : MonoBehaviour
{
    public float speed;
    public float modifier;

    void Update()
    {
        transform.Rotate(Vector3.up * speed * modifier * Time.deltaTime, Space.Self);
    }
}
