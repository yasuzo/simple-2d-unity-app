using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

    //u svrhu popravljanja greske s timerom -> da ne oduzima vrijeme ako je igra pauzirana
    //i u svrhu odeđivanja statusa igre
    GameManager theGameManager;

    //objekt tipa AudioController
    AudioController theAudioController;

    //definicija svojstava
    public int Score { get; set; }
    public int Highscore { get; set; }
    public int TargetColorIndex { get; set; }

    //koristi se za multipliciranje rezultata kod zaredanih pogodaka
    int scoreMultiplier = 0;
    int multiplyWith = 15;
    float multiplicationTimer = 0;
    float timerStartPoint = 1;

    //koliko će igraču biti dodjeljeno bodova kod svakog dobrog pogotka
    int scoreStep = 10;

	// Use this for initialization
	void Start () {
        //pronalazi objekt tipa AudioController
        theAudioController = FindObjectOfType<AudioController>();

        ResetAllButHighscore();

        //ucitava najbolji rezultat iz memorije
        Highscore = PlayerPrefs.GetInt("Highscore");
	}

    /*posto objekt ScoreManager nastaje prije GameManager objekta, 
    ne moze odmah varijabli theGameManager dodjeliti vrijednost. 
    Zato ce GameManager kad bude kreiran pozvati ovu funkciju 
    koja ce onda dodjeliti vrijednost.*/
    public void AssignGameManager()
    {
        theGameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        if (theGameManager != null)
        {
            if (theGameManager.Status == GameManager.GameStatus.IN_GAME)
            {
                //timer koji oznacava koliko vremena treba proci prije nego sto se igracev niz pogodaka resetira
                multiplicationTimer -= Time.unscaledDeltaTime;
            }
        }

        if (multiplicationTimer < 0)
        {
            ResetMultiplierAndGiveBonus();
        }
            
    }
	
    //radi reset
	public void ResetScore()
    {
        scoreMultiplier = 0;
        Score = 0;
    }

    //sprema najbolji rezultat
    void SaveHighscore()
    {
        //provjerava je li trenutni rezultat veci od sadasnjeg najboljeg
        if (Score > Highscore)
        {
            Highscore = Score;
            PlayerPrefs.SetInt("Highscore", Highscore);
        }
    }

    //provjerava je li igrac zasluzio dobiti bodove
    public void ObjectHit(int colorIndex)
    {
        //je li pogođena meta ispravne boje
        if(colorIndex == TargetColorIndex)
        {
            AddScore();

            //izvodi zvuk
            theAudioController.TargetHitSound();
        }
        else
        {
            //vibrira
            Handheld.Vibrate();
            //izvodi zvuk
            theAudioController.WrongTargetHitSound();
            //oduzima vrijeme
            theGameManager.TimeLeft -= 5;
            
            ResetMultiplierAndGiveBonus();
        }
    }

    //dodjeljuje bodove
    void AddScore()
    {
        //vraca timer ponovno na 1
        multiplicationTimer = timerStartPoint;
        //povecava score multiplier za 1
        scoreMultiplier++;
        //dodjeljuje bodove za pogodak
        Score += scoreStep;
    }

    //resetira vrijednost varijable scoreMultiplier
    public void ResetMultiplierAndGiveBonus()
    {
        Bonus();
        scoreMultiplier = 0;
        multiplicationTimer = 0;
    }

    //funkcija koja ce se izvrsiti po zavrsetku igre (sprema najbolji rezultat i resetira trenutni)
    public void OnGameEnd()
    {
        SaveHighscore();
        ResetScore();
        ResetMultiplierAndGiveBonus();
    }

    //dodaje bonus ako je igrac pogodio vise kockica zaredom u određenom vremenskom periodu
    private void Bonus()
    {
        if(scoreMultiplier >= 2)
            Score += multiplyWith * scoreMultiplier;
    }

    //resetira kljucne varijable
    public void ResetAllButHighscore()
    {
        Score = 0;
        scoreMultiplier = 0;
        multiplicationTimer = 0;
    }
}
