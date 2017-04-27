using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageZone : MonoBehaviour {

	private GameObject game;
	void Start () {
		game = GameObject.Find("GameController");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter(Collider other)
	{
		// ドラゴンにぶつかった場合
		if (other.name == "Dragon")
		{
			// ダメージを受ける
			game.SendMessage("ReceiveDamage", other.gameObject);
		}
	}
}
