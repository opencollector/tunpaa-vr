using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    private int point = 0;  // 得点
    private int count = 0;  // 獲得数
    private Text text;
    // Use this for initialization
    void Start () {
        InitPoint();
        text = GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
        text.text = "SCORE: " + point.ToString("D5") + " [" + count.ToString("D3") + "]";
	}

    void InitPoint()
    {
        point = 0;
    }

    void Increase(int delta)
    {
        point += delta;
        count++;
        if (point < 0)
        {
            point = 0;
        }
    }
}
