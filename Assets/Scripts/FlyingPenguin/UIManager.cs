using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    // 점수 표시할 TextMeshProUGUI 컴포넌트 에디터에서 할당할 수 있도록 public 변수로 선언
    public TextMeshProUGUI scoreText;
    // 재시작 안내 표시할 TextMeshProUGUI 컴포넌트
    public TextMeshProUGUI restartText;
    
    void Start()
    {
        // restartText가 에디터에서 할당되지 않았다면 에러 로그를 출력
        if (restartText == null)
            Debug.LogError("restart text is null");

        // scoreText가 에디터에서 할당되지 않았다면 에러 로그를 출력
        if (scoreText == null)
            Debug.LogError("score text is null");

        // 게임 시작 시 재시작 텍스트 보이지 않도록 비활성화
        restartText.gameObject.SetActive(false);
    }

    // 게임 오버 시 재시작 메시지를 화면에 출력하는 메서드
    public void SetRestart()
    {
        // restartText의 게임 오브젝트를 활성화하여 UI에 표시
        restartText.gameObject.SetActive(true);
    }

    // 점수를 UI에 보여주는 메서드
    public void UptateScore(int score)
    {
        // score를 문자열로 변환한 후 scoreText의 텍스트에 할당
        scoreText.text = score.ToString();
    }
}
