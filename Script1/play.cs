using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class play : MonoBehaviour
{
    public float moveSpeed = 5f; // ĳ������ �̵� �ӵ�

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime; // �¿� �̵�
        float moveY = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime; // ���� �̵�

        transform.Translate(moveX, moveY, 0f); // ĳ���� �̵�
    }
}
