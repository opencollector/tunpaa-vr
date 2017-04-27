using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PantuMoving : MonoBehaviour {

    public float speed = 0.1f;

	void Start () {
		transform.eulerAngles = new Vector3(0, 360f * Random.Range(0f, 1.0f), 0);
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += new Vector3(0, -speed * Time.deltaTime, 0);
		// 地面に当たっても消えないことがあるのでY軸が負になったら削除
		if (transform.position.y < 0){
			Destroy(this.gameObject);
		}
	}

}
