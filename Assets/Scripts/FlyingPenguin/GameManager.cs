using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
// GameManager 싱글톤
    static GameManager gameManager;

    // 외부에서 GameManager.Instance로 싱글톤 인스턴스에 접근할 수 있도록
    public static GameManager Instance { get { return gameManager; } }

    // 현재 점수를 저장하는 변수
    private int currentScore = 0;

    // UIManager 컴포넌트를 참조할 변수
    UIManager uiManager;
    // 외부에서 UIManager에 접근할 수 있도록 프로퍼티로
    public UIManager UIManager { get { return uiManager; } }
    
    private void Awake()
    {
        // 싱글톤 인스턴스로 현재 GameManager를 할당
        gameManager = this;
        // 씬 내에서 UIManager 타입의 컴포넌트를 찾아서 할당
        // FindAnyObjectByType 씬 내에서 해당 타입의 컴포넌트를 찾는 함수
        uiManager = FindAnyObjectByType<UIManager>();
    }
    
    private void Start()
    {
        // UIManager를 통해 초기 점수를 0으로
        uiManager.UptateScore(0);
    }
    
    // 게임 오버 메서드
    public void GameOver()
    {
        Debug.Log("Game Over");
        uiManager.SetRestart();  // UIManager를 통해 재시작 UI 활성화
    }

    // 게임 재시작 메서드
    public void RestartGame()
    {
        // 현재 활성화된 씬의 이름을 가져와 다시 로드
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // 점수 획득 메서드
    public void AddScore(int score)
    {
        // 현재 점수에 매개변수 score 값을 더함
        currentScore += score;

        Debug.Log("Score: " + currentScore);
        // UIManager를 통해 UI에 점수 업데이트
        uiManager.UptateScore(currentScore);
    }
}
