using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionScript : MonoBehaviour {

    public int vida;
    public int magia;


    private void OnTriggerEnter2D(Collider2D c)
    {
        PlayerScript player = c.GetComponent<PlayerScript>();
        
        if(player != null)
        {
            player.SetVidaMagia(vida, magia);
            Destroy(gameObject);
        }
    }


	}
