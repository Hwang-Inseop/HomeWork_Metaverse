using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
     // 장애물의 y축 위치 범위를 지정
    public float highPosY = 1f;  // 위쪽 위치 한계
    public float lowPosY = 1f;   // 아래쪽 위치 한계

    // 장애물 상하 간격의 최소, 최대 크기를 지정
    public float holeSizeMin = 1f;
    public float holeSizeMax = 3f;

    // 장애물 Transform을 연결할 변수
    public Transform topObject;
    public Transform bottomObject;

    // 장애물 간 가로 거리
    public float withPadding = 4f;

    // 게임 매니저를 저장할 변수
    GameManager gameManager;
    
    private void Start()
    {
        // GameManager 인스턴스를 가져온다
        gameManager = GameManager.Instance;
    }

    // 장애물의 위치 랜덤 설정하고, 위치를 반환하는 메서드
    public Vector3 SetRandomPlace(Vector3 lastPosition, int obstacleCount)
    {
        // 장애물 상하 간격 크기를 최소값과 최대값 사이에서 랜덤으로 결정
        float holesize = Random.Range(holeSizeMin, holeSizeMax);
        // 장애물 상하 간격의 절반 크기를 계산 (상단과 하단 오브젝트의 위치를 조절할 때 사용)
        float halfHoleSize = holesize / 2;

        // 상단 오브젝트의 로컬 위치를 (0, halfHoleSize)로 설정
        topObject.localPosition = new Vector3(0, halfHoleSize);
        // 하단 오브젝트의 로컬 위치를 (0, -halfHoleSize)로 설정
        bottomObject.localPosition = new Vector3(0, -halfHoleSize);

        // 마지막 장애물 위치(lastPosition)에서 오른쪽으로 withPadding만큼 떨어진 위치를 계산
        Vector3 placePosition = lastPosition + new Vector3(withPadding, 0);
        // y축 위치를 lowPosY와 highPosY 사이에서 랜덤으로 결정
        placePosition.y = Random.Range(lowPosY, highPosY);

        // 이 장애물의 위치를 계산한 placePosition으로 설정
        transform.position = placePosition;

        // 새 위치를 반환
        return placePosition;
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        // 충돌한 오브젝트에서 Player 컴포넌트를 찾는다
        Player_Flying player = collision.gameObject.GetComponent<Player_Flying>();
        // 만약 플레이어가 있다면,
        if (player != null)
            // 게임 매니저를 통해 점수를 1점 추가
            gameManager.AddScore(1);
    }
    
}
