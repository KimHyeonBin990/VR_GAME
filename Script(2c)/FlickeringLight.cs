using UnityEngine;

public class FlickeringLight : MonoBehaviour
{
    Light myLight;             // �Һ� ������Ʈ�� ������ ����
    public float minIntensity = 0.5f;  // �ּ� ����
    public float maxIntensity = 1.5f;  // �ִ� ����
    public float flickerSpeed = 0.07f; // ������ �ӵ�

    void Start()
    {
        myLight = GetComponent<Light>(); // �� ���� ������Ʈ���� Light ������Ʈ�� ������
    }

    void Update()
    {
        // Random.Range�� ����Ͽ� �Һ��� ������ �����ϰ� ����
        myLight.intensity = Mathf.Lerp(minIntensity, maxIntensity, Mathf.PingPong(Time.time * flickerSpeed, 1));
    }
}
