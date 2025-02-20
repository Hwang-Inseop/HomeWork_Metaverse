using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public string targetScene; // 이동할 씬 이름

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // 플레이어가 충돌하면
        {
            SceneManager.LoadScene(targetScene); // 미니 게임 씬으로 이동
        }
    }
}
