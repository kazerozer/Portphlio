using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pizza_seller : MonoBehaviour
{

    public Pizza_prilavok Pizza_prilavok;
    public podsobka_dver podsobka_dver;
    public int tek = 1;
    public double dialog_time;
    public truba truba;
    private Animator anim;
    public bool poshol = false;
    public bool colide = false;
    public trigers trigers;


    void Start()
    {

        anim = GetComponent<Animator>();
    }




    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            colide = true;
            if (trigers.posY > this.gameObject.transform.position.y)
                this.gameObject.GetComponent<Renderer>().sortingOrder = 6;
            if (trigers.posY < this.gameObject.transform.position.y)
                this.gameObject.GetComponent<Renderer>().sortingOrder = 1;
        }
    }

 

    public void FixedUpdate()
    {
        if (dialog_time>0)dialog_time -= Time.deltaTime;
        if (Pizza_prilavok.playerIn == true)
        {
            if (truba.brake == false) tek = 1;
            dialog_time = 2;
        }
        else if (podsobka_dver.playerIn == true)
        {
            if (truba.brake == false) tek = 2;
        }
        else if(tek != 3&&dialog_time<0)tek = 0;
        

        if (poshol==true)
        {
            if (transform.position.x < 22.3529)
            {
                anim.SetBool("react", true);
                transform.Translate(0.15f, -0.007f, 0f);
            }
            else
            {
                anim.SetBool("doshol", true);
                tek = 0;
            }
        }

        
            if (trigers.skazano==true)
            {
                if (truba.brake == true)
                {
                    poshol = true;
                    tek = 3;
                }
            }
        }
    }

        
    



