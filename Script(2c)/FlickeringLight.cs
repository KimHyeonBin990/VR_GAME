using UnityEngine;

public class FlickeringLight : MonoBehaviour
{
    Light myLight;             // 불빛 컴포넌트를 참조할 변수
    public float minIntensity = 0.5f;  // 최소 강도
    public float maxIntensity = 1.5f;  // 최대 강도
    public float flickerSpeed = 0.07f; // 깜박임 속도

    void Start()
    {
        myLight = GetComponent<Light>(); // 이 게임 오브젝트에서 Light 컴포넌트를 가져옴
    }

    void Update()
    {
        // Random.Range를 사용하여 불빛의 강도를 랜덤하게 변경
        myLight.intensity = Mathf.Lerp(minIntensity, maxIntensity, Mathf.PingPong(Time.time * flickerSpeed, 1));
    }
}
