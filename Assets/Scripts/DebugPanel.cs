using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugPanel : MonoBehaviour {

	private Text text;
	void Awake () {
		text = GetComponent<Text>();
	}

	// Update is called once per frame
	void UpdateText (string message) {
		text.text = "Debug: \n" + message;
	}
}
