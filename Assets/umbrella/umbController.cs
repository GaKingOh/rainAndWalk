using UnityEngine;

public class umbController : MonoBehaviour
{
    [Header("Anchor (고정 위치)")]
    [SerializeField] Transform anchor;

    [Header("Rotate (Input)")]
    [SerializeField] float rotateSpeed = 180f;
    [SerializeField] float minAngle = -60f;
    [SerializeField] float maxAngle = 60f;

    [Header("Auto Tilt (No Input)")]
    [SerializeField] float idleTargetAngle = -20f; // 입력 없을 때 가려는 각도
    [SerializeField] float idleReturnSpeed = 90f;  // deg/sec (붙는 속도)

    Vector3 fixedPos;

    void Start()
    {
        fixedPos = anchor ? anchor.position : transform.position;
    }

    void Update()
    {
        transform.position = anchor ? anchor.position : fixedPos;

        float input = 0f;
        if (Input.GetKey(KeyCode.LeftArrow)) input = 1f;
        if (Input.GetKey(KeyCode.RightArrow)) input = -1f;

        float cur = Normalize180(transform.eulerAngles.z);

        float next;
        if (Mathf.Abs(input) > 0.001f)
        {
            // 입력 회전
            next = cur + input * rotateSpeed * Time.deltaTime;
        }
        else
        {
            // 입력 없으면 목표 각도로 “서서히” 이동
            next = Mathf.MoveTowards(cur, idleTargetAngle, idleReturnSpeed * Time.deltaTime);
        }

        next = Mathf.Clamp(next, minAngle, maxAngle);
        transform.rotation = Quaternion.Euler(0f, 0f, next);
    }

    static float Normalize180(float angle)
    {
        angle %= 360f;
        if (angle > 180f) angle -= 360f;
        if (angle < -180f) angle += 360f;
        return angle;
    }
}
