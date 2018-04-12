using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaScript : MonoBehaviour {
 
    public GameObject projetil;
    public GameObject projetil2;
    public GameObject sensorRotacao;
    public GameObject player;

    public static   bool canFire = true;

    Animator animator;
   
        void Start()
        {
            animator = player.GetComponent<Animator>();
        }
        // Update is called once per frame
        void Update () {

        if (canFire)
        {
            if (Input.GetButtonUp("Fire1"))
            {
                canFire = false;
                StartCoroutine(socos());

            }
            if (Input.GetButtonUp("Fire2"))
            {
                canFire = false;
                StartCoroutine(fire());

            }
        }
       
        if (Input.GetAxisRaw("Horizontal") > 0.0f)
        {

            sensorRotacao.transform.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
        }
        else if (Input.GetAxisRaw("Horizontal") < 0.0f)
        {

            sensorRotacao.transform.eulerAngles = new Vector3(0.0f, 180.0f, 0.0f);

        }

    }
    IEnumerator socos()
    {



        PlayerScript.canMove = false;

        animator.SetBool("isSoco", true);
        yield return new WaitForSeconds(.1f);
        Instantiate(projetil2, transform.position, transform.rotation);
      
       
        yield return new WaitForSeconds(.4f);
        PlayerScript.canMove = true;
        animator.SetBool("isSoco", false);
        StopCoroutine(socos());
        canFire = true;
    }


    IEnumerator fire()
    {



        PlayerScript.canMove = false;

        animator.SetBool("isFire", true);
        yield return new WaitForSeconds(.4f);
        Instantiate(projetil, transform.position, transform.rotation); 
        animator.SetBool("isFire", false);
        PlayerScript.canMove = true;
        yield return new WaitForSeconds(.1f);
        StopCoroutine(fire());
        canFire = true;
    }

     
}
