using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rainMakerController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject rainPrefab;     // 비 프리팹
    [SerializeField] float spawnInterval = 0.05f; // 생성 간격(초)
    [SerializeField] float spawnY = 6f;          // 생성 Y 위치
    [SerializeField] float minX = -10f;
    [SerializeField] float maxX = 15f;
    bool start;
    float timer;
    void Update()
    {
        if (GameObject.Find("man") == null) return;
        start = GameObject.Find("man").GetComponent<manController>().start;
        timer += Time.deltaTime;
        if (timer >= spawnInterval && start)
        {
            timer = 0f;
            Spawn();
        }
    }

    void Spawn()
    {
        float x = Random.Range(minX, maxX);
        Vector3 pos = new Vector3(x, spawnY, 0f);
        Instantiate(rainPrefab, pos, Quaternion.identity);
    }
}
