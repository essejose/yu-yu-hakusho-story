using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoBase : MonoBehaviour {

    public int vida;
    public float velocidade;
    public float distanciaAtaque;

    public GameObject coin;
    public GameObject animacaoMorte;
    public GameObject player;

    protected Animator anim;
    protected bool flipXRight = true;
    protected Transform alvo; 
    protected float alvoDistancia;
    protected Rigidbody2D rb;
    protected SpriteRenderer sprite;

    void Awake()
    {
        anim = GetComponent<Animator>();
        alvo = player.gameObject.transform;
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    protected virtual void Update()
    {
        alvoDistancia = transform.position.x - alvo.position.x;
    }


   protected void Flip()
   {
        flipXRight = !flipXRight;

        Vector3 scale = transform.localScale;
        scale.x *= -1; ;
        transform.localScale = scale;
   }
    public void levaDano(int dano)
    {
        vida -= dano;
        print(dano);
        if (vida <= 0)
        {
            print("morreu");
            Instantiate(coin, transform.position, transform.rotation);
            Instantiate(animacaoMorte, transform.position, transform.rotation);

            gameObject.SetActive(false);
        }
        else
        {
            print("dano");
            StartCoroutine(levaDanoCoRoutine());
        }

    }

    IEnumerator levaDanoCoRoutine()
    {
        print(flipXRight);


      
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        sprite.color = Color.white;
       
        yield return new WaitForSeconds(4f);
        rb.velocity = new Vector2(0, 0);
        alvoDistancia = 0f;
        yield return new WaitForSeconds(4f);


    }
}
