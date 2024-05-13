using UnityEngine;
using System.Collections;

public class DoorController : MonoBehaviour
{
    public Transform playerTransform; // 플레이어의 위치
    public float triggerDistance = 5f; // 문이 열리는 트리거 거리

    public float openDelay = 15f; // 문이 열린 상태를 유지하는 시간
    public float openSpeed = 1f; // 문이 열리는 속도
    public float closeSpeed = 5f; // 문이 닫히는 속도 (빠르게)

    private bool isOpen = false;
    private bool hasOpenedOnce = false; // 문이 한 번 열렸는지 확인
    private Quaternion closedRotation;
    private Quaternion openRotation;

    void Start()
    {
        closedRotation = transform.rotation;
        openRotation = Quaternion.Euler(transform.eulerAngles + new Vector3(0, 90, 0)); // 90도 회전
    }

    void Update()
    {
        if (playerTransform != null && !hasOpenedOnce && Vector3.Distance(transform.position, playerTransform.position) <= triggerDistance)
        {
            StartCoroutine(OpenDoor());
        }
    }

    // 문을 천천히 열기
    private IEnumerator OpenDoor()
    {
        if (!isOpen)
        {
            float elapsed = 0f;
            while (elapsed < 1f)
            {
                transform.rotation = Quaternion.Lerp(closedRotation, openRotation, elapsed);
                elapsed += Time.deltaTime * openSpeed;
                yield return null;
            }
            transform.rotation = openRotation;
            isOpen = true;
            hasOpenedOnce = true; // 문이 한 번 열림
            StartCoroutine(CloseDoorAfterDelay());
        }
    }

    // 일정 시간 후 문 닫기
    private IEnumerator CloseDoorAfterDelay()
    {
        yield return new WaitForSeconds(openDelay);
        StartCoroutine(CloseDoor());
    }

    // 문을 빠르게 닫기
    private IEnumerator CloseDoor()
    {
        float elapsed = 0f;
        while (elapsed < 1f)
        {
            transform.rotation = Quaternion.Lerp(openRotation, closedRotation, elapsed);
            elapsed += Time.deltaTime * closeSpeed;
            yield return null;
        }
        transform.rotation = closedRotation;
        isOpen = false;
    }
}
