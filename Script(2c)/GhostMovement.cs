using UnityEngine;

public class GhostMovement : MonoBehaviour
{
    public Transform player; // �÷��̾��� Transform
    public float speed = 9.0f; // �ͽ��� �̵� �ӵ�
    public float waitTime = 2.0f; // ������ ���� �� ��� �ð�

    private float timer; // ��� �ð��� ������ Ÿ�̸�

    void Start()
    {
        timer = waitTime; // ���� �� Ÿ�̸Ӹ� �ʱ�ȭ�մϴ�.
    }

    void Update()
    {
        // Ÿ�̸Ӹ� ���ҽ�ŵ�ϴ�.
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            return; // Ÿ�̸Ӱ� 0���� ũ�� ���⼭ �Լ��� �����ϰ�, �Ʒ� �ڵ�� ������� �ʽ��ϴ�.
        }

        // �÷��̾��� ��ġ�� ���� �ͽ��� �̵���ŵ�ϴ�.
        Vector3 direction = player.position - transform.position;
        direction.y = 0; // ���� ���̴� �����ϰ�, ���� �̵��� ����մϴ�.
        transform.LookAt(player.position); // �÷��̾ �ٶ󺸰� �մϴ�.
        transform.position += direction.normalized * speed * Time.deltaTime;
    }
}
