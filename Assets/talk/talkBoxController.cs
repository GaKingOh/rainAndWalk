using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class talkBoxController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject talkBox;
    // Update is called once per frame
    public void TurnOnTalkBox(string message)
    {
        talkBox.GetComponentInChildren<TextMeshPro>().text = message; 
        talkBox.SetActive(true);
    }
    public IEnumerator DisableAfterSeconds(float sec)
    {
        yield return new WaitForSeconds(sec);
        gameObject.SetActive(false);
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
