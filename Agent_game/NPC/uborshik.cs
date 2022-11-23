using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class uborshik : MonoBehaviour
{
    private Animator animat;
    public bool colide = false;
    public string deistvie="piet";
    public bool beret = false;
    public bool razdet = false;
    public GameObject dialog;
    public Sprite[] dialogs;
    public bool spit = false;
    public float razTime;
    public GameObject Vodka;
    public GameObject Beer;
    void Start()
    {
        
        animat = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        if (razTime > 0) razTime -= Time.deltaTime;






        if (deistvie== "galyetsa"&& razTime<=3.9f) Beer.SetActive(true);
        if (colide == true && deistvie == "piet")
        {
            animat.SetTrigger("stavit");
            razTime = 4f;
            dialog.SetActive(true);
            deistvie = "galyetsa";
            
        }


        if(deistvie=="galyetsa" && razTime<=0)
        {
            animat.SetBool("talk", true);
            dialog.gameObject.GetComponent<SpriteRenderer>().sprite = dialogs[0];
            deistvie = "prosit";
            razTime = 8f;
        }
        if (deistvie == "prosit" && razTime <= 4)
        {
            dialog.gameObject.GetComponent<SpriteRenderer>().sprite = dialogs[1];
            
        }

        if (deistvie=="prosit"&& razTime <= 0)
        {
            deistvie = "gdet";
            dialog.SetActive(false);
            animat.SetBool("talk", false);
        }

        if (colide == true && deistvie == "gdet" && beret == true)
        {
            animat.SetTrigger("drink");
            razTime = 0.4f;
            deistvie = "xvalit";
        }
        if (deistvie == "xvalit" && razTime <= 0)
        {
            razTime = 4f;
            animat.SetBool("talk", true);
            dialog.gameObject.GetComponent<SpriteRenderer>().sprite = dialogs[2];
            dialog.SetActive(true);
            deistvie ="zasip";
        }

        if (deistvie == "zasip" && razTime <= 0)
        {
            razTime = 2f;
            animat.SetBool("talk", false);
            dialog.SetActive(false);
            spit = true;
            deistvie = "spit";
        }

        if(spit==true && razTime <= 0) Vodka.SetActive(true);

        if (spit==true && razdet == true)
        {
            animat.SetBool("razdet", true);
            
        }



        }
    void OnTriggerStay2D(Collider2D other)
    {
     if (other.CompareTag("Player"))
     {
        colide = true;
     }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        colide = false;
    }
}
