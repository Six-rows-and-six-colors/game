using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public Transform wheelBackLeft;
    public Transform wheelBackRight;
    public Transform wheelFrontLeft;
    public Transform wheelFrontRight;

    public WheelCollider wheelBackLeft_col;
    public WheelCollider wheelBackRight_col;
    public WheelCollider wheelFrontLeft_col;
    public WheelCollider wheelFrontRight_col;

    public float motorTorque;
    public float maxsteerAngle;

    public float InputH;
    public float InputV;
    public bool isBreaking;
    public KeyCode KC_Break;
    public float BreakingForce;
    public string Axis_H;
    public string Axis_V;

    public bool isReset;
    public Transform resetPos;
    public KeyCode KC_reset;

    public bool isStart;
    void Start()
    {
        //motorTorque = 3000;
        maxsteerAngle = 30;
        
    }

    
    void Update()
    {
        if (!isStart)
        {
            return;
        }

        if (isReset)
        {
            ResetCar();
        }
        GetInput();
        CarMotor();
        CarSteering();
        UpdateAllWheel();
        CarBreaking();
    }

    public void GetInput()
    {
        InputH = Input.GetAxis(Axis_H);
        InputV = Input.GetAxis(Axis_V);
        isBreaking = Input.GetKey(KC_Break);
        isReset = Input.GetKey(KC_reset);
    }

    public void CarMotor()
    {
        wheelBackLeft_col.motorTorque = InputV * -motorTorque;
        wheelBackRight_col.motorTorque = InputV * -motorTorque;
    }

    public void CarSteering()
    {
        wheelFrontLeft_col.steerAngle = InputH * maxsteerAngle;
        wheelFrontRight_col.steerAngle = InputH * maxsteerAngle;
    }

    public void UpdateWheel(WheelCollider wheelCollider, Transform wheelTransform)
    {
        Vector3 pos;
        Quaternion rot;
        wheelCollider.GetWorldPose(out pos, out rot);
        wheelTransform.position = pos;
        wheelTransform.rotation = rot;

       }

    public void UpdateAllWheel()
    {
        UpdateWheel(wheelBackLeft_col,wheelBackLeft);
        UpdateWheel(wheelBackRight_col, wheelBackRight);
        UpdateWheel(wheelFrontLeft_col, wheelFrontLeft);
        UpdateWheel(wheelFrontRight_col, wheelFrontRight);
    }

    public void CarBreaking()
    {
        if (isBreaking)
        {
            wheelBackLeft_col.brakeTorque = BreakingForce;
            wheelBackRight_col.brakeTorque = BreakingForce;
            wheelFrontLeft_col.brakeTorque = BreakingForce;
            wheelFrontRight_col.brakeTorque = BreakingForce;
        }
        else
        {
            wheelBackLeft_col.brakeTorque = 0;
            wheelBackRight_col.brakeTorque = 0;
            wheelFrontLeft_col.brakeTorque = 0;
            wheelFrontRight_col.brakeTorque = 0;
        }
    }

    public void ResetCar()
    {
        transform.position = resetPos.transform.position;
        transform.rotation = resetPos.rotation;
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        wheelBackLeft_col.enabled = false;
        wheelBackRight_col.enabled = false;
        wheelFrontLeft_col.enabled = false;
        wheelFrontRight_col.enabled = false;

        wheelBackLeft_col.enabled = true;
        wheelBackRight_col.enabled = true;
        wheelFrontLeft_col.enabled = true;
        wheelFrontRight_col.enabled = true;
    }

}
