using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
    public enum GameState
    {
        PLAYING,  // プレイ中
        GAMEOVER,  // ゲームオーバー
    }
    public GameState state;
    public GameObject pointTextPrefab;
    private GameObject life;
    private GameObject player;
    private GameObject damageFlash;
    private GameObject score;
    private GameObject gameOverImage;
    private GameObject gameOverBackground;
    private GameObject gameOverText;
    private GameObject[] spawnPoints;

	// Use this for initialization
	void Start () {
        life = GameObject.Find("Life");
        player = GameObject.Find("Player");
        damageFlash = GameObject.Find("DamageFlash");
        score = GameObject.Find("Score");
        gameOverBackground = GameObject.Find("GameOverBackground");
        gameOverImage = GameObject.Find("GameOverImage");
        gameOverText = GameObject.Find("GameOverText");
        spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");

        // ゲーム初期化
        state = GameState.PLAYING;
        gameOverImage.SetActive(false);
        gameOverBackground.SetActive(false);
        gameOverText.SetActive(false);
    }

    // Update is called once per frame
    void Update () {
    }

	void ReceiveDamage(GameObject attacker)
	{
		// ダメージを受ける処理
        // ライフ減少
        life.SendMessage("Decrease", 5);
        // コントローラー振動
        player.SendMessage("VibrateLeft");
        player.SendMessage("VibrateRight");
        // 画面フラッシュ
        damageFlash.SendMessage("Flash");
    }

    void CapturePantu(GameObject pantu)
    {
        int point;
        // スコア増減
        Debug.Log("CapturePantu:" + pantu.name);
        if (pantu.name == "PantuMale")
        {
            point = -100;
        }
        else
        {
            point = 300;
        }
        score.SendMessage("Increase", point);
        // ポイントを画面に表示
        var pointText = Instantiate(pointTextPrefab, pantu.transform.position + new Vector3(0, 0.2f, 0), Quaternion.identity);
        pointText.SendMessage("SetPointText", point);
        // パンツを削除
        Destroy(pantu);
    }

    void GameOver()
    {
        // 多重実行はしない
        if (state == GameState.GAMEOVER)
        {
            return;
        }
        // ゲームオーバー処理
        state = GameState.GAMEOVER;
        // ドラゴン発生止める
        // パンツ発生止める
        foreach (var spawnPoint in spawnPoints)
        {
            spawnPoint.SendMessage("StopSpawn");
        }
        // パンツ削除
        DestroyAllPantu();
        // ゲームオーバー画像表示
        gameOverBackground.SetActive(true);
        gameOverImage.SetActive(true);
        gameOverText.SetActive(true);
    }

    void DestroyAllPantu()
    {
        GameObject[] allPantu = GameObject.FindGameObjectsWithTag("Pantu");
        foreach (var pantu in allPantu)
        {
            Destroy(pantu);
        }
    }
}
