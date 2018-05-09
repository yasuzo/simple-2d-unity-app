using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundToggle : MonoBehaviour {

    //komponenta Toggle na objektu
    Toggle soundToggle;

    //zove se nakon kreiranja objkta
    void Awake()
    {
        //nalazi na sebi komponentu Toggle
        soundToggle = GetComponent<Toggle>();

        //cita zadnje stanje sklopke koje je pohranjeno u memoriji
        if (PlayerPrefs.GetString("mute") == "true")
            soundToggle.isOn = true;
        else
            soundToggle.isOn = false;
    }

    //sklopka koja pali/gasi zvuk
    public void ToggleSound()
    {
        if (soundToggle.isOn)
        {
            //gasi zvuk i sprema stanje u memoriju
            AudioListener.pause = true;
            PlayerPrefs.SetString("mute", "true");
        }
        else
        {
            //pali zvuk i sprema stanje u memoriju
            AudioListener.pause = false;
            PlayerPrefs.SetString("mute", "false");
        }
    }

    //zove se pri aktivaciji objekta -> cita spremljeno stanje sklopke i postavlja sklopku u to stanje
    void OnEnable()
    {
        if (PlayerPrefs.GetString("mute") == "true")
            soundToggle.isOn = true;
        else
            soundToggle.isOn = false;
    }
}
