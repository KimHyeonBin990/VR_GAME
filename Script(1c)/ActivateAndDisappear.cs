using UnityEngine;

public class ActivateAndDisappear : MonoBehaviour
{
    public Transform player;           // 플레이어의 Transform 참조
    public float activationDistance = 5.0f;  // 활성화 거리
    private bool timerActive = false;  // 타이머 활성화 상태를 추적
    private float timer = 10.0f;       // 타이머 초기값
    private Animator animator;         // 애니메이터 컴포넌트 참조

    void Start()
    {
        animator = GetComponent<Animator>(); // 애니메이터 컴포넌트 가져오기
    }

    void Update()
    {
        // 플레이어가 거리 내에 들어오면 타이머를 시작하고 애니메이션을 실행
        if (!timerActive && Vector3.Distance(player.position, transform.position) < activationDistance)
        {
            animator.SetTrigger("Activate"); // 애니메이터에 'Activate' 트리거 설정
            timerActive = true; // 타이머 활성화
        }

        // 타이머가 활성화된 경우 타이머 감소
        if (timerActive)
        {
            timer -= Time.deltaTime;
            // 타이머가 0 이하가 되면 오브젝트를 비활성화하고 타이머를 리셋
            if (timer <= 0)
            {
                gameObject.SetActive(false);
                timerActive = false;
                timer = 10.0f; // 타이머 리셋
            }
        }
    }
}
