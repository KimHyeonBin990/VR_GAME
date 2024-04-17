using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FlickerUI : MonoBehaviour
{
    public Image targetImage; // 깜빡일 Image 컴포넌트를 할당합니다.
    public float flickerTime = 0.5f; // 깜빡임 사이의 간격을 설정합니다.

    void Start()
    {
        if (targetImage != null)
            StartCoroutine(Flicker());
    }

    IEnumerator Flicker()
    {
        // 무한 루프 안에서 작동합니다.
        while (true)
        {
            // Image 컴포넌트의 투명도를 변화시킵니다.
            targetImage.enabled = !targetImage.enabled;

            // 설정된 시간만큼 대기합니다.
            yield return new WaitForSeconds(flickerTime);
        }
    }
}
