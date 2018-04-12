using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {
    Animator animator;

    public float life;
    public float velocidade;
    public float impulso;

    public Transform chaoVerificador;
    public Transform chaoVerificadorEsqueda;
    public Transform chaoVerificadorDireita;

    public static bool canMove = true;

    bool estanoChao;
    bool intro = true;
    float intervalo = 0.1f;

    Rigidbody2D rb;

    SpriteRenderer spriteRenderer;

    // Use this for initialization
    void Start () {

        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();

    }
	
	// Update is called once per frame
	void Update () {

            if(canMove)
            mover();
         
    }

    void mover()
    {

            
            float mover_x = Input.GetAxisRaw("Horizontal") * velocidade * Time.deltaTime;
            transform.Translate(mover_x, 0.0f, 0.0f);

         

        if (mover_x > 0.0f)
            {
                spriteRenderer.flipX = false;

            }
            else if (mover_x < 0.0f)
            {
                spriteRenderer.flipX = true;

            }
            animator.SetFloat("run", Mathf.Abs(Input.GetAxisRaw("Horizontal")));

            estanoChao = Physics2D.Linecast(transform.position, chaoVerificadorEsqueda.position, 1 << LayerMask.NameToLayer("Piso")) || Physics2D.Linecast(transform.position, chaoVerificadorDireita.position, 1 << LayerMask.NameToLayer("Piso"));

            animator.SetBool("jump", !estanoChao);

          if (estanoChao)
                pulo();
        
            
        }

    void pulo()
    {

        if (Input.GetButtonDown("Jump"))
        {

            StartCoroutine(puloForce());
        }

    }

    IEnumerator puloForce()
    {
        ArmaScript.canFire = false;
        rb.velocity = new Vector2(0.0f, impulso);

        yield return new WaitForSeconds(.4f);
        StopCoroutine(puloForce());
        ArmaScript.canFire = true;

    } 

}
