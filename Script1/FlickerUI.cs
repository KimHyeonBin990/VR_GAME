using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FlickerUI : MonoBehaviour
{
    public Image targetImage; // ������ Image ������Ʈ�� �Ҵ��մϴ�.
    public float flickerTime = 0.5f; // ������ ������ ������ �����մϴ�.

    void Start()
    {
        if (targetImage != null)
            StartCoroutine(Flicker());
    }

    IEnumerator Flicker()
    {
        // ���� ���� �ȿ��� �۵��մϴ�.
        while (true)
        {
            // Image ������Ʈ�� ������ ��ȭ��ŵ�ϴ�.
            targetImage.enabled = !targetImage.enabled;

            // ������ �ð���ŭ ����մϴ�.
            yield return new WaitForSeconds(flickerTime);
        }
    }
}
