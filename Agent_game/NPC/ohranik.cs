using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ohranik : MonoBehaviour
{
    public pause_menu pause_menu;
    private Animator anim;
    public trigers trigers;
    public Player_checker Player_checker;
    private bool shag_sdelan = false;
    public bool obuch_triger = false;
    public int tek;
    private double replic_time=5;
    private int last_replic=3;
 



    void Start()
    {
        anim = GetComponent<Animator>();

    }



    void FixedUpdate()
    {

        if (Player_checker.player_in ==true)
        {
            if (trigers.odegda != "suit" && trigers.odegda != "s_molotom" && trigers.odegda != "pizzaM")
            {
                if (shag_sdelan == false)
                {
                    anim.SetTrigger("shag");
                    transform.Translate(-0.8f, 0f, 0f);
                    shag_sdelan = true;
                    if (trigers.odegda == "pizza_zakaz") tek = 2;
                }

            }
            else
            {
                anim.SetBool("stop", true);
                tek = 1;
                if(obuch_triger==false) pause_menu.kd = 2f;
                obuch_triger = true;
            }
        }

        if (Player_checker.player_in == false)
        {

            if (trigers.odegda == "pizza_zakaz")
            {
                // if (shag_sdelan == true)
                // {
                //    anim.SetTrigger("shag");
                //    transform.Translate(-0.8f, 0f, 0f);
                //    shag_sdelan = false;

                // }

            }
            else
            {
                anim.SetBool("stop", false);
                tek = 0;

            }
        }

        if (Player_checker.takl_triger == true && Player_checker.ohran == 1)
        {
            anim.SetBool("talk", true);
            tek = last_replic;
            if (replic_time > 0) replic_time -= Time.deltaTime;
            if (replic_time <= 0) {
                
                last_replic = 4;
            }
                
                

        }
        else
        {
            anim.SetBool("talk", false);
            
             if(tek!=1&tek!=2)tek = 0;
        }
    }
}













    
