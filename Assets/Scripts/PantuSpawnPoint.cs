using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PantuSpawnPoint : MonoBehaviour {

	public GameObject pantuMale;
	public GameObject pantuFemale;
    public float areaSize = 10.0f;

	// Use this for initialization
	void Start () {
		StartCoroutine("SpawnPantu");
    }

	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator SpawnPantu()
	{
        var rangeLength = areaSize / 2;
        while (true)
		{
			yield return new WaitForSeconds(Random.Range(2f, 5f));
			var pantu = Random.Range(0, 2) == 1 ? pantuMale : pantuFemale;
			var position = transform.position + new Vector3(Random.Range(-rangeLength, rangeLength), 0, Random.Range(-rangeLength, rangeLength));
			var clone = Instantiate(pantu, position, Quaternion.identity);
			clone.name = pantu.name;
		}
	}

    void StopSpawn()
    {
        StopCoroutine("SpawnPantu");
    }
}
