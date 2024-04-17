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

            // ī�޶� �̵� �� 3�ʰ� ������ ���� ��ȯ�մϴ�.
            if (timeSinceCameraMove >= 1.2f)
            {
                SwitchScene();
            }
        }

        // �����̽��ٸ� ������ ī�޶� �̵� ����
        if (Input.GetKeyDown(KeyCode.Space))
        {
            moveCamera = true;
            timeSinceCameraMove = 0f; // �ð� ������ �ʱ�ȭ�մϴ�.
        }
    }

   

    void SwitchScene()
    {
        SceneManager.LoadScene("game main scene");
    }
}
