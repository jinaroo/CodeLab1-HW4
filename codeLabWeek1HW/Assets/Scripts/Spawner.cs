using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
	
	public LayerMask avoid;

	// Use this for initialization
	void Start () {
		InvokeRepeating("SpawnGoodStar", 1, 5); //call spawn after 1 seconds and then every 3 seconds
		InvokeRepeating("SpawnBadStar", 2, 5);
	}

	void SpawnGoodStar()
	{
		GameObject newGoodStar = Instantiate(Resources.Load<GameObject>("Prefabs/goodStar"));
		
		Vector2 goodStarPos = new Vector2(Random.Range(-3,3),Random.Range(-6,10));

		while (Physics2D.OverlapCircle(goodStarPos, 1, avoid))
		{
			goodStarPos = new Vector2(Random.Range(-3,3),Random.Range(-6,10));
		}
		
		newGoodStar.transform.position = goodStarPos;
		
		newGoodStar.transform.Rotate(0, 0, Random.Range(0,360));
	}

	void SpawnBadStar()
	{
		GameObject newBadStar = Instantiate(Resources.Load<GameObject>("Prefabs/badStar"));
		
		Vector2 badStarPos = new Vector2(Random.Range(-3,3),Random.Range(-6,10));

		while (Physics2D.OverlapCircle(badStarPos, 1, avoid))
		{
			badStarPos = new Vector2(Random.Range(-3,3),Random.Range(-6,10));
		}
		
		newBadStar.transform.position = badStarPos;
		
		newBadStar.transform.Rotate(0, 0, Random.Range(0,360));
	}
}
