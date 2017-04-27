using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	private void OnTriggerEnter(Collider other)
	{
		// 床にぶつかったら消える
		if (other.name == "PantuFemale" || other.name == "PantuMale")
		{
			Destroy(other.gameObject);
		}
	}

}
