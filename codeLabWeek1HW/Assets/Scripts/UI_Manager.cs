using System.Collections;
using System.Collections.Generic;
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
            scoreText.text = "Score: " + score;
        }
    }

    //LIVES
    public TextMesh livesText;
    public int lives = 3;

    public int Lives
    {
        get { return lives; }
        set
        {
            lives = value;
            livesText.text = "Lives: " + lives;
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
    }

    // Update is called once per frame
    void Update()
    {
        //scoreText.text = "score: " + score;
        if (score == 5)
        {    
            winnerText.transform.position = new Vector3(rb.position.x - winnerOffsetX, rb.position.y + winnerOffsetY); //moves text to correct position
            Time.timeScale = 0; //stop time, pause game
            //Debug.Log("winner");
        }
		
        //if all lives are lost
        livesText.text = "lives: " + lives;
        if (lives == 0)
        {
            loserText.transform.position = new Vector3(rb.position.x - loserOffsetX, rb.position.y + loserOffsetY, loserTextZ);
            Time.timeScale = 0;
            //Debug.Log("loser");
			
        }
    }
}
