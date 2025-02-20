using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueBox : MonoBehaviour
{
    public GameObject dialogueBox; // 말풍선 오브젝트
    public float showTime; // 말풍선 표시 시간
    public float hideTime; // 사라진 후 대기 시간

    void Start()
    {
        // StartCoroutine() 일부 실행 → 잠시 멈춤 → 다시 실행을 할 수 있는 함수
        StartCoroutine(ShowRoutine());
    }

    // 코루틴을 만들려면 반환 타입을 IEnumerator로 만들어야 함
    // yield return 키워드로 다음 코드 실행을 미루고 그 시점에서 기다림
    IEnumerator ShowRoutine()
    {
        while (true) // 무한 반복
        {
            dialogueBox.SetActive(true); // 말풍선 출력
            yield return new WaitForSeconds(showTime); // showTime만큼 출력

            dialogueBox.SetActive(false); // 말풍선 숨김
            yield return new WaitForSeconds(hideTime); // hideTime만큼 숨김
        }
    }
}
