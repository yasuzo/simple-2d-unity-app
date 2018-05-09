using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Preloader : MonoBehaviour {

	// Use this for initialization
	void Start () {

        //kaze uređaju da proba vrtiti igru na 60 fps-a
        Application.targetFrameRate = 60;

        //pokrece korutinu
        StartCoroutine(ProceedToMainMenu());
	}

    //po zavrsetku animacije nastavlja na MainMenu scenu
    IEnumerator ProceedToMainMenu()
    {
        //ceka 4 sekunde
        yield return new WaitForSeconds(4);

        //pokrece MainMenu scenu
        SceneManager.LoadScene("MainMenu");
    }
}
