using UnityEngine;

public class OneTimeTrigger : MonoBehaviour
{
    public Transform player; // 플레이어의 Transform
    public float triggerDistance = 5.0f; // 트리거 거리
    private Rigidbody rb;
    public Vector3 moveDirection = new Vector3(0, 0, 5);
    public float moveForce = 500;
    private bool hasMoved = false; // 물체가 움직였는지 추적하는 변수

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (!hasMoved) // 물체가 아직 움직이지 않았다면
        {
            float distance = Vector3.Distance(player.position, transform.position);
            if (distance < triggerDistance)
            {
                rb.AddForce(moveDirection.normalized * moveForce); // 힘을 가해서 움직임
                hasMoved = true; // 움직였다는 상태로 설정
            }
        }
    }
}
