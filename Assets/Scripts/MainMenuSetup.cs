using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuSetup : MonoBehaviour {

    //kreira instancu SceneNavigation objekta
    SceneNavigation mySceneNavigator;

    //AudioController objekt
    AudioController theAudioController;

	// Use this for initialization
	void Start () {
        Time.timeScale = 1;

        //pronalazi objekt tipa AudioController
        theAudioController = FindObjectOfType<AudioController>();

        //dodjeljuje mu objekt kojem pripada
        mySceneNavigator = FindObjectOfType<SceneNavigation>();

        //zapocnje sviranje glazbe
        theAudioController.PlayMenuMusic();

        //pokrece ucitavanje Game scene u pozadini
        StartCoroutine(mySceneNavigator.LoadGameInBackgroundCo());
    }
}
