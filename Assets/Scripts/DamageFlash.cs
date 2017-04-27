using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageFlash : MonoBehaviour {

    private Image image;
	void Start () {
        image = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Flash()
    {
        StartCoroutine("flasher");
    }

    IEnumerator flasher()
    {
        image.enabled = true;
        yield return new WaitForSeconds(0.1f);
        image.enabled = false;
    }
}
