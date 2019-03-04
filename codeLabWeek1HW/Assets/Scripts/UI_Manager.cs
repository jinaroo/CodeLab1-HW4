using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class UI_Manager : MonoBehaviour
{
    public static UI_Manager instance;
    
    public Rigidbody2D rb;
    
    //SCORE
    public TextMesh scoreText;
    public int score = 0;

    public int Score
    {
        get { return score; }
        set
        {
            score = value;
            scoreText.text = "score: " + score;

            HighScore = score;
        }
    }
    
    // HIGH SCORE STUFF
    private const string FILE_HIGHSCORE = "/HighScoreFile.txt";
    
    private int highScore = 0;
    public TextMesh highScoreText;

    public int HighScore
    {
        get { return highScore; }
        set
        {
            if (value > highScore)
            {
                highScore = value;
                highScoreText.text = "high score: " + highScore;
                
                Debug.Log("Application.datapath: " + Application.dataPath);
                string fullPathToFile = Application.dataPath + FILE_HIGHSCORE;
                File.WriteAllText(fullPathToFile, "High Score: " + highScore);
            }
        }
    }
    // CONTINUED ON LINES 97-100

    //LIVES
    public TextMesh livesText;
    public int lives = 3;

    public int Lives
    {
        get { return lives; }
        set
        {
            lives = value;
            livesText.text = "lives: " + lives;
        }
    }

    public TextMesh winnerText;
    public float winnerTextX;
    public float winnerTextY;
    public float winnerTextZ;
    
    public TextMesh loserText;
    public float loserTextX;
    public float loserTextY;
    public float loserTextZ;
    
    //text offset
    public float winnerOffsetX;
    public float winnerOffsetY;
    public float loserOffsetX;
    public float loserOffsetY;
    
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this; //this means "this (instance of the) script"
        }
        else
        {
            Destroy(gameObject); 
        }
        
        scoreText.text = "score: " + score;
        livesText.text = "lives: " + lives;
        
        // MORE HIGH SCORE STUFF
        string highScoreFileText = File.ReadAllText(Application.dataPath + FILE_HIGHSCORE);
        string[] scoreSplit = highScoreFileText.Split(' ');
        int highScoreCheck;
        if (Int32.TryParse(scoreSplit[1], out highScoreCheck))
        {
            Debug.Log("Application.datapath: " + Application.dataPath);
            string fullPathToFile = Application.dataPath + FILE_HIGHSCORE;
            File.WriteAllText(fullPathToFile, "High Score: " + highScoreCheck);

            HighScore = highScoreCheck;
            highScoreText.text = "high score: " + highScoreCheck;
        }
    }

    // Update is called once per frame
    void Update()
    {   
        if (score == 5)
        {    
            winnerText.transform.position = new Vector3(rb.position.x - winnerOffsetX, rb.position.y + winnerOffsetY, winnerTextZ); //moves text to correct position
            Time.timeScale = 0; //stop time, pause game
            //Debug.Log("winner");
        }
		
        //if all lives are lost
        if (lives == 0)
        {
            loserText.transform.position = new Vector3(rb.position.x - loserOffsetX, rb.position.y + loserOffsetY, loserTextZ);
            Time.timeScale = 0;
            //Debug.Log("loser");
			
        }
    }
}
