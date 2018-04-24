using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoPupet : InimigoBase {

    public float andarDistancia;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    protected override void Update() {
        if (morreu) return;

        base.Update();


        if (vida <= 0) {
            anim.SetBool("run", false);
            anim.SetBool("isAttack", false);
            anim.Play("bossGolemDeath");
            morreu = true;
        }
        else {
            anim.SetBool("run", Mathf.Abs(alvoDistancia) < andarDistancia);
            anim.SetBool("isAttack", Mathf.Abs(alvoDistancia) < distanciaAtaque);
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

    private void FixedUpdate() {


        if (Mathf.Abs(alvoDistancia) < andarDistancia && Mathf.Abs(alvoDistancia) >= distanciaAtaque) {

            if (alvoDistancia < 0) {
                rb.velocity = new Vector2(velocidade, rb.velocity.y);
                if (!flipXRight) {
                    Flip();
                }
            }
            else {
                rb.velocity = new Vector2(-velocidade, rb.velocity.y);
                if (flipXRight) {
                    Flip();
                }
            }
        }
    }


}
