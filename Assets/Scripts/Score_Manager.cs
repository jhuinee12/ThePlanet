using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class Score_Manager : MonoBehaviour
{
    float LimitTime=0;
    public Text Score_text;

    // Update is called once per frame
    void Update()
    {
        LimitTime += Time.deltaTime / 5; // 5초당 1점
        Score_text.text = Mathf.Round(LimitTime) + "점";
    }
}
