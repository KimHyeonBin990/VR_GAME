using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraMoveAndSwitchScene : MonoBehaviour
{
    public string nextSceneName = "GAME Main Scene";
    public float speed = 10f;
    private bool moveCamera = false;
    private float timeSinceCameraMove = 0f;

    void Update()
    {
        if (moveCamera)
        {
            transform.position += transform.forward * speed * Time.deltaTime;
            timeSinceCameraMove += Time.deltaTime;

            // 카메라 이동 후 3초가 지나면 씬을 전환합니다.
            if (timeSinceCameraMove >= 1.2f)
            {
                SwitchScene();
            }
        }

        // 스페이스바를 누르면 카메라 이동 시작
        if (Input.GetKeyDown(KeyCode.Space))
        {
            moveCamera = true;
            timeSinceCameraMove = 0f; // 시간 측정을 초기화합니다.
        }
    }

   

    void SwitchScene()
    {
        SceneManager.LoadScene("game main scene");
    }
}
