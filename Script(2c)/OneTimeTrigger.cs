using UnityEngine;

public class OneTimeTrigger : MonoBehaviour
{
    public Transform player; // �÷��̾��� Transform
    public float triggerDistance = 5.0f; // Ʈ���� �Ÿ�
    private Rigidbody rb;
    public Vector3 moveDirection = new Vector3(0, 0, 5);
    public float moveForce = 500;
    private bool hasMoved = false; // ��ü�� ���������� �����ϴ� ����

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (!hasMoved) // ��ü�� ���� �������� �ʾҴٸ�
        {
            float distance = Vector3.Distance(player.position, transform.position);
            if (distance < triggerDistance)
            {
                rb.AddForce(moveDirection.normalized * moveForce); // ���� ���ؼ� ������
                hasMoved = true; // �������ٴ� ���·� ����
            }
        }
    }
}
