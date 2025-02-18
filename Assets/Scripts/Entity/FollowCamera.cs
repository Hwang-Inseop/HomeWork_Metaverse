using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target;
    public Vector2 minBounds; // ī�޶� �̵��� �ּ� ��ǥ
    public Vector2 maxBounds; // ī�޶� �̵��� �ִ� ��ǥ

    void Update()
    {
        if (target == null)
            return;

        // ī�޶� ��ǥ�� Ÿ�� ��ǥ�� �����ϰ� �ؼ� ī�޶� �÷��̾ ����
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

        //ī�޶� �̵� ����
        targetPosition.x = Mathf.Clamp(targetPosition.x, minBounds.x, maxBounds.x);
        targetPosition.y = Mathf.Clamp(targetPosition.y, minBounds.y, maxBounds.y);

        transform.position = targetPosition;
    }

}
