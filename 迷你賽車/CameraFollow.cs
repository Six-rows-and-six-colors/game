using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraFollow : MonoBehaviour
{
    public Transform Target;
    public Vector3 Distance;

    public float transformSpeed;
    public float rotationSpeed;
    void Start()
    {
        
    }

    
    void FixedUpdate()
    {
        Translation();
        Rotation();
    }

    public void Translation()
    {
        Vector3 tragetPosition = Target.TransformPoint(Distance);
        transform.position = Vector3.Lerp(transform.position, tragetPosition, transformSpeed * Time.deltaTime);
    }

    public void Rotation()
    {
        Vector3 direction = Target.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);


    }
}
