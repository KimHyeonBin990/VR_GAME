using UnityEngine;

public class ThrowWheelchair : MonoBehaviour
{
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();  // Rigidbody 컴포넌트를 참조
        Invoke("ApplyForce", 10);       // 150초 후에 ApplyForce 메소드 호출
    }

    void ApplyForce()
    {
        float forceMagnitude = 1000f;       // 힘의 크기
        Vector3 forceDirection = new Vector3(1, 1, 1);  // 힘의 방향 (예시로 오른쪽-위 방향)

        rb.AddForce(forceDirection * forceMagnitude);  // 힘 적용
    }
}
