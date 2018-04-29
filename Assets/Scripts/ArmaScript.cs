using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;
public class ArmaScript : MonoBehaviour {
 
    public GameObject projetil;
    public GameObject projetil2;
    public GameObject sensorRotacao;
    public GameObject player;
    public GameObject botao1;
    public GameObject botao2;
    public static bool canFire = true;
    public static int magia;

 
     Animator animator;
   
        void Start()
        {
            animator = player.GetComponent<Animator>();
            magia = GameController.gameController.magias;
            UpdateMagiaUI();
        canFire = true;
        botao1.GetComponent<Button>().onClick.AddListener(tiro1);
        botao2.GetComponent<Button>().onClick.AddListener(tiro2);
    }
        // Update is called once per frame
        void Update () {


                if (canFire)
                {
                  
                    if (Input.GetButtonUp("Fire2") && magia > 0)
                    {
                        canFire = false;

                        StartCoroutine(fire());
                        magia--;
                        UpdateMagiaUI();
                    }
                }
       
                if (CrossPlatformInputManager.GetAxisRaw("Horizontal") > 0.0f)
                {

                    sensorRotacao.transform.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
                }
                else if (CrossPlatformInputManager.GetAxisRaw("Horizontal") < 0.0f)
                {

                    sensorRotacao.transform.eulerAngles = new Vector3(0.0f, 180.0f, 0.0f);

                }

        }
    IEnumerator socos()
    {



        PlayerScript.canMove = false;

        animator.SetBool("isSoco", true);
        yield return new WaitForSeconds(.2f);
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

    public void tiro1()
    {
        if (canFire)
        {
            canFire = false;
            StartCoroutine(socos());
        }
            
     }
    public void tiro2()
    {
        if (canFire && magia > 0)
        { 
                
                canFire = false;

                StartCoroutine(fire());
                magia--;
                UpdateMagiaUI();
             
           
        }

    }
    public void UpdateMagiaUI()
    {
        FindObjectOfType<UIController>().UpdateMagiaUI(magia);
    }
}
