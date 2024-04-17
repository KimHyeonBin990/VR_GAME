using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class play : MonoBehaviour
{
    public float moveSpeed = 5f; // 캐릭터의 이동 속도

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime; // 좌우 이동
        float moveY = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime; // 상하 이동

        transform.Translate(moveX, moveY, 0f); // 캐릭터 이동
    }
}
