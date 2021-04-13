using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mid_Planet_Generator : MonoBehaviour
{
    public GameObject planetPrefabs;
    float span = 1.0f;
    float delta = 0;

    // Update is called once per frame
    void Update()
    {
        this.delta += Time.deltaTime;
        if (this.delta > this.span)
        {
            this.delta = 0;
            GameObject go = Instantiate(planetPrefabs) as GameObject;
            int px = Random.Range(-2, 3); // 랜덤 위치 범위
            go.transform.position = new Vector3(px, 12, 0);
        }
    }
}
