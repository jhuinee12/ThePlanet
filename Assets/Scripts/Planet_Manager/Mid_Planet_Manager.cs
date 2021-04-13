using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mid_Planet_Manager : MonoBehaviour
{
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        this.player = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
        // 프레임마다 등속으로 낙하
        transform.Translate(0, -0.1f, 0);

        // 화면 밖으로 나오면 오브젝트 소멸
        if (transform.position.y < -5.0f)
        {
            Destroy(gameObject);
        }
    }
}
