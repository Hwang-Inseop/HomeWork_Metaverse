using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    private Vector2 movement;
    public float moveSpeed = 5f; // �̵� �ӵ�
    void Start()
    {
        // �ʵ忡�� ������ ������Ʈ ��������
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        // ����Ű�� �̵�
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // ���� �̵� �� ��������Ʈ ����
        if (movement.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1); // �¿� ����
        }
        else if (movement.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1); // ���� ũ��
        }

        // �ִϸ��̼� �Ķ���� ����
        animator.SetFloat("MoveX", movement.x); // X�� �̵� �� ����
        animator.SetFloat("MoveY", movement.y); // Y�� �̵� �� ����
        animator.SetBool("isMoving", movement != Vector2.zero); // �̵��� �������� üũ
    }

    void FixedUpdate()
    {
        // Rigidbody2D�� ����Ͽ� �̵� ����
        rb.velocity = movement * moveSpeed;
    }
}
