using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ImageSlideshow : MonoBehaviour
{
    public Sprite[] images; // �̹������� ������ �迭
    public Image displayImage; // UI���� �̹����� ǥ���� Image ������Ʈ
    public string nextSceneName; // ��ȯ�� ���� ���� �̸�
    public float fadeDuration = 2.0f; // ���̵� �ƿ� ���� �ð�

    private int currentIndex = 0; // ���� �̹��� �ε���

    void Start()
    {
        StartCoroutine(ShowImages());
    }

    IEnumerator ShowImages()
    {
        while (currentIndex < images.Length)
        {
            displayImage.sprite = images[currentIndex]; // ���� �ε����� �̹����� ������Ʈ
            displayImage.color = Color.white; // �̹����� ������ ������� ����
            yield return new WaitForSeconds(3); // 5�� ���� ���

            // ����: ���̵� �ƿ�
            float elapsed = 0.0f;
            Color originalColor = displayImage.color;
            while (elapsed < fadeDuration)
            {
                elapsed += Time.deltaTime;
                float alpha = Mathf.Lerp(1.0f, 0.0f, elapsed / fadeDuration);
                displayImage.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
                yield return null;
            }
            displayImage.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0); // ������ �����ϰ�
            // ����: ���̵� �ƿ�

            currentIndex++; // �ε��� ����
        }

        SceneManager.LoadScene(nextSceneName); // ��� �̹����� ������ �� �� ��ȯ
    }
}
