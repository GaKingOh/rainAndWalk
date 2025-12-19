using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class dropController : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Put your 5 rain sprites here")]
    [SerializeField] private Sprite[] sprites;   // Inspector에 5개 드래그

    [Header("Optional random tweaks")]
    [SerializeField] private Vector2 scaleRange = new Vector2(0.9f, 1.1f);
    [SerializeField] private Vector2 alphaRange = new Vector2(0.7f, 1.0f);

    private SpriteRenderer sr;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();

        if (sprites == null || sprites.Length == 0)
        {
            Debug.LogWarning($"{name}: sprites array is empty.");
            return;
        }

        // 1) 5개(또는 배열에 들어있는 개수) 중 랜덤 선택
        sr.sprite = sprites[Random.Range(0, sprites.Length)];

        // 2) (선택) 약간의 랜덤 스케일/투명도 → 자연스러움
        float s = Random.Range(scaleRange.x, scaleRange.y);
        transform.localScale = new Vector3(s, s, 1f);

        Color c = sr.color;
        c.a = Random.Range(alphaRange.x, alphaRange.y);
        sr.color = c;
    }
}
