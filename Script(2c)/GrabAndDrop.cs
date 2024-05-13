using UnityEngine;
using System.Collections;  // IEnumerator를 사용하기 위해 추가

public class GrabAndDrop : MonoBehaviour
{
    public Transform cameraTransform;
    public GameObject girlObject;  // 여자아이 오브젝트 참조
    public float grabDistance = 2.0f;
    private GameObject grabbedObject;
    private bool isHolding = false;

    void Start()
    {
        // 게임 시작 시 여자아이 오브젝트를 비활성화
        if (girlObject != null)
            girlObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetButtonDown("Grab"))
        {
            if (!isHolding)
            {
                int layerMask = LayerMask.GetMask("Grabbable");  // "Grabbable" 레이어에 대한 마스크
                RaycastHit hit;
                // 레이캐스트에 layerMask를 적용하여 "Grabbable" 레이어의 오브젝트만 감지하도록 설정
                if (Physics.Raycast(cameraTransform.position, cameraTransform.forward, out hit, grabDistance, layerMask))
                {
                    if (hit.collider.CompareTag("Grabbable"))
                    {
                        grabbedObject = hit.collider.gameObject;
                        grabbedObject.GetComponent<Rigidbody>().isKinematic = true;
                        grabbedObject.transform.SetParent(cameraTransform);
                        grabbedObject.transform.localPosition = new Vector3(0, 0, 1);
                        isHolding = true;

                        // 곰돌이 인형을 잡았을 때 여자아이 오브젝트를 활성화
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

                    // 곰돌이 인형을 놓은 후 2초 지연으로 여자아이 오브젝트를 비활성화
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
