using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// НПС Агент Хантер 

public class Hunter : MonoBehaviour
{
    private Animator anim;
    public trigers trigers;
    public CAMERA CAMERA;
    public razved_Chek razved_Chek;
    public float speed;
    public Transform[] moveSpots;
    public int pos;
    private int pr;
    public bool destvie2 = false;
    public bool peremest = false;
    public bool destvie3 = false;
    public bool destvie4 = false;
    public bool dialog = false;
    public bool povorot = false;
    public bool upal = false;
    public GameObject prolito;
    
    public bool start_triger = false;
    public bool poshol = false;
    private bool smen = true; //Смена позиции
    public bool dead = false;
    public int tek; // Номер диалога
    public bool skazano = false;
    private bool pervshag = false;
    public float dialogtime=0;
    public float smokeTime;
    public float endSmokeTime;
    public float stoitTime=3;





    void Start()
    {
        pr = 1;
        pos = 0;
        anim = GetComponent<Animator>();
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (trigers.posY > this.gameObject.transform.position.y)
                this.gameObject.GetComponent<Renderer>().sortingOrder = 6;
            if (trigers.posY < this.gameObject.transform.position.y)
                this.gameObject.GetComponent<Renderer>().sortingOrder = 4;
            if (trigers.posY == this.gameObject.transform.position.y)
            {
                //kd = 3;

                //anim.SetBool("stop", true);
            }
        }
    }



    void FixedUpdate()
    {
        if (razved_Chek.playerIn == true)
        {
            start_triger=true;
            razved_Chek.playerIn=false;
            trigers.Hide = true;
            CAMERA.to_Hunter = true;
           
        }
        if (start_triger==true) {
            dialogtime -= Time.deltaTime;
            tek = 1;

            if (dialogtime <= 0)
            {
                
                dialogtime = 3;
                destvie2=true;
                start_triger = false;
                tek = 0;
                pos = 15;
                Flip();
                anim.SetBool("talk", false);
                anim.SetBool("idet", true);
                
            }
        }







     // Порядок действий и перемещения по уровню, НПС Агент Хантер


        if (destvie2 == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, moveSpots[pos].position, speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, moveSpots[pos].position) < 0.2f)
            {
				
				// Реакция на игрока в одежде Уборщика
                if (trigers.odegda == "s_Vedrom")
                {


                    dialogtime -= Time.deltaTime;
                    if (dialogtime > 0)
                    {
                        anim.SetBool("idet", false);
                        
                        tek = 2;
                    }
                    else
                    {
                        anim.SetBool("talk", false);
                        anim.SetBool("idet", true);
                        tek = 0;
                        destvie2 = false;
                        destvie3 = true;
                        trigers.Hide = false;
                        CAMERA.to_Hunter = false;
                        pos = 8;
                        
                    }


                }
				// Реакция на игрока в одежде Официанта
                if (trigers.odegda == "oficiant_food")
                    {

                        if (dialogtime > 0)
                        {
                            dialogtime -= Time.deltaTime;
                            anim.SetBool("idet", false);
                            anim.SetBool("Ukaz", true);
                            tek = 3;



                        }
                        else
                        {
                            dialogtime = 5;
                            destvie2 = false;
                            tek = 0;
                            poshol = true;
                            anim.SetBool("Ukaz", false);
                            anim.SetBool("idet", true);
                            trigers.Hide = false;
                        CAMERA.to_Hunter = false;
                        pos = 0;
                        }
                    }

                
            }
        }
        if (destvie3 == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, moveSpots[pos].position, speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, moveSpots[pos].position) < 0.2f)
            {
                if (pos == 13)
                {
                    if (povorot == false)
                    {
                      Flip();
                      povorot = true;
                    }
                    if (prolito != null) { 
                    
                    anim.SetBool("idet", false);
                    anim.SetBool("Pol", true);
                    tek = 4;
                    }
                    else
                    {
                        destvie3 = false;
                        anim.SetBool("Pol", false);
                        anim.SetBool("idet", true);
                        destvie4 = true;
                        pos = 14;
                        povorot = false;
                    }
                }
                if (pos == 8)
                {
                    transform.Translate(0f, 38f, 0f);
                    pos = 13;
                }
            }
        }
        if (destvie4 == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, moveSpots[pos].position, speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, moveSpots[pos].position) < 0.2f)
            {
                if (pos == 14)
                {
                    if (upal == false)
                    {
                        anim.SetBool("idet", false);
                        anim.SetTrigger("padaet");
                        anim.SetBool("legit", true);
                        anim.SetTrigger("get up");
                        anim.SetBool("legit", false);
                       
                        upal = true;
                       // CAMERA.to_Hunter = true;
                        //CAMERA.speed = 3f;
                       // CAMERA.showTime = 3f;
                        dialogtime = 6;
                    }
                    if (upal == true)
                    {
                        if (dialogtime > 0)
                        {
                            dialogtime -= Time.deltaTime;
                            anim.SetBool("talk", true);
                            tek = 5;

                        }
                        else
                        {
                            tek = 0;
                            anim.SetBool("talk", false);
                            anim.SetBool("idet", true);
                            pos = 10;
                            destvie4 = false;
                            poshol = true;
                        }
                    }
                   


                }
            }

        }

            if (poshol==true)
            {
            if (stoitTime <=0 && pos ==3 && trigers.palevnoTime > 0)
            {
                
                anim.SetTrigger("pistol");
                tek = 10;
                trigers.Fail = true;

                if (peremest == false)
                {
                    transform.Translate(-0.5f, 0f, 0f);
                    peremest = true;

                }
            }
            else if(trigers.Fail != true) transform.position = Vector2.MoveTowards(transform.position, moveSpots[pos].position, speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, moveSpots[pos].position) < 0.2f)
            {
                if (pos == 11)
                {
                    pos = 12;
                    dead = true;
                }




                if (pos == 10 && smen == true)
                {
                    if (stoitTime > 0)
                    {
                        anim.SetBool("idet", false);
                        anim.SetBool("dumaet", true);

                        tek = 6;
                        stoitTime -= Time.deltaTime;
                    }else
                    {
                        anim.SetBool("dumaet", false);
                        anim.SetBool("idet", true);
                        stoitTime = 5;
                        Flip();
                        tek = 0;
                        pr = -1;
                        pos = pos + pr;
                        smokeTime = 10;
                        endSmokeTime = 2;
                        smen = false;
                    }
                    
                }




                if (pos == 9 && smen == true)
                {

                    transform.Translate(0f, -38f, 0f);
                    pos = pos + pr + pr;
                    smen = false;
                }
                if (pos == 8 && smen == true)
                {

                    transform.Translate(0f, 38f, 0f);
                    pos = pos + pr + pr;
                    smen = false;
                }
                if (pos == 7 && smen == true)
                {
                    pos = pos + pr;
                    smen = false;
                }
                if (pos == 6 && smen == true)
                {
                    pos = pos + pr;
                    smen = false;
                }
                if (pos == 5 && smen == true)
                {
                    pos = pos + pr + pr;
                    transform.Translate(0f, 17f, 0f);
                    smen = false;
                }
                if (pos == 4 && smen == true)
                {

                    transform.Translate(0f, -17f, 0f);
                    pos = pos + pr + pr;
                    smen = false;

                }
                if (pos == 3 && smen == true)
                {
                    
                    if (stoitTime > 0 && trigers.palevnoTime > 0)
                    {
                        anim.SetBool("idet", false);
                        anim.SetBool("eat", false);
                        anim.SetTrigger("pistol");
                        tek = 10;
                        trigers.Fail = true;
                       
                        if (peremest == false)
                        {
                            transform.Translate(1.4f, 0f, 0f);
                            peremest = true;
                            Flip();

                        }
                    }

                    if (trigers.otrav == true && trigers.Fail != true)
                    {
                        anim.SetTrigger("otravlen");
                        dead = true;
                    }
                    if (trigers.otrav == false && trigers.postavleno == true && stoitTime > 0 && trigers.Fail != true)
                    {



                        anim.SetBool("idet", false);
                        anim.SetBool("eat",true);
                        tek = 8;
                        stoitTime -= Time.deltaTime;



                    }
                    
                    




                    if (trigers.otrav == false && trigers.postavleno == false && stoitTime > 0 && trigers.Fail != true)
                    {



                        anim.SetBool("idet", false);
                        anim.SetBool("dumaet", true);
                        tek = 7;
                        stoitTime -= Time.deltaTime;



                    }
                    if(trigers.otrav == false && trigers.postavleno == false && stoitTime <= 0 && trigers.Fail != true)
                    {
                        stoitTime = 5;
                        anim.SetBool("dumaet", false);
                        anim.SetBool("idet", true);
                        Flip();
                        tek = 0;
                        pos += pr;
                        smen = false;
                    }
                    if (trigers.otrav == false && trigers.postavleno == true && stoitTime <= 0 && trigers.Fail != true)
                    {
                        stoitTime = 5;
                        anim.SetBool("eat", false);
                        anim.SetBool("idet", true);
                        Flip();
                        tek = 0;
                        pos += pr;
                        smen = false;
                    }



                }
                if (pos == 2 && smen == true)
                {
                    if (pr == -1)
                    {
                        transform.Translate(0f, -17f, 0f);
                        Flip();
                        pos = pos + pr + pr;
                    }

                    smen = false;


                }
                if (pos == 1 && smen == true)
                {
                    if (pr == 1)
                    {
                        transform.Translate(0f, 17f, 0f);
                        Flip();
                        pos = pos + pr + pr;
                        smen = false;
                        

                    }

                }
                if (pos == 0 && smen == true)
                {
                    if (trigers.ko == true)
                    {
                        anim.SetTrigger("padaet");
                        anim.SetBool("legit", true);
                        if (pos != 12) pos = 11;
                        speed *= 2;

                    }
                    else
                     if (endSmokeTime >= 0)
                    {
                        if (smokeTime >= 0)
                        {

                            anim.SetBool("idet", false);
                            anim.SetBool("smoke", true);
                            smokeTime -= Time.deltaTime;
                        }
                        else
                        {
                            anim.SetBool("smoke", false);
                            endSmokeTime -= Time.deltaTime;

                        }

                    }
                    else
                    {
                        anim.SetBool("idet", true);
                        pr = 1;
                        Flip();

                        pos = pos + pr;
                        smen = false;
                    }
                }
                smen = true;
            }
        }
        
        
    }
    public void Flip()
    {

        Vector3 Scalet = transform.localScale;
        Scalet.x *= -1;
        transform.localScale = Scalet;
    }
    

}