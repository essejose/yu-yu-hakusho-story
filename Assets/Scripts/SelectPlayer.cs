
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class SelectPlayer : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{

    public bool blocked;

    public void OnPointerDown(PointerEventData eventData)
    {

        SceneManager.LoadScene("Game");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
         
    }


    // Update is called once per frame
    void Update () {
		
	}
}
