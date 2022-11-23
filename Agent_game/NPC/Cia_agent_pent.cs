using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cia_agent_pent : MonoBehaviour
{
    public tyalletvoda tyalletvoda;
    public tyalet tyalet;
    public trigers trigers;
    public CAMERA CAMERA;
    private Animator anim;
    public Palevo Palevo;
    public Transform[] moveSpots;
    public GameObject dialog;
    public GameObject dialog2;
    public Sprite[] dialogs;
    private bool shag = false;
    public string deistvie;
    public bool ko = false;
    public bool peremest = false;
    public bool Fshag = false;
    public bool doshel = false;
    public bool povorot = false;
    public bool povorot2 = false;
    public bool Tyalfixed = false;
    public bool povorot3 = false;
    public bool povorot4 = false;
    public float TimeOut = 5;
    public int pos = 0;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        deistvie = "stoit";
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (TimeOut > 0) TimeOut -= Time.deltaTime;

        if (pos == 3 && trigers.KabpalevnoTime > 0)
        {
            
            anim.SetBool("stop", false);
            anim.SetTrigger("pistol");
            dialog.gameObject.GetComponent<SpriteRenderer>().sprite = dialogs[4];
            dialog.SetActive(true);
            trigers.Fail = true;
            deistvie = "popalsa";
            if (peremest == false)
            {
                transform.Translate(-1f, 0f, 0f);
                peremest = true;

            }
            
        }


        if (tyalletvoda.dolilas == true && doshel==false) deistvie = "tuda";
        if(deistvie=="tuda")
        {
           if (trigers.Hide == true && trigers.zasor == true) CAMERA.to_CIA = true;
            if (Fshag == false)
            { 
                if (povorot == false)
            {
                Flip();
                povorot = true;
            }
                anim.SetBool("stop", false);
                dialog2.SetActive(false);
                anim.SetBool("idet", true);
            anim.SetBool("front", true);
            transform.position = Vector2.MoveTowards(transform.position, moveSpots[0].position, 2 * Time.deltaTime);
            if (Vector2.Distance(transform.position, moveSpots[0].position) < 0.2f)
            {
               
                anim.SetBool("idet", false);
                    dialog.gameObject.GetComponent<SpriteRenderer>().sprite = dialogs[1];
                    dialog.SetActive(true);


                    TimeOut = 3;
                    this.gameObject.GetComponent<Renderer>().sortingOrder = 7;
                    Fshag = true;
                    pos = 1;
                
               


            }
            } //

            if (TimeOut <= 0 && Fshag == true)
            {

                anim.SetBool("idet", true);
                dialog.SetActive(false);


                transform.position = Vector2.MoveTowards(transform.position, moveSpots[4].position, 0.6f * Time.deltaTime);
                if (Vector2.Distance(transform.position, moveSpots[4].position) < 0.2f && Palevo.palevo == true && trigers.Hide == false)
                {

                    anim.SetBool("idet", false);
                    dialog.gameObject.GetComponent<SpriteRenderer>().sprite = dialogs[3];
                    dialog.SetActive(true);
                    anim.SetTrigger("pistol");
                    trigers.Fail = true;
                    deistvie = "popalsa";


                }
                else
                {
                    transform.position = Vector2.MoveTowards(transform.position, moveSpots[1].position, 3 * Time.deltaTime);
                    if (Vector2.Distance(transform.position, moveSpots[1].position) < 0.2f)
                    {

                        CAMERA.to_CIA = false;
                        anim.SetTrigger("dumaet");
                        dialog.gameObject.GetComponent<SpriteRenderer>().sprite = dialogs[2];
                        dialog.SetActive(true);
                        doshel = true;
                        deistvie = "dumaet";
                        TimeOut = 6;

                    }
                }
            }
        }
        if (doshel == true && TimeOut > 0)
            {
                if (trigers.Cia_ko == true)
                {
                   dialog.SetActive(false);
                   anim.SetTrigger("ko");
                    ko = true;
                    // if(trigers.KoKd <= 0) transform.position = moveSpots[2].position;

                }
            }
        

        if (ko == false && TimeOut <= 0 && deistvie=="dumaet")
            {

               anim.SetTrigger("fix");
               dialog.SetActive(false);
               TimeOut = 2.3f;
                Tyalfixed = true;
                tyalletvoda.dolilas = false;
                
                trigers.zasor = false;
                pos = 0;
                deistvie = "suda";
                // if(trigers.KoKd <= 0) transform.position = moveSpots[2].position;

            }
        
        if (deistvie=="suda" && TimeOut <= 0)
        {
            if (povorot4 == false)
            {
                Flip();
                povorot4 = true;
                anim.SetBool("idet", true);

            }
            if(pos==3 && trigers.KabpalevnoTime > 0)
            {
                anim.SetBool("idet", false);
                anim.SetTrigger("pistol");
                trigers.Fail = true;
                deistvie = "popalsa";
                dialog.gameObject.GetComponent<SpriteRenderer>().sprite = dialogs[4];
                dialog.SetActive(true);
                if (peremest == false)
                {
                    transform.Translate(-0.5f, 0f, 0f);
                    peremest = true;

                }
            }
            else transform.position = Vector2.MoveTowards(transform.position, moveSpots[pos].position, 3 * Time.deltaTime);
            if (Vector2.Distance(transform.position, moveSpots[pos].position) < 0.2f)
            {
                if (pos == 3)
                {
                    anim.SetBool("idet", false);
                    anim.SetBool("front", false);
                    Tyalfixed = false;
                    doshel = false;
                    Fshag = false;
                    povorot = false;
                    deistvie = "stoit";
                    this.gameObject.GetComponent<Renderer>().sortingOrder = 4;
                    povorot4 = false;

                }
                if (pos == 0)
                 if(trigers.KabpalevnoTime > 0)
                 {
                    anim.SetBool("idet", false);
                    anim.SetTrigger("pistol");
                    trigers.Fail = true;
                    deistvie = "popalsa";
                 }else pos = 3;


            }

        }
        

    }


    


    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
           if(deistvie=="stoit" && pos == 3) { 

            anim.SetBool("stop", true);
            dialog.gameObject.GetComponent<SpriteRenderer>().sprite = dialogs[0];
            dialog2.SetActive(true);
            }

        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (deistvie == "stoit" && pos == 3)
        { 
            anim.SetBool("stop", false);
            dialog2.SetActive(false);
        }
    }

    public void Flip()
    {

        Vector3 Scalet = transform.localScale;
        Scalet.x *= -1;
        transform.localScale = Scalet;
    }

}








