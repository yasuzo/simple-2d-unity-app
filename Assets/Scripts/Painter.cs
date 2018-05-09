using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Painter : MonoBehaviour {

    //izbor boja
    Color colorIndex_1 = new Color(0.89f, 0.22f, 0.22f);
    Color colorIndex_2 = new Color(0.96f, 0.92f, 0.41f);
    Color colorIndex_3 = new Color(0.41f, 0.55f, 0.96f);

    public void Paint(Image img, int colorIndex)
    {
        //postavlja boju na temelju indeksa
        switch (colorIndex)
        {
            case 1:
                img.color = colorIndex_1;
                break;
            case 2:
                img.color = colorIndex_2;
                break;
            case 3:
                img.color = colorIndex_3;
                break;
        }
    }

    public void Paint(SpriteRenderer rend, int colorIndex)
    {
        //postavlja boju na temelju indeksa
        switch (colorIndex)
        {
            case 1:
                rend.color = colorIndex_1;
                break;
            case 2:
                rend.color = colorIndex_2;
                break;
            case 3:
                rend.color = colorIndex_3;
                break;
        }
    }
}
