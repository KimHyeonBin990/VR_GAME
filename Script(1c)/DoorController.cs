using UnityEngine;
using System.Collections;

public class DoorController : MonoBehaviour
{
    public Transform playerTransform; // �÷��̾��� ��ġ
    public float triggerDistance = 5f; // ���� ������ Ʈ���� �Ÿ�

    public float openDelay = 15f; // ���� ���� ���¸� �����ϴ� �ð�
    public float openSpeed = 1f; // ���� ������ �ӵ�
    public float closeSpeed = 5f; // ���� ������ �ӵ� (������)

    private bool isOpen = false;
    private bool hasOpenedOnce = false; // ���� �� �� ���ȴ��� Ȯ��
    private Quaternion closedRotation;
    private Quaternion openRotation;

    void Start()
    {
        closedRotation = transform.rotation;
        openRotation = Quaternion.Euler(transform.eulerAngles + new Vector3(0, 90, 0)); // 90�� ȸ��
    }

    void Update()
    {
        if (playerTransform != null && !hasOpenedOnce && Vector3.Distance(transform.position, playerTransform.position) <= triggerDistance)
        {
            StartCoroutine(OpenDoor());
        }
    }

    // ���� õõ�� ����
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
            hasOpenedOnce = true; // ���� �� �� ����
            StartCoroutine(CloseDoorAfterDelay());
        }
    }

    // ���� �ð� �� �� �ݱ�
    private IEnumerator CloseDoorAfterDelay()
    {
        yield return new WaitForSeconds(openDelay);
        StartCoroutine(CloseDoor());
    }

    // ���� ������ �ݱ�
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
