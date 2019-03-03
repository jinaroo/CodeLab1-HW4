using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private string sceneName;

    public static GameManager instance;
    
    // Start is called before the first frame update
    void Start()
    {   
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject); //don't destroy game manager when changing scenes
            instance = this; //refers to this instance of the script, or first game manager game object
        }

        else
        {
            Destroy(gameObject); //if another game manager is created, destroy it
        }
    }

    // Update is called once per frame
    void Update()
    {   
        Scene currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
        //Debug.Log(sceneName);
        
        //to start game
        if (sceneName == "TitleScreen" && Input.GetKeyDown(KeyCode.Space))
        {
            //Debug.Log("Pressed space");
            UnityEngine.SceneManagement.SceneManager.LoadScene ("SampleScene");   
        }
    }
}
