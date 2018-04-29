using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerScript : MonoBehaviour {
    Animator animator;

    public float life;
    public float velocidade;
    public float impulso;

    public Transform chaoVerificador;
    public Transform chaoVerificadorEsqueda;
    public Transform chaoVerificadorDireita;



    public int vidaMaxima = 5;
    public float danoTempo = 1f;
    private int vida;
    private bool morto = false;
    private bool tomandoDano = false;


    public GameObject painel;
    public static bool canMove = true;




    bool estanoChao;
    bool intro = true;
    float intervalo = 0.1f;
    bool canJump = true;
    Rigidbody2D rb;
    GameController gameManager;
    SpriteRenderer spriteRenderer;

    ArmaScript arma;
   
    // Use this for initialization
    void Start () {

        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>(); 
        gameManager = GameController.gameController;

        Debug.Log("Device type : " + SystemInfo.deviceType);
 
        setPlayerStatus();
        vida = vidaMaxima;
        UpdateVidaUI();
        morto = false;
        canMove = true;
       
    }
	
	// Update is called once per frame
	void Update () {

            if(canMove)
            mover();

    }

    void mover()
    {

            
            float mover_x = CrossPlatformInputManager.GetAxisRaw("Horizontal") * velocidade * Time.deltaTime;
            transform.Translate(mover_x, 0.0f, 0.0f);

         

        if (mover_x > 0.0f)
            {
                spriteRenderer.flipX = false;

            }
            else if (mover_x < 0.0f)
            {
                spriteRenderer.flipX = true;

            }
            animator.SetFloat("run", Mathf.Abs(CrossPlatformInputManager.GetAxisRaw("Horizontal")));

            estanoChao = Physics2D.Linecast(transform.position, chaoVerificadorEsqueda.position, 1 << LayerMask.NameToLayer("Piso")) || Physics2D.Linecast(transform.position, chaoVerificadorDireita.position, 1 << LayerMask.NameToLayer("Piso"));

            animator.SetBool("jump", !estanoChao);

          if (estanoChao)
                pulo();
        
            
        }

    void pulo()
    {

       
        if (CrossPlatformInputManager.GetAxisRaw("Vertical") > 0.92 && estanoChao && canJump)
        {
            canJump = false;
            StartCoroutine(puloForce());
        }
        

    }

    IEnumerator puloForce()
    {
      
        ArmaScript.canFire = false;
        rb.velocity = new Vector2(0.0f, impulso);

        yield return new WaitForSeconds(.9f);
        StopCoroutine(puloForce());
        ArmaScript.canFire = true;
        canJump = true;
        yield return new WaitForSeconds(1f);

    }


    IEnumerator TomandoDano()
    {
        tomandoDano = true;
        vida--;
        UpdateVidaUI();
        if(vida <= 0)
        {
            morto = true;
            /* TODO: fazer ele morrendo*/ 
            canMove = false;


            if (morto)
            {

                animator.SetBool("death", morto); 
                Invoke("RecarregarScene", 2f);
            }
        }
        else
        {
            Physics2D.IgnoreLayerCollision(9, 10,true);
            for (float i = 0; i < danoTempo; i += 0.2f){
                spriteRenderer.enabled = false;
                yield return new WaitForSeconds(0.1f);
                spriteRenderer.enabled = true;
                yield return new WaitForSeconds(0.1f);
            }
            Physics2D.IgnoreLayerCollision(9, 10, false);

            tomandoDano = false;
        }
    }

    public void RecarregarScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }



    public void SetVidaMagia(int lifePotion, int magiaPotion)
    {
        vida += lifePotion;
        
        if(vida >= vidaMaxima)
        {
            vida = vidaMaxima;
        }

        /*TODO: CORRRIGIR :( */
        ArmaScript.magia += magiaPotion; 
        FindObjectOfType<UIController>().UpdateMagiaUI(ArmaScript.magia);
        UpdateVidaUI();
    }

    public void setPlayerStatus()
    {
        vida = gameManager.vida;
    }

    void UpdateVidaUI()
    {
        FindObjectOfType<UIController>().UpdateVidaUI(vida);
    }
    void UpdateCoinsUI()
    {
        FindObjectOfType<UIController>().UpdateCoinUI();
    }

    private void OnTriggerEnter2D(Collider2D c)
    {
        print(c.gameObject.tag);
        if((c.CompareTag("inimigo") || c.CompareTag("boss")) && !tomandoDano)
        {
            StartCoroutine(TomandoDano());
        }
    }


    private void OnCollisionEnter2D(Collision2D c)
    {
        print(c.gameObject.tag);
        if (c.gameObject.CompareTag("inimigo") && !tomandoDano)
        {
            StartCoroutine(TomandoDano());
        }
        else if (c.gameObject.CompareTag("coin"))
        {
            c.gameObject.GetComponent<AudioSource>().Play();
          
            gameManager.coins += 1;
            UpdateCoinsUI();
            Destroy(c.gameObject,0.1f);
        }
         if (c.gameObject.tag == "darkcoin")
        {
            Destroy(c.gameObject); 
            painel.SetActive(true);
        }

    }


}
