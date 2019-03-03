using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodStarController : MonoBehaviour
{
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			other.gameObject.GetComponent<VelocityPlayerController>().score++; //score goes up
		}
		
		Destroy(gameObject);
	}
}
