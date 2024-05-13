using UnityEngine;
using UnityEngine.UI;

public class Door2 : MonoBehaviour
{
    public GameObject objectToActivate; // Ȱ��ȭ�� ������Ʈ
    private bool trig, open; // trig - �÷��̾ Ʈ���� �ȿ� �ִ��� Ȯ��, open - ���� ���ȴ��� ����
    private bool hasActivatedOnce = false; // ������Ʈ�� �� �� Ȱ��ȭ�Ǿ����� Ȯ��
    public float smooth = 2.0f; // �� ȸ�� �ӵ�
    public float DoorOpenAngle = 90.0f; // ���� ������ ����
    private Vector3 defaulRot; // �⺻ ȸ�� ��
    private Vector3 openRot; // ���� ���� ���� ȸ�� ��
    public Text txt; // UI �ؽ�Ʈ
    private float timer; // Ÿ�̸�

    void Start()
    {
        defaulRot = transform.eulerAngles;
        openRot = new Vector3(defaulRot.x, defaulRot.y + DoorOpenAngle, defaulRot.z);
    }

    void Update()
    {
        // ���� ȸ�� ó��
        if (open)
        {
            transform.eulerAngles = Vector3.Slerp(transform.eulerAngles, openRot, Time.deltaTime * smooth);
        }
        else
        {
            transform.eulerAngles = Vector3.Slerp(transform.eulerAngles, defaulRot, Time.deltaTime * smooth);
        }

        // Ű �Է� ó��
        if (Input.GetKeyDown(KeyCode.E) && trig && !hasActivatedOnce)
        {
            open = !open;
            if (open && objectToActivate != null)
            {
                objectToActivate.SetActive(true);
                hasActivatedOnce = true; // ������Ʈ�� Ȱ��ȭ�Ǿ����Ƿ�, �÷��� ����
                timer = 5.0f; // 5�� Ÿ�̸� ����
            }
        }

        // Ÿ�̸Ӹ� ���� ������Ʈ ��Ȱ��ȭ ó��
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            if (timer <= 0 && objectToActivate != null)
            {
                objectToActivate.SetActive(false);
                timer = 0;
            }
        }

        // UI �ؽ�Ʈ ������Ʈ
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
