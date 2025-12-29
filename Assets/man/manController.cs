using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manController : MonoBehaviour
{
    // Start is called before the first frame update
    Animator anim;
    float t;
    public bool start = false;
    void Awake()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("isWalk", false); // 시작은 정지
    }
    private void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            start = true;
        }
        if (start)
        {
            anim.SetBool("isWalk", true);
        }
        else
        {
            anim.SetBool("isWalk", false);
        }
    }
}
