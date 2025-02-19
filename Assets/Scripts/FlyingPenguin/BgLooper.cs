using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgLooper : MonoBehaviour
{
    // 배경 오브젝트를 몇 개 연속으로 이어서 배치할지 설정
    public int numBgCount = 5;

    // 장애물의 총 개수와 마지막으로 배치된 장애물의 위치를 저장하는 변수
    public int obstacleCount = 0;
    public Vector3 obstacleLastPosition = Vector3.zero;
    
    void Start()
    {
        // 씬에 있는 모든 Obstacle 컴포넌트를 찾아 배열에 저장
        Obstacle[] obstacles = GameObject.FindObjectsOfType<Obstacle>();

        // 첫 번째 장애물의 위치를 기준점으로 사용
        obstacleLastPosition = obstacles[0].transform.position;
        // 장애물의 개수를 저장
        obstacleCount = obstacles.Length;

        // 모든 장애물에 대해 순서대로 위치를 랜덤하게 배치
        for (int i = 0; i < obstacleCount; i++)
        {
            // SetRandomPlace()는 각 장애물의 위치를 랜덤하게 설정하고, 
            // 그 새로운 위치를 반환하므로 obstacleLastPosition을 계속 업데이트
            obstacleLastPosition = obstacles[i].SetRandomPlace(obstacleLastPosition, obstacleCount);
        }
    }

    // OnTriggerEnter2D()는 Collider2D가 이 오브젝트의 트리거 영역에 들어올 때 호출
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 충돌한 오브젝트의 이름을 콘솔에서 확인
        Debug.Log("Triggerd: " + collision.name);

        // 만약 충돌한 오브젝트의 태그가 "BackGround"라면
        if (collision.CompareTag("BackGround"))
        {
            // 충돌한 배경 오브젝트의 BoxCollider2D 컴포넌트를 가져와서 해당 오브젝트의 x축 크기를 계산
            float widthOfBgObject = ((BoxCollider2D)collision).size.x;
            // 현재 배경 오브젝트의 위치를 저장
            Vector3 pos = collision.transform.position;

            // 배경 오브젝트의 x 위치에 (배경 너비 * numBgCount)를 더해서 오브젝트를 오른쪽으로 일정 간격만큼 이동
            pos.x += widthOfBgObject * numBgCount;
            collision.transform.position = pos;
            return; // 배경 오브젝트 처리가 끝났으므로 여기서 종료
        }

        // 만약 충돌한 오브젝트가 장애물(Obstacle)이라면,
        Obstacle obstacle = collision.GetComponent<Obstacle>();
        if (obstacle)
        {
            // 장애물의 위치를 랜덤하게 재설정하고, 마지막 장애물 위치를 업데이트
            obstacleLastPosition = obstacle.SetRandomPlace(obstacleLastPosition, obstacleCount);
        }
    }
}
