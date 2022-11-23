using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Действия и реакция официанта в ресторане

public class oficiant : MonoBehaviour
{
    private Animator anim;
    public float speed;
    public povar povar;
    public CAMERA CAMERA;
    public shitok shitok;
    public Palevo Palevo;
    public trigers trigers;
    public double dialog_time;
    public GameObject dialogs;
    public bool talk = false;
    public double wait_time=6;
    public int tek=0;
    public Transform[] moveSpots;
    public int pos;
    public bool ko = false;
    public string deistvie;
    public float kd;
    public float Dumaetkd;

    public int proverk1 = 0;
    public int proverk2 = 0;

    public bool poshol = false;
    public bool colide = false;
    public bool timekd = false;
    private bool povorot=false;
    void Start()
    {
        pos = 0;
        anim = GetComponent<Animator>();
    }




    void FixedUpdate()
    {
        if (povar.pov_dialog_triger == true)
            deistvie = "talk";
        if (deistvie == "talk")
        {
            if (dialog_time > 0) dialog_time -= Time.deltaTime;
            if (wait_time > 0) wait_time -= Time.deltaTime;



            if (dialog_time > 0 && wait_time <= 0)
            {
                dialogs.SetActive(true);
                anim.SetBool("nos", false);
                anim.SetBool("talk", true);


            }
            if (dialog_time <= 0 && wait_time <= 0 && talk == true)
            {
                dialogs.SetActive(false);
                anim.SetBool("talk", false);
                wait_time = 6;
                talk = false;

                if (tek < 3) tek++;

                if (tek == 3)
                {
                    poshol = true;
                    deistvie = "poshol";
                }

            }
            if (wait_time <= 0 && dialog_time <= 0)
            {
                dialog_time = 5;
                talk = true;

            }









        }

        if (kd > 0) kd -= Time.deltaTime;
        if (Dumaetkd > 0) Dumaetkd -= Time.deltaTime;

        if (shitok.svet == false && timekd == false) { kd = 5; timekd = true; deistvie = "tuda"; }
        if (deistvie == "tuda" && kd <= 0)
        {
            anim.SetBool("nos", false);
            anim.SetBool("idet", true);
            transform.position = Vector2.MoveTowards(transform.position, moveSpots[pos].position, speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, moveSpots[pos].position) < 0.2f)
            {
                if (pos == 4)
                {
                    anim.SetBool("idet", false);
                    if (povorot == false)
                    {
                        Flip();
                        povorot = true;
                    }
                    deistvie = "dumaet";
                    proverk1++;
                    Dumaetkd = 6;
                    tek = 3;
                    dialogs.SetActive(true);
                    //anim.SetTrigger("fix");
                    anim.SetBool("dumaet", true);
                    shitok.svet = true;
                    trigers.v_per = true;
                    trigers.svet_off = false;
                    CAMERA.to_offic = false;


                }
                if (pos == 3)
                {
                    if (Palevo.palevo == true && trigers.Hide==false)
                    {
                        if (proverk1 == 0)
                        {
                            
                            dialogs.SetActive(true);
                            tek = 4;
                            anim.SetBool("idet", false);
                            CAMERA.to_offic = true;
                        }
                        if (proverk2 >= 1)
                        {
                            dialogs.SetActive(true);
                            tek = 5;
                            anim.SetBool("idet", false);
                            anim.SetTrigger("police");
                            trigers.Fail = true;
                            deistvie = "popalsa";
                            anim.SetBool("idet", false);
                            CAMERA.to_offic = true;
                        }
                       
                    }
                    else
                    {
                        anim.SetBool("idet", true);
                        pos = 4;
                        if(trigers.Hide == false)CAMERA.to_offic = false;
                    }
                }
               
                if (pos == 2)
                {if (trigers.Hide == true && deistvie=="tuda") CAMERA.to_offic = true;
                    pos = 3;
                }
                if (pos == 1)
                {
                    pos = 2;
                    transform.position = moveSpots[2].position;
                    Flip();

                }
                if (pos == 0) pos = 1;
                if (pos == 6) pos = 0;

            }

        }
        if (ko == false && Dumaetkd <= 0 && deistvie == "dumaet")
        {

            trigers.v_per = false;

            pos = 3;
            proverk2++;
            deistvie = "suda";
            dialogs.SetActive(false);
            anim.SetBool("dumaet", false);
            povorot = false;
        }

        if (deistvie == "suda" && Dumaetkd <= 0)
        {

            anim.SetBool("idet", true);
            transform.position = Vector2.MoveTowards(transform.position, moveSpots[pos].position, speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, moveSpots[pos].position) < 0.2f)
            {
                if (pos == 6)
                {
                    anim.SetBool("idet", false);
                    anim.SetBool("nos", true);
                    if (povorot == false)
                    {
                        Flip();
                        povorot = true;
                    }
                    deistvie = "stoit";
                    povorot = false;
                    timekd = false;
                }
                if (pos == 0) pos = 6;
                if (pos == 1) pos = 0;
                if (pos == 2)
                {
                    transform.position = moveSpots[1].position;
                    Flip();
                    pos = 1;
                }

                if (pos == 3) pos = 2;

            }

        }


        if (poshol == true)
        {
            anim.SetBool("idet", true);
            transform.position = Vector2.MoveTowards(transform.position, moveSpots[pos].position, speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, moveSpots[pos].position) < 0.2f)
            {
                if (pos == 5)
                {
                    anim.SetBool("idet", false);
                    anim.SetBool("smoke", true);
                }
                if (pos == 3) pos = 5;
                if (pos == 2) pos = 3;

                if (pos == 1)
                {
                    pos = 2;
                    transform.position = moveSpots[2].position;
                    Flip();

                }
                if (pos == 0) pos = 1;

            }

        }




     if(deistvie=="poshol" || deistvie=="dumaet")
        {
            if (trigers.atacked == true)
            {
                dialogs.SetActive(false);
                anim.SetBool("dumaet", false);
                anim.SetTrigger("atacked");
                    anim.SetBool("upal", true);
                    ko = true;      
            }
            if(trigers.pereodet == true) anim.SetBool("goly", true);
        }

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


    public void Flip()
    {

        Vector3 Scalet = transform.localScale;
        Scalet.x *= -1;
        transform.localScale = Scalet;
    }
}
