using UnityEngine;
using UnityEngine.UI;

public class Door2 : MonoBehaviour
{
    public GameObject objectToActivate; // 활성화할 오브젝트
    private bool trig, open; // trig - 플레이어가 트리거 안에 있는지 확인, open - 문이 열렸는지 여부
    private bool hasActivatedOnce = false; // 오브젝트가 한 번 활성화되었는지 확인
    public float smooth = 2.0f; // 문 회전 속도
    public float DoorOpenAngle = 90.0f; // 문이 열리는 각도
    private Vector3 defaulRot; // 기본 회전 값
    private Vector3 openRot; // 문이 열린 후의 회전 값
    public Text txt; // UI 텍스트
    private float timer; // 타이머

    void Start()
    {
        defaulRot = transform.eulerAngles;
        openRot = new Vector3(defaulRot.x, defaulRot.y + DoorOpenAngle, defaulRot.z);
    }

    void Update()
    {
        // 문의 회전 처리
        if (open)
        {
            transform.eulerAngles = Vector3.Slerp(transform.eulerAngles, openRot, Time.deltaTime * smooth);
        }
        else
        {
            transform.eulerAngles = Vector3.Slerp(transform.eulerAngles, defaulRot, Time.deltaTime * smooth);
        }

        // 키 입력 처리
        if (Input.GetKeyDown(KeyCode.E) && trig && !hasActivatedOnce)
        {
            open = !open;
            if (open && objectToActivate != null)
            {
                objectToActivate.SetActive(true);
                hasActivatedOnce = true; // 오브젝트가 활성화되었으므로, 플래그 설정
                timer = 5.0f; // 5초 타이머 설정
            }
        }

        // 타이머를 통한 오브젝트 비활성화 처리
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            if (timer <= 0 && objectToActivate != null)
            {
                objectToActivate.SetActive(false);
                timer = 0;
            }
        }

        // UI 텍스트 업데이트
        if (trig && txt != null)
        {
            txt.text = open ? "Close E" : "Open E";
        }
    }

    private void OnTriggerEnter(Collider coll)
    {
        if (coll != null && coll.CompareTag("Player"))
        {
            if (txt != null)
            {
                txt.text = open ? "Close E" : "Open E";
            }
            trig = true;
        }
    }

    private void OnTriggerExit(Collider coll)
    {
        if (coll != null && coll.CompareTag("Player"))
        {
            if (txt != null)
            {
                txt.text = " ";
            }
            trig = false;
        }
    }
}
