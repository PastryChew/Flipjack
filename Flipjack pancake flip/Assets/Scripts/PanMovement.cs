using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanMovement : MonoBehaviour
{
    [SerializeField] private GameObject pan;

    private Vector3 gyroRotation;
    private Vector3 gyroMovement;

    private void Start()
    {
        Input.gyro.enabled = true;
    }

    private void Update()
    {
        RotatePan();
        MovePan();
    }

    private void RotatePan()
    {
        gyroRotation = Input.gyro.rotationRate;
        pan.transform.localEulerAngles = ConvertGyroRotation(gyroRotation);
    }

    private void MovePan()
    {
        gyroMovement = Input.acceleration.normalized;
        Debug.Log(gyroMovement);
    }

    private Vector3 ConvertGyroRotation(Vector3 _gyroRotation)
    {
        return new Vector3(_gyroRotation.x, _gyroRotation.z, _gyroRotation.y) * -5;
    }
}