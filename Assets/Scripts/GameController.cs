using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {


    public int vida = 5;
    public int dano = 1;
    public int magias = 6;
    public int coins;

    public int updateTiro = 20;


    //unico
    public static GameController gameController;

    void Awake() {

        if (gameController == null) {
            gameController = this;
        }
        else {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }


    // Update is called once per frame
    void Update() {

    }
}
