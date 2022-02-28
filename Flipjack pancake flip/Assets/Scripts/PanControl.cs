using UnityEngine;

public class PanControl : MonoBehaviour
{
    [SerializeField] private GameObject pan;

    private Vector3 gyroRotation;

    private void Start()
    {
        Input.gyro.enabled = true;
    }

    private void FixedUpdate()
    {
        RotatePan();
        MovePan();
    }

    private void RotatePan()
    {
        gyroRotation -= Input.gyro.rotationRate;
        float rotX = Mathf.Lerp(gyroRotation.x, 0f, 0.05f);
        float rotY = Mathf.Lerp(gyroRotation.y, 0f, 0.05f);
        float rotZ = Mathf.Lerp(gyroRotation.z, 0f, 0.05f);
        gyroRotation = new Vector3(rotX, rotZ, rotY);
        pan.transform.eulerAngles = gyroRotation;
    }

    private void MovePan()
    {
        pan.transform.localPosition = new Vector3(0f, -gyroRotation.x / 100, -gyroRotation.x / 100f);
    }
}