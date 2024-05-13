using UnityEngine;
using System.Collections;  // IEnumerator�� ����ϱ� ���� �߰�

public class GrabAndDrop : MonoBehaviour
{
    public Transform cameraTransform;
    public GameObject girlObject;  // ���ھ��� ������Ʈ ����
    public float grabDistance = 2.0f;
    private GameObject grabbedObject;
    private bool isHolding = false;

    void Start()
    {
        // ���� ���� �� ���ھ��� ������Ʈ�� ��Ȱ��ȭ
        if (girlObject != null)
            girlObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetButtonDown("Grab"))
        {
            if (!isHolding)
            {
                int layerMask = LayerMask.GetMask("Grabbable");  // "Grabbable" ���̾ ���� ����ũ
                RaycastHit hit;
                // ����ĳ��Ʈ�� layerMask�� �����Ͽ� "Grabbable" ���̾��� ������Ʈ�� �����ϵ��� ����
                if (Physics.Raycast(cameraTransform.position, cameraTransform.forward, out hit, grabDistance, layerMask))
                {
                    if (hit.collider.CompareTag("Grabbable"))
                    {
                        grabbedObject = hit.collider.gameObject;
                        grabbedObject.GetComponent<Rigidbody>().isKinematic = true;
                        grabbedObject.transform.SetParent(cameraTransform);
                        grabbedObject.transform.localPosition = new Vector3(0, 0, 1);
                        isHolding = true;

                        // ������ ������ ����� �� ���ھ��� ������Ʈ�� Ȱ��ȭ
                        if (girlObject != null)
                            girlObject.SetActive(true);
                    }
                }
            }
            else
            {
                if (grabbedObject != null)
                {
                    grabbedObject.GetComponent<Rigidbody>().isKinematic = false;
                    grabbedObject.transform.SetParent(null);
                    grabbedObject = null;
                    isHolding = false;

                    // ������ ������ ���� �� 2�� �������� ���ھ��� ������Ʈ�� ��Ȱ��ȭ
                    StartCoroutine(DeactivateAfterDelay(0.2f));
                }
            }
        }
    }

    private IEnumerator DeactivateAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        if (girlObject != null)
            girlObject.SetActive(false);
    }
}
