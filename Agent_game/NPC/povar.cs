using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class povar : MonoBehaviour
{
    private Animator anim;
   // private Animator KRanim;
    public trigers trigers;
    public Player_In_cheker Player_In_cheker;
   public GameObject krisa;
    public bool krisaShoUp = false;
    public GameObject dialogs;
    public double dialog_time;
    //public Transform[] moveSpot;
    public double wait_time;
   // public int i;
    public bool krisa_triger = false;
    public bool pers_ofic_triger = false;
    public bool talk = false;
    public bool dialog_triger = false;
    public bool pov_dialog_triger = false;
   
    public int tek = 1;

    
    void Start()
    {
        anim = GetComponent<Animator>();
        //KRanim = krisa.GetComponent<Animator>();

    }

   
    void FixedUpdate()
    {
        if (dialog_time > 0) dialog_time -= Time.deltaTime;
        if (wait_time > 0) wait_time -= Time.deltaTime;

        if(trigers.odegda == "pizza_zakaz" && Player_In_cheker.player_in ==true)
        {
            anim.SetBool("ukaz", true);
            dialogs.SetActive(true);

        }
           

                if (trigers.KrisaShow == true) { 
                    
                    tek = 2;
                    krisa_triger = true;
                    dialog_time = 7;
                    anim.SetBool("ukaz", false);
                    dialogs.SetActive(false);
                    wait_time = 3;
                    trigers.KrisaShow = false;



                }

        if (pers_ofic_triger == true && dialog_time>0)
        {
            tek = 7;
        }
        if (pers_ofic_triger == true && dialog_time <= 0)
        {
            tek = 8;
        }

        if (krisa_triger == true)
        {

            if (wait_time < 2.5) krisa.SetActive(true);
            if (dialog_time<2)
            {

                krisaShoUp = true;

            }
            if (dialog_time > 0 && wait_time<=0)
            {
                dialogs.SetActive(true);
                anim.SetBool("rat", true);



            }
            if (dialog_time <= 0)
            {
                tek++;
                krisa_triger = false;
                krisa.SetActive(false);
                anim.SetBool("rat", false);
                pov_dialog_triger = true;
                

            }

        }
      
        if(pov_dialog_triger == true)
       {

            if (dialog_time > 0 && wait_time <= 0)
            {
                dialogs.SetActive(true);
                anim.SetBool("slushat", true);
                anim.SetBool("talk", true);


            }
            if (dialog_time <=0 && wait_time<=0 && talk==true)
        {
            dialogs.SetActive(false);
                anim.SetBool("talk", false);

                wait_time = 6;
            talk = false;
            if(tek<6)tek++;
                if (tek == 6)
                {
                    pov_dialog_triger = false;
                    anim.SetBool("slushat", false);
                }

        }
        if (wait_time <= 0 && dialog_time<=0)
        {
            dialog_time = 5;
            talk = true;

        }
      }
        if(trigers.pereodet==true) dialogs.SetActive(true);
        if (trigers.odegda == "oficiant_food") dialogs.SetActive(false);
    }




    

}
