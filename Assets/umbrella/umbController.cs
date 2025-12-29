using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class umbController : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("References")]
    [SerializeField] Rigidbody2D pivotRb;     // umbPivot의 Rigidbody2D
    [SerializeField] Transform handlePoint;  // 손잡이 끝 (Empty)

    [Header("Tuning")]
    [SerializeField] float hitTorque = 3f;   // 충돌 시 토크 세기(Impulse)

    void Awake()
    {
        if (pivotRb == null) pivotRb = GetComponentInParent<Rigidbody2D>();
        if (handlePoint == null) Debug.LogError("handlePoint를 손잡이 끝에 지정해줘!");
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (pivotRb == null || handlePoint == null) return;

        // 충돌 지점(월드)
        Vector2 hitPoint = col.GetContact(0).point;

        // 손잡이 기준 벡터들
        Vector2 handleToPivot = (Vector2)pivotRb.transform.position - (Vector2)handlePoint.position;
        Vector2 handleToHit = hitPoint - (Vector2)handlePoint.position;

        // 2D 외적의 z성분(부호만 필요)
        // handleToPivot 축을 기준으로 hitPoint가 어느 쪽에 있냐로 방향 결정
        float cross = handleToPivot.x * handleToHit.y - handleToPivot.y * handleToHit.x;

        float sign = (cross >= 0f) ? 1f : -1f;

        pivotRb.AddTorque(sign * hitTorque, ForceMode2D.Impulse);
    }
}
