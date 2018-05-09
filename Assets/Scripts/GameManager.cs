using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    //objekti koji ce se trebati aktivirati/deaktivirati
    public GameObject gameOverMenu;
    public GameObject pauseMenu;
    public GameObject playModeUI;
    public GameObject notInPlayModeUI;
    public GameObject colorPick;

    //objekti cije ce funkcije trebati biti pozvane
    ScoreManager theScoreManager;
    DropArranger theDropArranger;
    Painter thePainter;
    AudioController theAudioController;

    //definira moguce statuse aplikacije
    public enum GameStatus
    {
        IN_GAME,
        PAUSED,
        OVER,
        NULL
    }

    //varijabla u kojoj ce status biti pohranjen
    public GameStatus Status;

    //vrijeme do isteka runde
    public float TimeLeft { get; set; }

	// Use this for initialization
	void Start () {
        //trazi objekte te dodjeljuje vrijednosti definiranim varijablama
        theScoreManager = FindObjectOfType<ScoreManager>();
        theDropArranger = FindObjectOfType<DropArranger>();
        thePainter = FindObjectOfType<Painter>();
        theAudioController = FindObjectOfType<AudioController>();

        //zove funkciju u ScoreManager objektu koja ce dodjeliti vrijednost varijabli theGameManager u ScoreManager skripti
        theScoreManager.AssignGameManager();

        //zapocinje igru
        GameStart();
	}

    //naređuje koja ce boja trebati biti pogođena
    void SetTargetColor()
    {
        //nasumicno bira boju
        theScoreManager.TargetColorIndex = Random.Range(1, 4);

        //zove metodu Paint() koja ce obojati sliku kruga u animaciji u boju koja ce trebati biti pogođena
        thePainter.Paint(colorPick.transform.GetChild(1).gameObject.GetComponent<Image>(), theScoreManager.TargetColorIndex);
    }
	
	// Update is called once per frame
	void Update () {
        if (Status == GameStatus.IN_GAME)
        {
            if (TimeLeft > 0)
            {
                TimeLeft -= Time.deltaTime;
            }
            else {
                TimeLeft = 0;
                GameOver();
            }
        }

	}

    //poziva se pri kraju igre
    void GameOver()
    {
        theAudioController.PlayMenuMusic();

        Status = GameStatus.OVER;

        playModeUI.SetActive(false);
        notInPlayModeUI.SetActive(true);

        gameOverMenu.SetActive(true);

        //theDropArranger.OnGameEnd();
        //theScoreManager.OnGameEnd();
    }

    //poziva se pri pocetku nove igre
    public void GameStart()
    {
        theAudioController.PlayGameMusic();

        Time.timeScale = 1;
        Status = GameStatus.NULL;

        theDropArranger.OnGameEnd();
        theScoreManager.OnGameEnd();

        pauseMenu.SetActive(false);
        gameOverMenu.SetActive(false);
        notInPlayModeUI.SetActive(false);
        playModeUI.SetActive(true);

        theScoreManager.ResetAllButHighscore();

        SetTargetColor();

        TimeLeft = 30;
        colorPick.GetComponent<Animation>().Stop();
        colorPick.GetComponent<Animation>().Play();

        Invoke("SetStatus_IN_GAME", 3);
    }

    void SetStatus_IN_GAME()
    {
        Status = GameStatus.IN_GAME;
    }


    //zapocinje pauzu
    public void PauseGame()
    {
        theAudioController.PlayMenuMusic();

        Status = GameStatus.PAUSED;

        Time.timeScale = 0;

        playModeUI.SetActive(false);
        notInPlayModeUI.SetActive(true);
        pauseMenu.SetActive(true);
    }

    //prekida pauzu
    public void CancelPause()
    {
        theAudioController.PlayGameMusic();

        Status = GameStatus.IN_GAME;

        pauseMenu.SetActive(false);
        notInPlayModeUI.SetActive(false);
        playModeUI.SetActive(true);

        Time.timeScale = 1;
    }
}
