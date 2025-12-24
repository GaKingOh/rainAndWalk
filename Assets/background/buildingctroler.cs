using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buildingctroler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -4) transform.position = new Vector3(25f, 1.4f, 0f);
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += new Vector3(-0.02f, 0f, 0f);
        }
    }
}
