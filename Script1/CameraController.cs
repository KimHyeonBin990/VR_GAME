using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float mouseSensitivity = 100.0f;
    private float xRotation = 0.0f;

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // 부모 객체가 있는지 확인
        if (transform.parent != null)
        {
            transform.parent.Rotate(Vector3.up * mouseX);
        }
        else
        {
            Debug.LogWarning("CameraController: No parent object found for the camera.");
        }
    }
}