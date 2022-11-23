using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ohranik_left : MonoBehaviour
{
    private Animator anim;
    public trigers trigers;
    public Player_checker Player_checker;
    private bool shag_sdelan = false;
    public int tek;
    private double replic_time = 5;
   




    void Start()
    {
        anim = GetComponent<Animator>();

    }



    void Update()
    {

        if (Player_checker.player_in == true)
        {
            if (trigers.odegda != "suit" && trigers.odegda != "s_molotom" && trigers.odegda != "pizzaM")
            {
                if (shag_sdelan == false)
                {
                    anim.SetTrigger("shag");
                    transform.Translate(0.8f, 0f, 0f);
                    shag_sdelan = true;
                }

            }
            else
            {
                anim.SetBool("stop", true);
                
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
                

            }
        }

        if (Player_checker.takl_triger == true && Player_checker.ohran == -1)
        {
            anim.SetBool("talk", true);
            if (tek == 0) tek = 1;
           
            if (replic_time > 0) replic_time -= Time.deltaTime;
            if (replic_time <= 0&&tek<6)
            {
                tek += 1;
               
                replic_time = 5;
            }



        }
        else
        {
            anim.SetBool("talk", false);

            tek = 0;
        }
    }
}
