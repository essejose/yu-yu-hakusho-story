using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlinkEffectOnTextScript : MonoBehaviour {
    public float speed = 0.4f;
    
    private Text myText;
    private string textToFlash;

    // Use this for initialization
    void Start () {
        myText = GetComponent<Text>();
        textToFlash = myText.text;
        //Call coroutine BlinkText on Start
        StartCoroutine(BlinkText());
    }

    IEnumerator BlinkText() {
        while (true) {
            myText.text = (myText.text == "") ? textToFlash : "";

            yield return new WaitForSeconds(speed);
        }
    }
}
