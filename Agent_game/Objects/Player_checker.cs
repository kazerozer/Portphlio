using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_checker : MonoBehaviour
{
    public bool player_in = false;
    public bool takl_triger = false;
    private double full_talk_time;
    private double talk_time=5;
    public double kd;
    public bool kd_start=false;
    public int ohran=1;
    private bool skazano=false;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {

             player_in = true;
             
}
    }
    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {

            player_in = false;
            if (skazano == false)
            {
                kd_start = true;
                full_talk_time = 35;
                skazano = true;
            }
            


        }
    }
    void FixedUpdate()
    {
        if(kd<=0) takl_triger = true;
        if (takl_triger == true)
        {
            full_talk_time -= Time.deltaTime;
            if (full_talk_time > 0)
            {
                talk_time -= Time.deltaTime;
                if (talk_time <= 0&&ohran==1)
                {
                  ohran *= -1;
                  talk_time = 20;
                }
                if (talk_time <= 0 && ohran == -1)
                {
                    ohran *= -1;
                    talk_time = 10;
                }
            }
            if (full_talk_time <= 0) takl_triger = false;
        }

        if (kd > 0 && kd_start == true)kd-= Time.deltaTime;
    }
    }