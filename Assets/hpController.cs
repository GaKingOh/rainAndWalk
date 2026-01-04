using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hpController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] 
    int hp = 5;
    [SerializeField]
    public GameObject talkBox;
    // Update is called once per frame
    public void minusHp()
    {
        if(hp > 0)
        {
            hp--;
            Debug.Log("¼öÆÈ");
            talkBox.SetActive(true);
        }
    }
    void Update()
    {
        
    }
}
