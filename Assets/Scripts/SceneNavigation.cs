using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneNavigation : MonoBehaviour {

    //async operacija
    AsyncOperation async;

    //pokrece MainMenu scenu
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    //pokrece Credit scenu sa zakasnjenjem
    public void LoadCreditsWithDelay()
    {
        //brise Game scenu koja je ucitana u pozadini (aplikacija bi se inace srusila) 
        SceneManager.UnloadSceneAsync("Game");

        //zove korutinu
        StartCoroutine("LoadCreditsWithDelayCo");
    }

    //korutina koja zapravo pokrece Credit scenu
    private IEnumerator LoadCreditsWithDelayCo()
    {
        //ceka prije nego sto pokrene scenu
        yield return new WaitForSeconds(0.09f);

        //pokrece Credit scenu
        SceneManager.LoadScene("Credits");
    }

    //GAME SCENA
    public IEnumerator LoadGameInBackgroundCo()
    {
        //ucitava Game scenu u pozadini
        async = SceneManager.LoadSceneAsync("Game");

        //ne dozvoljava da se Game scene pokrene odmah nakon zavrsetka ucitavanja vec ceka da korisnik klikne na Play
        async.allowSceneActivation = false;
        yield return async;
    }

    //dozvoljava Game sceni da bude pokrenuta
    private void GameAllowedToStart()
    {
        async.allowSceneActivation = true;
    }

    //pokrece Game scenu sa zakasnjenjem
    public void LoadGameWithDelay()
    {
        StartCoroutine("LoadGameWithDelayCo");
    }

    //korutina koja zapraco pokrece Game scenu sa zakasnjenjem
    public IEnumerator LoadGameWithDelayCo()
    {
        //ceka prije nego sto pokrene scenu
        yield return new WaitForSeconds(0.09f);

        GameAllowedToStart();
    }

    //pokrece Shop scenu sa zakasnjenjem
    public void LoadShopWithDelay()
    {
        //brise Game scenu koja je ucitana u pozadini (aplikacija bi se inace srusila) 
        SceneManager.UnloadSceneAsync("Game");

        StartCoroutine("LoadShopWithDelayCo");
    }

    //korutina koja zapravo pokrece Shop scenu
    private IEnumerator LoadShopWithDelayCo()
    {
        //ceka prije nego sto pokrene scenu
        yield return new WaitForSeconds(0.09f);
        SceneManager.LoadScene("Shop");
    }

    //gasi aplikaciju
    public void Quit() {

        Application.Quit();

    }
}
