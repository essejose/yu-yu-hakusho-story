using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    public Text magiaText;
    public Text coinText;
    public Text vidaText;

    public Slider barraDeVida;

    // Use this for initialization
    void Start () {
        //  UpdatebarraDeVida();
        UpdateCoinUI();

    }
	
	
    public void UpdateMagiaUI( int magia)
    {
        magiaText.text = magia.ToString();
    }

    public void UpdateCoinUI()
    {
        coinText.text = GameController.gameController.coins.ToString();
    }


    public void UpdateVidaUI(int vida)
    {

        vidaText.text = vida.ToString();
        barraDeVida.value = vida;
    }

    public void UpdatebarraDeVida()
    {
 
        barraDeVida.maxValue = GameController.gameController.vida;
    }
}
