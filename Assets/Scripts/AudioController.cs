using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour {

    public AudioSource targetHit;
    public AudioSource wrongTargetHit;
    public AudioSource menuMusic;
    public AudioSource gameMusic;

    bool menuMusicStarted = false;
    bool gameMusicStarted = false;
	
	public void TargetHitSound()
    {
        targetHit.Stop();
        targetHit.Play();
    }

    public void WrongTargetHitSound()
    {
        wrongTargetHit.Stop();
        wrongTargetHit.Play();
    }

    public void PlayMenuMusic()
    {
        gameMusic.Pause();
        if (menuMusicStarted)
        {
            menuMusic.UnPause();
        }
        else
        {
            menuMusic.Play();
            menuMusicStarted = true;
        }
    }

    public void PlayGameMusic()
    {
        menuMusic.Pause();
        if (gameMusicStarted)
        {
            gameMusic.UnPause();
        }
        else
        {
            gameMusic.Play();
            gameMusicStarted = true;
        }
    }
}
