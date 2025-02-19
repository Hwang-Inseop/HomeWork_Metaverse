using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Flying : MonoBehaviour

{
    Animator animator = null;
    Rigidbody2D _rigidbody = null;

    public float flapForce = 6f; // 점프하는 힘
    public float forwardSpeed = 3f; // 정면으로 이동하는 힘
    public bool isDead = false; // Die 여부 판단
    float deathCooldown = 0f; // Die까지 걸리는 시간

    bool isFlap = false; // 점프한 상태 판단

    public bool godMode = false;

    void Start()
    {
        animator = transform.GetComponentInChildren<Animator>();
        _rigidbody = transform.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isDead)
        {
            if (deathCooldown <= 0)
            {
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
                {
                    // 게임 재시작
                }
            }
            else
            {
                deathCooldown -= Time.deltaTime;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) // 버튼을 입력하면 점프
            {
                isFlap = true;
            }
        }
    }

    public void FixedUpdate()
    {
        if (isDead)
            return;

        Vector3 velocity = _rigidbody.velocity; // 리지드바디의 가속도를 가져온다
        velocity.x = forwardSpeed; // x가속도에 앞으로 가는 힘 부여

        if (isFlap)
        {
            velocity.y += flapForce; // y가속도에 점프하는 힘 부여
            isFlap = false; // 점프 하고 나면 점프 상태를 끔
        }

        _rigidbody.velocity = velocity; // 계산된 값을 리지드바디에 적용
        
        float angle = Mathf.Clamp((_rigidbody.velocity.y * 10f), -90, 90); // 회전 각도 제한
        float lerpAngle = Mathf.Lerp(_rigidbody.velocity.y, angle, Time.deltaTime * 5f);
        transform.rotation = Quaternion.Euler(0, 0, lerpAngle);
    }
    
    public void OnCollisionEnter2D(Collision2D collision) // 물리적 충돌이 발생하면 실행되는 유니티 함수
    {
        if (godMode)
            return;
            
        if (isDead)
            return;

        animator.SetInteger("IsDie", 1);
    }
}