using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class rainController : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 5f;
    public float lifeTime = 5f;

    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        // 중력 끄기
        rb.gravityScale = 0f;
        rb.freezeRotation = true;

    }

    void Start()
    {
        // 아래로 떨어지기
        rb.velocity = Vector2.down * speed;

        Destroy(gameObject, lifeTime);
    }
}
