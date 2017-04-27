using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleController : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var controllerLeft = GameObject.Find("ControllerLeft");
        var controllerRight = GameObject.Find("ControllerRight");
        // 左右のトリガーボタンどちらか押されるとスタート
        if (controllerLeft)
        {
            var trackedObjectL = controllerLeft.GetComponent<SteamVR_TrackedObject>();
            var deviceL = SteamVR_Controller.Input((int)trackedObjectL.index);
            if (deviceL.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
            {
                GoNextScene();
            }
        }
        if (controllerRight)
        {
            var trackedObjectR = controllerRight.GetComponent<SteamVR_TrackedObject>();
            var deviceR = SteamVR_Controller.Input((int)trackedObjectR.index);
            if (deviceR.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
            {
                GoNextScene();
            }
        }
    }

    void GoNextScene()
    {
        // 次のシーンへ
        SceneManager.LoadScene("Main");
    }
}