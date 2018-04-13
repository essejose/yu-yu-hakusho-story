using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoPupet : InimigoBase {

    public float andarDistancia;

    private bool andar;
    private bool atacar = false;



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	protected override void  Update () {

        base.Update();


        anim.SetBool("run", andar);
 


        if (Mathf.Abs(alvoDistancia) < andarDistancia)
        {
            andar = true;
        }

        if (Mathf.Abs(alvoDistancia) < distanciaAtaque)
        {

            atacar = true;
            andar = false;
        }
        
        
        /* inimgo que voa ? haha ficou legal
            if ( Mathf.Abs( alvoDistancia) < distanciaAtaque)
            {
                anim.SetBool("run",true);
                transform.position = Vector3.MoveTowards(transform.position, alvo.transform.position, velocidade * Time.deltaTime);
            }
            else
            {
                anim.SetBool("run", false);
            }
            */
        }

     private void FixedUpdate()
            {

    
                if(andar )
                {
          
                    if(alvoDistancia < 0)
                    {
                        rb.velocity = new Vector2(velocidade, rb.velocity.y);
                        if (!flipXRight)
                        {
                            Flip();
                        }
                    }
                    else
                    {
                        rb.velocity = new Vector2(-velocidade, rb.velocity.y);
                        if (flipXRight)
                        {
                            Flip();
                        }
                    }
                }
            }

        
    }
