using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Life: MonoBehaviour {

    public int maxLife = 100;
    private int life;
    private Text lifeText;
    private GameObject game;

	// Use this for initialization
	void Start () {
        InitLife();
        lifeText = GetComponent<Text>();
        game = GameObject.Find("GameController");
    }
	
	// Update is called once per frame
	void Update () {
        lifeText.text = life.ToString();
    }

    void InitLife()
    {
        life = maxLife;
    }

    void Decrease(int point)
    {
        life -= point;
        if (life < 0)
        {
            life = 0;
        }
        if (life == 0)
        {
            game.SendMessage("GameOver");
        }
    }
}
