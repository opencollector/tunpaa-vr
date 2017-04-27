using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointText : MonoBehaviour {

	private Vector3 startPos;
    private float displayedTime;  // 表示された時間
    public float deleteTime = 3.0f;
    public float maxFloatingDistance = 1.0f;
    public float speed = 0.3f;

	void Start () {
        startPos = transform.position;

        
    }
	
	// Update is called once per frame
	void Update () {
        // カメラの方に向ける
        var camera = GameObject.Find("Camera (eye)");
        transform.LookAt(camera.transform);
        transform.Rotate(new Vector3(0, 180, 0));
        // 位置を上昇させつつ一定距離移動したら停止、その後消える
        if (transform.position.y < startPos.y + maxFloatingDistance)
        {
            transform.position += new Vector3(0, Time.deltaTime * speed, 0);
        }
        displayedTime += Time.deltaTime;
        if (displayedTime > deleteTime)
        {
            Destroy(this.gameObject);
        }
    }

    public void SetPointText(int point)
    {
        string prefix = "";
        if (point >= 0)
        {
            prefix += "+";
        }
        GetComponent<TextMesh>().text = prefix + point.ToString();
    }

}
