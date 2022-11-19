using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMusicManager : MonoBehaviour
{
    public AudioClip battleClip, caveClip;
    AudioSource music;
    GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        music = GetComponent<AudioSource>();
        music.clip = caveClip;
        music.Play();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void musicPlay()
    {
        if (gameManager.isFight)
        {
            music.clip = battleClip;
            music.Play();
        }
        else
        {
            music.clip = caveClip;
            music.Play();
        }
    }
}
