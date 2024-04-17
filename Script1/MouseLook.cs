using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;  // ���콺 ���� ����
    public Transform playerBody;          // ī�޶� ������ �÷��̾��� ��ü(ȸ�� ���)

    float xRotation = 0f;                 // ���� ȸ���� ���� ����

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;  // ���� ���� �� Ŀ�� ����
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;  // ���콺 X�� ������
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;  // ���콺 Y�� ������

        xRotation -= mouseY;                            // ���� ȸ�� �� ���
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);  // ���� ȸ�� ���� ����

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);  // ī�޶� ���� ȸ�� ����
        playerBody.Rotate(Vector3.up * mouseX);         // �÷��̾� ��ü�� �¿�� ȸ��
    }
}
