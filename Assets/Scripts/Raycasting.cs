using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycasting : MonoBehaviour {

    //definira koji sloj metoda CircleCast pogađa
    public LayerMask layerToHit;

    //radijus kruga
    float thickness = 0.3f;

    //objekt tipa GameManager
    GameManager theGameManager;

    void Start()
    {
        //nalazi objekt tipa GameManager
        theGameManager = FindObjectOfType<GameManager>();
    }

	void Update () {
        //provjerava je li aplikacija u game modu
        if (theGameManager.Status == GameManager.GameStatus.IN_GAME)
        {
            //provjerava je li igrac stisnuo na ekran
            if (Input.touchCount > 0)
            {
                //odrađuje naredbe unutar petlje za svaki prst koji igrac drzi na ekranu
                foreach (Touch t in Input.touches)
                {
                    //ispituje je li igrac upravo dodirnuo ekran
                    if (t.phase == TouchPhase.Began)
                    {
                        //baca zraku od mjesta gdje je pritisnuto prema naprijed
                        RaycastHit2D hit = Physics2D.CircleCast(Camera.main.ScreenToWorldPoint(t.position), thickness, Vector2.zero, 1, layerToHit);

                        //ispituje je li zraka nesto pogodila
                        if (hit.collider != null)
                        {
                            //definira objekt koji je pogođen
                            GameObject recepient = hit.transform.gameObject;

                            //zove metodu OnTouch() definiranu u klasi pogođenog objekta
                            recepient.SendMessage("OnTouch", hit.point, SendMessageOptions.DontRequireReceiver);
                        }
                    }
                }
            }
        }
    }
}
