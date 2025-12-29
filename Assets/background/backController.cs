using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backcontroler : MonoBehaviour
{
    // Start is called before the first frame update
    bool start = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -20) transform.position = new Vector3(15f,transform.position.y, 0f);
        if (Input.GetKeyDown(KeyCode.Space)) start = true;

        if(start)
        {
            transform.position += new Vector3(-0.01f, 0f, 0f);
        }
    }
}
