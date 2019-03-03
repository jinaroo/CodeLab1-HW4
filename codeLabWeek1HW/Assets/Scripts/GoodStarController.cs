using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodStarController : MonoBehaviour
{
	void OnTriggerEnter2D(Collider2D other)
	{
//		if (other.CompareTag("Player"))
//		{
//			other.gameObject.GetComponent<UI_Manager>().score++; //score goes up
//		}

		UI_Manager.instance.Score++;
		
		Destroy(gameObject);
	}
}
