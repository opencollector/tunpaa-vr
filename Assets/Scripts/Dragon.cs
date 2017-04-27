using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : MonoBehaviour {

	public float speed = 1f;  // 速度
	private playerControl body;
	public float deletionBorder = 45f;  // 削除境界

	void Start () {
		body = transform.Find("DefaultDragon").GetComponent<playerControl>();
		Transform player = GameObject.Find("Player").transform;
		// プレイヤーの方向を向く
		transform.LookAt(player);
		// 走るアニメーション
		body.Run2();
	}
	
	void Update () {
		// 向いてる方向に進む
		transform.position += transform.TransformDirection(Vector3.forward) * speed * Time.deltaTime;
		// 画面外に出たら削除する
		if (Mathf.Abs(transform.position.x) > deletionBorder || Mathf.Abs(transform.position.z) > deletionBorder)
		{
			Destroy(gameObject);
		}
	}
}
