using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class AxleInfo
{
    public WheelCollider leftWheel;

    public Transform leftWheelModel;

    public WheelCollider rightWheel;

    public Transform rightWheelModel;

    public bool motor;

    public bool steering;
}

public class SportsCarController : MonoBehaviour
{
    public bool isCurrent = false;

    public List<AxleInfo> axleInfos;

    public float maxMotorTorque = 4000;

    public float maxSteeringAngle = 30;

    void Start()
    {
        
    }

    private void ApplyLocalPositionToVisuals(AxleInfo axleInfo)
    {
        WheelCollider leftWheel = axleInfo.leftWheel;
        WheelCollider rightWheel = axleInfo.rightWheel;
        Transform leftWheelModel = axleInfo.leftWheelModel;
        Transform rightWheelModel = axleInfo.rightWheelModel;

        Vector3 position1, position2;
        Quaternion rotation1, rotation2;

        leftWheel.GetWorldPose(out position1, out rotation1);

        leftWheelModel.position = position1;
        leftWheelModel.rotation = rotation1;

        rightWheel.GetWorldPose(out position2, out rotation2);

        rightWheelModel.position = position2;
        rightWheelModel.rotation = rotation2;
    }

    void FixedUpdate()
    {
        if (isCurrent)
        {
            float motor = maxMotorTorque * Input.GetAxis("Vertical");
            float steering = maxSteeringAngle * Input.GetAxis("Horizontal");

            foreach (AxleInfo axleInfo in axleInfos)
            {
                if (axleInfo.steering)
                {
                    axleInfo.leftWheel.steerAngle = steering;
                    axleInfo.rightWheel.steerAngle = steering;
                }

                if (axleInfo.motor)
                {
                    axleInfo.leftWheel.motorTorque = motor;
                    axleInfo.rightWheel.motorTorque = motor;
                }

                ApplyLocalPositionToVisuals(axleInfo);
            }
        }
    }
}
