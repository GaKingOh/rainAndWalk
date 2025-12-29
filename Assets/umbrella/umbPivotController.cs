using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class umbPivotController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float rotateSpeed = 180f; // 초당 회전 각도(도)

    void Update()
    {
        float dir = 0f;

        if (Input.GetKey(KeyCode.RightArrow))
            dir -= 1f;   // 시계방향 (Z -)

        if (Input.GetKey(KeyCode.LeftArrow))
            dir += 1f;   // 반시계방향 (Z +)

        if (dir != 0f)
        {
            transform.Rotate(0f, 0f, dir * rotateSpeed * Time.deltaTime);
        }
    }
}
