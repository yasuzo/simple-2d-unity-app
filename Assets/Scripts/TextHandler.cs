using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextHandler : MonoBehaviour {

    ScoreManager theScoreManager;
    GameManager theGameManager;

    Text thisText;

    // Use this for initialization
    void Start()
    {
        theScoreManager = FindObjectOfType<ScoreManager>();
        theGameManager = FindObjectOfType<GameManager>();

        thisText = GetComponent<Text>();
    }

    public enum WhatToWrite
    {
        SCORE,
        HIGHSCORE,
        TIME_LEFT
    }

    public WhatToWrite write;

    public void Update()
    {
        switch (write)
        {
            case WhatToWrite.SCORE:
                thisText.text = theScoreManager.Score.ToString();
                break;
            case WhatToWrite.HIGHSCORE:
                thisText.text = theScoreManager.Highscore.ToString();
                break;
            case WhatToWrite.TIME_LEFT:
                thisText.text = theGameManager.TimeLeft.ToString();
                break;
        }
    }
}
