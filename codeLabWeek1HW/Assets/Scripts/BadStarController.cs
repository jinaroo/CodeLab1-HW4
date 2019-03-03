using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadStarController : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
//        if (other.CompareTag("Player"))
//        {
//            other.gameObject.GetComponent<UI_Manager>().lives--; //lives go down
//        }

        if (other.CompareTag("Player"))
        {
            UI_Manager.instance.Lives--;

            Destroy(gameObject);
        }

    }
}
