using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target;
    public Vector2 minBounds; // 카메라 좌표 최소값
    public Vector2 maxBounds; // 카메라 좌표 최대값

    void Update()
    {
        if (target == null)
            return;

        // 카메라 위치를 플레이어 위치와 같게 함
        Vector3 pos = transform.position;
        pos.x = target.position.x;
        pos.y = target.position.y;
        transform.position = pos;
    }

    void LateUpdate()
    {
        if (target == null)
            return;

        // 카메라 위치를 플레이어 위치와 같게 정의하되, z값은 카메라 원래 위치 그대로 정의
        Vector3 cameraPosition = new Vector3(target.position.x, target.position.y, transform.position.z);

        // 카메라가 이동할 수 있는 범위의 최소값과 최대값을 반환
        cameraPosition.x = Mathf.Clamp(cameraPosition.x, minBounds.x, maxBounds.x);
        cameraPosition.y = Mathf.Clamp(cameraPosition.y, minBounds.y, maxBounds.y);

        transform.position = cameraPosition;
    }

}
