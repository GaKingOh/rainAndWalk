using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hpController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] 
    int hp = 5;
    talkBoxController tpScript;
    bool isInvincible;
    // Update is called once per frame
    private void Awake()
    {
        tpScript = GameObject.Find("talkBox1").GetComponent<talkBoxController>();
        isInvincible = GameObject.Find("man").GetComponent<invincibleController>().isInvincible;
    }
    public void minusHp()
    {
        if(hp==0)
        {
            Destroy(gameObject);
        }
        if(hp > 0 && !isInvincible)
        {
            hp--;
            if(tpScript != null)
            {
                tpScript.TurnOnTalkBox("¾ÆÇÁ´Ù!");
                StartCoroutine(tpScript.DisableAfterSeconds(1.5f));
            }
        }
    }
    void Update()
    {
        
    }
}
