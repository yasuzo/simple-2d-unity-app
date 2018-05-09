using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour {

    //definicija objekta DropArranger
    DropArranger theDropArranger;

    //definicija objekta ScoreManager
    ScoreManager theScoreManager;

    //definicija objekta Painter;
    Painter thePainter;

    //definira komponente objekta
    SpriteRenderer mySpriteRenderer;
    Rigidbody2D myRigidbody;

    //definira najmanju i najvecu brzinu kocke
    float minVelocity = -6;
    float maxVelocity = -3;

    //oznaka boje kocke
    public int ColorIndex { get; set; }

	// Use this for initialization
	void Awake () {
        //nalazi objekt sa skriptom DropArranger na sebi
        theDropArranger = FindObjectOfType<DropArranger>();

        //nalazi objekt sa skriptom ScoreManager na sebi
        theScoreManager = FindObjectOfType<ScoreManager>();

        //nalazi objekt sa skriptom Painter na sebi
        thePainter = FindObjectOfType<Painter>();

        //nalazi gore definirane komponente 
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        myRigidbody = GetComponent<Rigidbody2D>();


        //poziva funkciju renew kako bi ona inicirala boju objekta
        Renew();
	}
	
	// Update is called once per frame
	void Update () {
        //ispituje je li kocka izasla iz vidljivosti kamere
        if (transform.position.y < -6)
        {
            //ako je izasla, zove metodu OnDropExit()
            theDropArranger.OnDropExit(gameObject);
        }
    }

    // FixedUpdate is called multiple times per frame
    void FixedUpdate()
    {
        //azurira brzinu -> dobiva se na glatkoci prijelaza
        myRigidbody.velocity = myRigidbody.velocity;
    }

    //metoda koja se poziva kada igrac pritisne na kocku
    void OnTouch()
    {
        //zove metodu ScoreManager-a 
        theScoreManager.ObjectHit(ColorIndex);

        //zove metodu OnDropExit() koja vraca objekt iznad ekrana
        theDropArranger.OnDropExit(gameObject);
    }

    //metoda za obnavljanje kocke
    public void Renew()
    {
        // postavlja indeks boje
        ColorIndex = Random.Range(1, 4);

        //postavlja brzinu kocke
        myRigidbody.velocity = new Vector2(0, Random.Range(minVelocity, maxVelocity));

        //postavlja boju na temelju indeksa
        thePainter.Paint(mySpriteRenderer, ColorIndex);
    }
}
