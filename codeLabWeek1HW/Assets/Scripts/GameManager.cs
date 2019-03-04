using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private string sceneName;

    public static GameManager instance;
    
    // HIGH SCORE STUFF
    private const string PLAYER_PREF_HIGHSCORE = "highScore";
    private const string FILE_HIGHSCORE = "/HighScoreFile.txt";
    private int highScore = 0;

    public int HighScore
    {
        get { return highScore; }
        set
        {
            if (value > highScore)
            {
                highScore = value;
                Debug.Log("Application.datapath: " + Application.dataPath);
                string fullPathToFile = Application.dataPath + FILE_HIGHSCORE;
                File.WriteAllText(fullPathToFile, "High Score: " + highScore);
            }
        }
    }
    // HIGH SCORE STUFF CONTINUED ON LINES 49-52
    
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
        
        // MORE HIGH SCORE STUFF
        string highScoreFileText = File.ReadAllText(Application.dataPath + FILE_HIGHSCORE);
        string[] scoreSplit = highScoreFileText.Split(' ');
        HighScore = Int32.Parse(scoreSplit[1]);
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
