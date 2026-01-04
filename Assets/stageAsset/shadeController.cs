using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private Animator anim;

    [Header("Targets (비워두면 자식 포함 SpriteRenderer 자동 수집)")]
    [SerializeField] private SpriteRenderer[] layers;

    [Header("Tint Colors")]
    [SerializeField] private Color dayTint = Color.white;
    [SerializeField] private Color nightTint = new Color(0.35f, 0.35f, 0.45f, 1f);

    [Header("Cycle (seconds)")]
    [Tooltip("완전히 낮 상태로 유지되는 시간")]
    [SerializeField] private float dayHold = 20f;

    [Tooltip("낮 -> 밤으로 어두워지는 시간")]
    [SerializeField] private float fadeToNight = 10f;

    [Tooltip("완전히 밤 상태로 유지되는 시간")]
    [SerializeField] private float nightHold = 20f;

    [Tooltip("밤 -> 낮으로 다시 밝아지는 시간")]
    [SerializeField] private float fadeToDay = 10f;

    [Header("Animation Threshold")]
    [Tooltip("night01이 이 값 이상이면 밤(잠)으로 전환")]
    [Range(0f, 1f)][SerializeField] private float sleepThreshold = 0.8f;

    [Tooltip("night01이 이 값 이하이면 낮(서있기)로 전환")]
    [Range(0f, 1f)][SerializeField] private float wakeThreshold = 0.2f;

    private float cycleLen;
    private bool isDayState = true; // true=낮(stand), false=밤(sleep)
    private static readonly int SunHash = Animator.StringToHash("sun");

    void Awake()
    {
        if (anim == null) anim = GetComponentInChildren<Animator>(); // 혹시 안 넣었을 때 대비
        if (layers == null || layers.Length == 0)
            layers = GetComponentsInChildren<SpriteRenderer>(true);

        cycleLen = Mathf.Max(0.01f, dayHold + fadeToNight + nightHold + fadeToDay);

        // 시작은 낮으로
        isDayState = true;
        if (anim != null) anim.SetBool(SunHash, true);
        SetTint(dayTint);
    }

    void Update()
    {
        float t = Time.time % cycleLen;

        // 0~1로 "밤 정도" 만들기 (0=완전 낮, 1=완전 밤)
        float night01 = CalcNight01(t);

        // 배경 틴트
        SetTint(Color.Lerp(dayTint, nightTint, night01));

        // 애니 전환(히스테리시스)
        // - 어두워져서 night01이 sleepThreshold 넘으면 잠
        // - 다시 밝아져서 night01이 wakeThreshold 아래로 내려가면 깸
        if (isDayState && night01 >= sleepThreshold)
            isDayState = false;
        else if (!isDayState && night01 <= wakeThreshold)
            isDayState = true;

        if (anim != null) anim.SetBool(SunHash, isDayState);
    }

    private float CalcNight01(float t)
    {
        // 1) Day hold
        if (t < dayHold) return 0f;
        t -= dayHold;

        // 2) Fade to night
        if (t < fadeToNight)
        {
            float u = fadeToNight <= 0.0001f ? 1f : Mathf.Clamp01(t / fadeToNight);
            return u; // 0 -> 1
        }
        t -= fadeToNight;

        // 3) Night hold
        if (t < nightHold) return 1f;
        t -= nightHold;

        // 4) Fade to day
        {
            float u = fadeToDay <= 0.0001f ? 1f : Mathf.Clamp01(t / fadeToDay);
            return 1f - u; // 1 -> 0
        }
    }

    private void SetTint(Color c)
    {
        for (int i = 0; i < layers.Length; i++)
            if (layers[i] != null) layers[i].color = c;
    }
}
