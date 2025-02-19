using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target;
    public Vector2 minBounds; // 카메라가 이동할 최소 좌표
    public Vector2 maxBounds; // 카메라가 이동할 최대 좌표

    void Update()
    {
        if (target == null)
            return;

        // 카메라 좌표를 타겟 좌표와 동일하게 해서 카메라가 플레이어를 추적
        Vector3 pos = transform.position;
        pos.x = target.position.x;
        pos.y = target.position.y;
        transform.position = pos;
    }

    void LateUpdate()
    {
        if (target == null)
            return;

        //카메라 위치를 타겟=플레이어의 위치로 정의하되, z값은 원래 카메라의 위치로 정의
        Vector3 cameraPosition = new Vector3(target.position.x, target.position.y, transform.position.z);

        //카메라 이동 범위 제한
        cameraPosition.x = Mathf.Clamp(cameraPosition.x, minBounds.x, maxBounds.x);
        cameraPosition.y = Mathf.Clamp(cameraPosition.y, minBounds.y, maxBounds.y);

        transform.position = cameraPosition;
    } 

}
