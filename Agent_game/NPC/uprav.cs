using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class uprav : MonoBehaviour
{
    private Animator anim;
    public trigers trigers;
    public uborshik uborshik;
    public bool propusk=false;
    public int tek=0;
    public string deistv;
    public float zvonok=4;
    public float razgovTime;
    private bool zvonok_sdelan = false;
  



    void Start()
    {
        anim = GetComponent<Animator>();
    }


    void FixedUpdate()
    {
        if(zvonok_sdelan== true && zvonok>0)zvonok-= Time.deltaTime;
        if (razgovTime > 0) razgovTime -= Time.deltaTime;
        if (trigers.vPente == true) deistv = "skazano";
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && deistv!="skazano")
        {
            if(trigers.odegda == "pizza_zakaz")
            {
                anim.SetBool("pokaz_left", true);
          
                tek = 1;
            }

           
            if (trigers.odegda == "oficiant"&& uborshik.deistvie != "gdet")
            {
                if (zvonok > 0)
                {
                    if (zvonok_sdelan==false)anim.SetTrigger("telefon");
                    zvonok_sdelan = true;
                    tek = 2;
                }
                else
                {
                    anim.SetBool("pokaz_right", true);
                    tek = 3;
                }
            
            }
            if (trigers.odegda == "oficiant_food" && propusk == false)
            {

                tek = 7;
                razgovTime = 4;
                propusk = true;

            }

            if (trigers.odegda == "oficiant_food" && deistv == "povtor") tek = 7;

            if (trigers.odegda == "uborshik") tek = 4;

            if (trigers.odegda == "s_Vedrom"&& propusk==false)
            {
                tek = 5;
                razgovTime = 4;
                propusk = true;
            }
            if (trigers.odegda == "s_Vedrom" && deistv == "povtor") tek = 5;

            if (propusk==true && razgovTime <= 0 && deistv!="povtor")
            {
                tek = 6;
                
                
            }
           


        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            anim.SetBool("pokaz_left", false);
            anim.SetBool("pokaz_right", false);
            if (trigers.odegda == "s_Vedrom" || trigers.odegda == "oficiant_food") deistv = "povtor";
            tek = 0;
            
        }
    }


}
