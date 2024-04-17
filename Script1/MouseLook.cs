using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;  // 마우스 감도 설정
    public Transform playerBody;          // 카메라가 부착된 플레이어의 몸체(회전 대상)

    float xRotation = 0f;                 // 상하 회전을 위한 변수

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;  // 게임 시작 시 커서 고정
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;  // 마우스 X축 움직임
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;  // 마우스 Y축 움직임

        xRotation -= mouseY;                            // 상하 회전 값 계산
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);  // 상하 회전 각도 제한

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);  // 카메라 상하 회전 적용
        playerBody.Rotate(Vector3.up * mouseX);         // 플레이어 몸체를 좌우로 회전
    }
}
