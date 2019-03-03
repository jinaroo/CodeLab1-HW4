using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource bgMusic;

    public static MusicManager instance;
    
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject); //don't destroy music manager when changing scenes
            instance = this; //refers to this instance of the script, or first music manager game object
        }

        else
        {
            Destroy(gameObject); //if another music manager is created, destroy it
        }
    }

    void PlayMusic(AudioClip clip)
    {
        bgMusic.clip = clip;
        bgMusic.Play();
    }
}
