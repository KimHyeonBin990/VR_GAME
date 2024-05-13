using UnityEngine;

public class GhostMovement : MonoBehaviour
{
    public Transform player; // 플레이어의 Transform
    public float speed = 9.0f; // 귀신의 이동 속도
    public float waitTime = 2.0f; // 움직임 시작 전 대기 시간

    private float timer; // 대기 시간을 추적할 타이머

    void Start()
    {
        timer = waitTime; // 시작 시 타이머를 초기화합니다.
    }

    void Update()
    {
        // 타이머를 감소시킵니다.
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            return; // 타이머가 0보다 크면 여기서 함수를 종료하고, 아래 코드는 실행되지 않습니다.
        }

        // 플레이어의 위치를 향해 귀신을 이동시킵니다.
        Vector3 direction = player.position - transform.position;
        direction.y = 0; // 높이 차이는 무시하고, 수평 이동만 고려합니다.
        transform.LookAt(player.position); // 플레이어를 바라보게 합니다.
        transform.position += direction.normalized * speed * Time.deltaTime;
    }
}
