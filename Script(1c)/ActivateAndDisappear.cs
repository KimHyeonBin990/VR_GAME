using UnityEngine;

public class ActivateAndDisappear : MonoBehaviour
{
    public Transform player;           // �÷��̾��� Transform ����
    public float activationDistance = 5.0f;  // Ȱ��ȭ �Ÿ�
    private bool timerActive = false;  // Ÿ�̸� Ȱ��ȭ ���¸� ����
    private float timer = 10.0f;       // Ÿ�̸� �ʱⰪ
    private Animator animator;         // �ִϸ����� ������Ʈ ����

    void Start()
    {
        animator = GetComponent<Animator>(); // �ִϸ����� ������Ʈ ��������
    }

    void Update()
    {
        // �÷��̾ �Ÿ� ���� ������ Ÿ�̸Ӹ� �����ϰ� �ִϸ��̼��� ����
        if (!timerActive && Vector3.Distance(player.position, transform.position) < activationDistance)
        {
            animator.SetTrigger("Activate"); // �ִϸ����Ϳ� 'Activate' Ʈ���� ����
            timerActive = true; // Ÿ�̸� Ȱ��ȭ
        }

        // Ÿ�̸Ӱ� Ȱ��ȭ�� ��� Ÿ�̸� ����
        if (timerActive)
        {
            timer -= Time.deltaTime;
            // Ÿ�̸Ӱ� 0 ���ϰ� �Ǹ� ������Ʈ�� ��Ȱ��ȭ�ϰ� Ÿ�̸Ӹ� ����
            if (timer <= 0)
            {
                gameObject.SetActive(false);
                timerActive = false;
                timer = 10.0f; // Ÿ�̸� ����
            }
        }
    }
}
