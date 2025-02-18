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
        // 필드에서 선언한 컴포넌트 가져오기
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        // 방향키로 이동
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // 왼쪽 이동 시 스프라이트 반전
        if (movement.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1); // 좌우 반전
        }
        else if (movement.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1); // 원래 크기
        }

        // 애니메이션 파라미터 설정
        animator.SetFloat("MoveX", movement.x); // X축 이동 값 전달
        animator.SetFloat("MoveY", movement.y); // Y축 이동 값 전달
        animator.SetBool("isMoving", movement != Vector2.zero); // 이동중 상태인지 체크
    }

    void FixedUpdate()
    {
        // Rigidbody2D를 사용하여 이동 적용
        rb.velocity = movement * moveSpeed;
    }
}
