using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class talkBoxController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject talkBox;
    // Update is called once per frame
    public void TurnOnTalkBox()
    {
        talkBox.SetActive(true);
    }
    void Start()
    {
        if (talkBox != null)
            talkBox.SetActive(false);
    }
    void Update()
    {
        
    }
}
