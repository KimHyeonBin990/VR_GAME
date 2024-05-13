using UnityEngine;

public class ThrowWheelchair : MonoBehaviour
{
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();  // Rigidbody ������Ʈ�� ����
        Invoke("ApplyForce", 10);       // 150�� �Ŀ� ApplyForce �޼ҵ� ȣ��
    }

    void ApplyForce()
    {
        float forceMagnitude = 1000f;       // ���� ũ��
        Vector3 forceDirection = new Vector3(1, 1, 1);  // ���� ���� (���÷� ������-�� ����)

        rb.AddForce(forceDirection * forceMagnitude);  // �� ����
    }
}
