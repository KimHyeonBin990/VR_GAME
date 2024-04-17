using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ImageSlideshow : MonoBehaviour
{
    public Sprite[] images; // 이미지들을 저장할 배열
    public Image displayImage; // UI에서 이미지를 표시할 Image 컴포넌트
    public string nextSceneName; // 전환할 다음 씬의 이름
    public float fadeDuration = 2.0f; // 페이드 아웃 지속 시간

    private int currentIndex = 0; // 현재 이미지 인덱스

    void Start()
    {
        StartCoroutine(ShowImages());
    }

    IEnumerator ShowImages()
    {
        while (currentIndex < images.Length)
        {
            displayImage.sprite = images[currentIndex]; // 현재 인덱스의 이미지로 업데이트
            displayImage.color = Color.white; // 이미지의 색상을 원래대로 설정
            yield return new WaitForSeconds(3); // 5초 동안 대기

            // 시작: 페이드 아웃
            float elapsed = 0.0f;
            Color originalColor = displayImage.color;
            while (elapsed < fadeDuration)
            {
                elapsed += Time.deltaTime;
                float alpha = Mathf.Lerp(1.0f, 0.0f, elapsed / fadeDuration);
                displayImage.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
                yield return null;
            }
            displayImage.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0); // 완전히 투명하게
            // 종료: 페이드 아웃

            currentIndex++; // 인덱스 증가
        }

        SceneManager.LoadScene(nextSceneName); // 모든 이미지를 보여준 후 씬 전환
    }
}
