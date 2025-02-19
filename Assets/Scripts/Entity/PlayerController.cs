using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    private Vector2 movement;
    public float moveSpeed = 5f; // 이동 속도
    void Start()
    {
        // 필요한 컴포넌트 가져오기
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        // 입력에 따라 벡터값이 변함
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // localScale값을 변경해서 이동 방향에 따라 스프라이트 방향 전환
        if (movement.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1); // 왼쪽으로 이동하면 스프라이트를 왼쪽으로
        }
        else if (movement.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1); // 오른쪽으로 이동하면 스프라이트를 오른쪽으로
        }

        // Move 애니메이션 재생을 위한 파라미터 설정
        animator.SetFloat("MoveX", movement.x); // X값 입력 확인
        animator.SetFloat("MoveY", movement.y); // Y값 입력 확인
        animator.SetBool("isMoving", movement != Vector2.zero); // movement가 0이 아니면 움직이는 상태
    }

    void FixedUpdate()
    {
        // rigidbody2D의 가속도에 벡터*이동속도로 이동 구현
        rb.velocity = movement * moveSpeed;
    }
}
