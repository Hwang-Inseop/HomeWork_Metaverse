using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Flying : MonoBehaviour

{
      // Animator 컴포넌트 저장
    Animator animator;
    // Rigidbody2D 컴포넌트 저장
    Rigidbody2D _rigidbody;

    // 점프 할 때 적용되는 힘
    public float flapforce = 6f;
    // 앞으로 전진하는 속도
    public float forwardSpeed = 3f;
    // 죽었는지 여부를 나타내는 변수
    public bool isDead = false;
    // 죽은 후 재시작하기 전에 기다리는 시간
    float deathCooldown = 0f;

    // 점프 상태인지 확인
    bool isFlap = false;

    // 갓모드 true면 충돌 무시
    public bool godMode = false;

    // 게임 매니저 인스턴스
    GameManager gameManager;
    
    void Start()
    {
        // GameManager 싱글톤 인스턴스 가져오기
        gameManager = GameManager.Instance;

        // 자식 오브젝트에 있는 Animator 컴포넌트 가져오기
        animator = GetComponentInChildren<Animator>();
        // 현재 오브젝트에 있는 Rigidbody2D 컴포넌트 가져오기
        _rigidbody = GetComponent<Rigidbody2D>();

        // Animator 컴포넌트가 없으면 에러 메시지 출력
        if (animator == null)
            Debug.LogError("Not Founded Animator");

        // Rigidbody2D 컴포넌트가 없으면 에러 메시지 출력
        if (_rigidbody == null)
            Debug.LogError("Not Founded Rigidbody");
    }
    
    void Update()
    {
        // 만약 캐릭터가 죽었다면 재시작 입력을 확인함
        if(isDead)
        {
            // 재시작 대기 시간이 끝났으면
            if (deathCooldown <= 0)
            {
                // 스페이스키나 마우스 왼쪽 버튼을 눌렀을 때
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
                {
                    // 게임 재시작 함수 호출
                    gameManager.RestartGame();
                }
            }
            else
            {
                // 재시작 대기 시간을 줄임
                deathCooldown -= Time.deltaTime;
            }
        }
        // 캐릭터가 살아있다면
        else
        {
            // 입력이 들어오면 점프 상태로 만든다
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                isFlap = true;
            }
        }
    }

    // FixedUpdate() : 고정된 시간 간격으로 호출됨 (물리 연산에 사용)
    private void FixedUpdate()
    {
        if (isDead) return;

        // 현재 Rigidbody2D의 가속도를 가져옴
        Vector3 velocity = _rigidbody.velocity;
        // x축 가속도를 항상 forwardSpeed로 설정 (앞으로 전진)
        velocity.x = forwardSpeed;

        // 점프 상태라면
        if (isFlap)
        {
            // y축에 flapforce 만큼의 힘을 추가 (점프 효과)
            velocity.y += flapforce;
            // 상승하고 나면 점프 상태가 꺼지도록
            isFlap = false;
        }
        // 계산된 속도를 Rigidbody2D에 적용
        _rigidbody.velocity = velocity;

        // 캐릭터의 회전(기울기) 조정 (최소 -90도, 최대 90도)
        float angle = Mathf.Clamp((_rigidbody.velocity.y * 10f), -90, 90);
        // 회전을 적용
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    // OnCollisionEnter2D() : 다른 Collider와 충돌 시 호출됨
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 갓모드가 켜져 있다면 충돌 무시
        if (godMode) return;

        // 이미 죽은 상태면 추가 충돌 처리 무시
        if (isDead) return;

        // 캐릭터를 죽은 상태로 변경
        isDead = true;
        // 죽은 후 재시작까지 1초 대기 설정
        deathCooldown = 1f;

        // 애니메이터에 "IsDie" 파라미터 값을 1로 설정하여 Die 애니메이션 실행
        animator.SetInteger("IsDie", 1);
        // 게임 매니저에 게임 오버를 알림
        gameManager.GameOver();
    }
}