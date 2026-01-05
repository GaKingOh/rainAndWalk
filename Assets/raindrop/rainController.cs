using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class rainController : MonoBehaviour
{
    // Start is called before the first frame update
    public float fallSpeed = 6f;     // 항상 아래로 떨어지는 속도
    public float scrollSpeed = 3f;   // → 방향키 누를 때만 적용할 옆 이동 속도(왼쪽으로라면 -로)
    Rigidbody2D rb; // 물방울의 물리
    float f = 0;
    bool start; // 게임이 시작했는지를 알려주는 변수
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;
        rb.freezeRotation = true;
        start = GameObject.Find("man").GetComponent<manController>().start;
        /*
         * Serializefield에서 받을 수 없는 변수 -> hierarchy에 있는 오브젝트/컴포넌트 불가능
         * 
         */
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("man"))
        {
            other.GetComponent<invincibleController>().TakeHit(1); // 물방울이랑 충돌하면 깜빡거리는 기능
            other.GetComponent<hpController>().minusHp(); // 물방울이랑 충돌하면 hp 줄이는 기능
        }
        Destroy(gameObject);
    }
    void FixedUpdate()
    {
        f += Time.deltaTime;
        float vx = 0f;
        if(start) vx = -scrollSpeed;   // 배경이 왼쪽으로 흐르는 느낌이면 - (원하는 방향대로 +/− 바꿔)
        // else vx = 0f;  // 안 누르면 옆이동 없음

        rb.velocity = new Vector2(vx, -fallSpeed);
        if (f > 5) Destroy(gameObject);
        // 만약 너 Unity에서 velocity 대신 linearVelocity를 쓰는 버전이면 rb.linearVelocity로 바꿔줘
    }
}
