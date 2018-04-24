using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntroControllerScript : MonoBehaviour {
    public Text txtLastScore;
    public Text txtBestScore;

    private int bestScore;

    // Use this for initialization
    void Start () {
        txtLastScore.text = "Last Score: 0";
        txtBestScore.text = "Best Score: 0";
        bestScore = 0;
    }
	
	// Update is called once per frame
	void Update () {
        // Screen transition
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter)
            || Input.touchCount > 0) {
            SceneManager.LoadScene("Game");
        }

        if (GameController.gameController == null) return;

        txtLastScore.text = string.Format("Last Score: {0}", GameController.gameController.coins);

        if (GameController.gameController.coins > bestScore) {
            bestScore = GameController.gameController.coins;
        }
        txtBestScore.text = string.Format("Best Score: {0}", bestScore);
    }
}
