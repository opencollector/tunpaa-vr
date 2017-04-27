using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandController : MonoBehaviour {

	private GameObject game;
	void Start () {
        game = GameObject.Find("GameController");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay(Collider other)
    {
        // 手のあたり判定範囲に入っている
        if (other.name == "PantuFemale" || other.name == "PantuMale")
        {
            var trackedObject = GetComponent<SteamVR_TrackedObject>();
            var device = SteamVR_Controller.Input((int)trackedObject.index);
            // 触っているほうのトリガーボタンを押している獲得
            if (device.GetPress(SteamVR_Controller.ButtonMask.Trigger))
            {
                // パンツを獲得
                game.SendMessage("CapturePantu", other.gameObject);
            }
        }
    }
}
