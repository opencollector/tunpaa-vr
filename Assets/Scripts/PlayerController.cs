using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    private GameObject debug;
    public float moveSpeed = 1f;
    public float rotateSpeed = 1f;
    public ushort vibratePulse = 1000;

    void Start()
    {
        debug = GameObject.Find("DebugPanel");
    }

    // Update is called once per frame
    void Update()
    {
        var controllerLeft = GameObject.Find("ControllerLeft");
        var controllerRight = GameObject.Find("ControllerRight");
        var camera = GameObject.Find("Camera (eye)");
        string cameraText = "eye: " + camera.transform.rotation + camera.transform.position;
        string leftText, rightText;
        if (controllerLeft)
        {
            var trackedObjectL = controllerLeft.GetComponent<SteamVR_TrackedObject>();
            var deviceL = SteamVR_Controller.Input((int)trackedObjectL.index);
            if (deviceL.GetPressDown(SteamVR_Controller.ButtonMask.Grip)) {
                var ViveControllerL = controllerLeft.transform.Find("ViveControllerLeft").gameObject;
                ViveControllerL.SetActive(!ViveControllerL.activeSelf);
            }
            if (deviceL.GetTouch(SteamVR_Controller.ButtonMask.Touchpad))
            {
                var position = deviceL.GetAxis();
                leftText = "x: " + position.x + " y: " + position.y;
                // 左押しているときは移動
                if (deviceL.GetPress(SteamVR_Controller.ButtonMask.Touchpad))
                {
                    // カメラの向きを取得
                    var right = camera.transform.TransformDirection(Vector3.right);
                    var forward = camera.transform.TransformDirection(Vector3.forward);
                    var rightDelta = right * position.x * moveSpeed * Time.deltaTime;
                    var forwardDelta = forward * position.y * moveSpeed * Time.deltaTime;
                    // 移動
                    // Y方向を消すためにVector3インスタンス生成
                    var delta = new Vector3(rightDelta.x + forwardDelta.x, 0, rightDelta.z + forwardDelta.z);
                    // 現在地が移動制限範囲外なら方向ベクトルを消す
                    if ((transform.position.x > 7.0f && delta.x > 0) || (transform.position.x < -7.0f && delta.x < 0))
                    {
                        delta += new Vector3(-delta.x, 0, 0);
                    }
                    if ((transform.position.z > 7.0f && delta.z > 0) || (transform.position.z < -7.0f && delta.z < 0))
                    {
                        delta += new Vector3(0, 0, -delta.z);
                    }
                    transform.position += delta;
                }
            }
            else
            {
                leftText = "(not touched)";
            }
        }
        else
        {
            leftText = "(controller not found)";
        }
        if (controllerRight)
        {
            var trackedObjectR = controllerRight.GetComponent<SteamVR_TrackedObject>();
            var deviceR = SteamVR_Controller.Input((int)trackedObjectR.index);
            if (deviceR.GetPressDown(SteamVR_Controller.ButtonMask.Grip))
            {
                var ViveControllerR = controllerRight.transform.Find("ViveControllerRight").gameObject;
                ViveControllerR.SetActive(!ViveControllerR.activeSelf);
            }
            if (deviceR.GetTouch(SteamVR_Controller.ButtonMask.Touchpad))
            {
                var position = deviceR.GetAxis();
                rightText = "x: " + position.x + " y: " + position.y;
                // 右押しているときは回転
                if (deviceR.GetPress(SteamVR_Controller.ButtonMask.Touchpad))
                {
                    // playerの向き
                    transform.Rotate(new Vector3(0, position.x * rotateSpeed, 0));
                }
            }
            else
            {
                rightText = "(not touched)";
            }
        }
        else
        {
            rightText = "(controller not found)";
        }

        debug.SendMessage("UpdateText", leftText + "\n" + rightText + "\n" + cameraText);
    }

    private void Vibrate(GameObject controller)
    {
        if (controller)
        {
            var trackedObject = controller.GetComponent<SteamVR_TrackedObject>();
            var device = SteamVR_Controller.Input((int)trackedObject.index);
            device.TriggerHapticPulse(vibratePulse);
        }
    }
    public void VibrateLeft()
    {
        var controllerLeft = GameObject.Find("ControllerLeft");
        if (controllerLeft)
        {
            Vibrate(controllerLeft);
        }
    }
    public void VibrateRight()
    {
        var controllerRight = GameObject.Find("ControllerRight");
        if (controllerRight)
        {
            Vibrate(controllerRight);
        }
    }
}