using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropArranger : MonoBehaviour {

    //objekt koji ce se kreirati
    public GameObject theDrop;

    //runda/nivo na kojem je igrac
    public int round;

    //broj kockica koje ce se instancirati
    public int startingNumber;
    public int numberPerLevel;

    //granice unutur kojih ce objekt biti stvoren
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    //X i Y koordinate mjesta na kojem ce objekt biti stvoren
    float posX, posY;

    // Use this for initialization
    void Start () {

        //stvara određeni broj kockica
        for(int i = 0; i < startingNumber; i++)
        {
            //X i Y koordinate se nasumicno biraju unutar granica
            posX = Random.Range(minX, maxX);
            posY = Random.Range(minY, maxY);

            //instancira objekt
            Instantiate(theDrop, new Vector2(posX, posY), transform.rotation);
        }

	}
	
    //instancira jos kockica ako je potrebno
    public void InstantiateMore()
    {
        //stvara određeni broj kockica
        for (int i = 0; i < numberPerLevel; i++)
        {
            //X i Y koordinate se nasumicno biraju unutar granica
            posX = Random.Range(minX, maxX);
            posY = Random.Range(minY, maxY);

            //instancira objekt
            Instantiate(theDrop, new Vector2(posX, posY), transform.rotation);
        }
    }


    //kada kocka prijeđe granicu vidljivosti
    public void OnDropExit(GameObject obj)
    {
        //X i Y koordinate se nasumicno biraju unutar granica
        posX = Random.Range(minX, maxX);
        posY = Random.Range(minY, maxY);

        //vraca objekt(kocku) na vrh na nasumicno odabranu lokaciju
        obj.transform.position = new Vector2(posX, posY);

        //obnavlja kocku
        obj.GetComponent<Drop>().Renew();
    }

    //funkcija koja ce se pozvati po zavrsetku igre
    //ponovno ce pozicionirati kocku i obnoviti ju
    public void OnGameEnd()
    {
        Drop[] drops = FindObjectsOfType<Drop>();

        foreach(Drop d in drops)
        {
            //X i Y koordinate se nasumicno biraju unutar granica
            posX = Random.Range(minX, maxX);
            posY = Random.Range(minY, maxY);

            //vraca objekt(kocku) na vrh na nasumicno odabranu lokaciju
            d.transform.position = new Vector2(posX, posY);

            d.Renew();
        }
    }
}
