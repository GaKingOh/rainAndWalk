using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class invincibleController : MonoBehaviour
{
    [SerializeField] float invTime = 1.0f; // 무적 시간
    [SerializeField] float blinkInterval = 0.25f; // 반짝 거리는 시간
    [Range(0f, 1f)][SerializeField] float blinkAlpha = 0.35f; // 투명도

    public bool isInvincible;
    SpriteRenderer sr;
    Color original;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        original = sr.color;
    }

    public void TakeHit(int dmg) // 물방울과 충돌 했을 때
    {
        if (isInvincible) return; // 현재 반짝거리면 충돌 판정 x

        // TODO: HP 감소 처리
        // hp -= dmg;

        StartCoroutine(InvRoutine());
    }

    IEnumerator InvRoutine()
    {
        Debug.Log("왓떠");
        isInvincible = true;

        int manLayer = LayerMask.NameToLayer("man"); // 플레이어 레이어 번호
        int waterLayer = LayerMask.NameToLayer("Water"); // 물방울 레이어 번호

        Physics2D.IgnoreLayerCollision(manLayer, waterLayer, true); // 둘이 충돌 무시

        float t = 0f;
        bool low = false;

        while (t < invTime)
        {
            low = !low;
            var c = original;
            c.a = low ? blinkAlpha : 1f;
            sr.color = c;

            yield return new WaitForSeconds(blinkInterval);
            t += blinkInterval;
        }

        sr.color = original;
        Physics2D.IgnoreLayerCollision(manLayer, waterLayer, false); // 원복
        isInvincible = false;
    }
}
