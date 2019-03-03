using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadStarController : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.GetComponent<VelocityPlayerController>().lives--; //lives go down
        }
        
        Destroy(gameObject);
    }
}
