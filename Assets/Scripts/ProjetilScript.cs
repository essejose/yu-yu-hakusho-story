using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjetilScript : MonoBehaviour {

    public float velocidade;
    public float tempoDeVida;
    public int dano = 1;
    public GameObject explosao;

    SpriteRenderer spriteRenderer;


    // Use this for initialization
    void Start()
    {
        AudioSource audio = GetComponent<AudioSource>();
        Destroy(gameObject, tempoDeVida);

        audio.Play();
    }
    // Update is called once per frame
    void Update()
    {


        transform.Translate(Vector2.right * velocidade * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D c)
    {
       
        if (c.gameObject.tag == "inimigo" || c.gameObject.tag == "boss")
        {

            c.gameObject.GetComponent<InimigoBase>().levaDano(dano);
        }


    }
    void OnTriggerEnter2D(Collider2D c)
    {

        InimigoBase outroInimigo = c.GetComponent<InimigoBase>();

        if (c.gameObject.tag == "inimigo")
        {
            
            outroInimigo.levaDano(dano);
        }


        
        if (c.gameObject.tag == "subInimigo")
        {

            //	Instantiate (explosao, transform.position,transform.rotation);



            Destroy(c.gameObject);
            Destroy(gameObject);
            //PontuacaoScript.score++;

        }

    }

}
