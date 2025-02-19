using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPenguinCamera : MonoBehaviour
{
    public Transform target;
    
    // 카메라와 대상 사이의 x축 거리 차이를 저장할 변수 (초기 오프셋)
    float offsetX; 
    
    void Start()
    {
        // 만약 target이 연결되지 않았다면 아래 코드를 실행하지 않고 종료
        if (target == null)
            return;

        // 카메라와 target의 초기 x 위치 차이를 계산하여 offsetX에 저장
        offsetX = transform.position.x - target.position.x;
    }
    
    void Update()
    {
        // 만약 target이 없다면 아무것도 하지 않고 종료
        if (target == null)
            return;

        // 현재 카메라의 위치를 Vector3 변수 pos에 저장
        Vector3 pos = transform.position;
        // target의 현재 x 위치에 초기 오프셋(offsetX)을 더한 값을 새로운 x 위치로 설정
        pos.x = target.position.x + offsetX;
        // 변경된 pos 값을 카메라의 위치로 적용
        transform.position = pos;
    }
}
