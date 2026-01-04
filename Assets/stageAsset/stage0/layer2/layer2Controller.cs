using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class layer2Controller : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Transform> child = new();
    bool start = false;
    private void Awake()
    {
        child.Clear();
        for (int i = 0; i < transform.childCount; i++)
        {
            child.Add(transform.GetChild(i));
        }
    }
    // Update is called once per frame
    void Update()
    {
        for(int i=0;i<child.Count;i++)
        {
            if (child[i]!=null && child[i].position.x < -15) // 5f АЃАн
            {
                child[i].position = new Vector3(child[((i + child.Count - 1) % child.Count)].position.x + 5, child[i].position.y, child[i].position.z);
            } 
        }
        if (Input.GetKeyDown(KeyCode.Space)) start = true;

        if (start)
        {
            transform.position += new Vector3(-0.01f, 0f, 0f);
        }
    }
}
