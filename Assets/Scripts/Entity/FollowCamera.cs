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

        Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);

        //카메라 이동 제한
        targetPosition.x = Mathf.Clamp(targetPosition.x, minBounds.x, maxBounds.x);
        targetPosition.y = Mathf.Clamp(targetPosition.y, minBounds.y, maxBounds.y);

        transform.position = targetPosition;
    }

}
