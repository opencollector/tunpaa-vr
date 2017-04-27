using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonSpawnPoint : MonoBehaviour {

	public GameObject dragon;
    private GameObject game;

	void Start () {
		StartCoroutine("SpawnDragon");
	}
	
	// Update is called once per frame
	void Update () {
	}

	IEnumerator SpawnDragon()
	{
		while (true)
		{
			yield return new WaitForSeconds(Random.Range(5f, 40f));
            var dragons = GameObject.FindGameObjectsWithTag("Dragon");
            // ドラゴンの最大数以下なら追加
            if (dragons.Length < 3)
            {
                var clone = Instantiate(dragon, transform.position, Quaternion.identity);
                clone.name = "Dragon";
            }
        }
	}

    void StopSpawn()
    {
        StopCoroutine("SpawnDragon");
    }
}