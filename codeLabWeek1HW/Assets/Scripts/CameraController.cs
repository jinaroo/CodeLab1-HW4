using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //add this script to the camera
    public GameObject player; //don't forget to attach player game object
    //public float offsetX; //unnecessary here because i want player game object to always be in the center
    public float offsetY; //bumps up camera slightly higher than where the player game object is
    public Vector3 playerPosition;
    public float offsetSmoothing;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       //finds where player is currently at to center camera
       playerPosition = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z); //you don't want to be on the player gameobject's z axis here
       
       if (player.transform.localScale.y > 0f)
       {
           playerPosition = new Vector3(playerPosition.x, playerPosition.y + offsetY, playerPosition.z);
       }

       else
       {
           playerPosition = new Vector3(playerPosition.x, playerPosition.y - offsetY, playerPosition.z);
       }

       //transform.position = Vector3.Lerp(transform.position, playerPosition, offsetSmoothing * Time.deltaTime);
       transform.position = Vector3.Lerp(transform.position, playerPosition, offsetSmoothing); //got rid of deltaTime to create lerp "slide" camera effect
       //in main camera, change offsetSmoothing from 10 to around 0.1-ish
    }
}
