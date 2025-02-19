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

        //ī�޶� ��ġ�� Ÿ��=�÷��̾��� ��ġ�� �����ϵ�, z���� ���� ī�޶��� ��ġ�� ����
        Vector3 cameraPosition = new Vector3(target.position.x, target.position.y, transform.position.z);

        //ī�޶� �̵� ���� ����
        cameraPosition.x = Mathf.Clamp(cameraPosition.x, minBounds.x, maxBounds.x);
        cameraPosition.y = Mathf.Clamp(cameraPosition.y, minBounds.y, maxBounds.y);

        transform.position = cameraPosition;
    } 

}
