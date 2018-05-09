using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour {

    //kreira instancu DontDestroyOnLoad objekta
    public static DontDestroyOnLoad instance = null;

    //izvrsava se pri pokretanju i koristi za inicijalizaciju
    void Awake()
    {
        instance = this;

        //naređuje da se ovaj objekt ne smije unistiti po prijelazu scena
        DontDestroyOnLoad(gameObject);
    }
}
