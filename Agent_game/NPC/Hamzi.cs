using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hamzi : MonoBehaviour
{

    public trigers trigers;
    private Animator anim;
    public Sup Sup;
    public GameObject dialog;
    public Sprite[] dialogs;
    public float reactTime;
    public Transform moveSpot;
    public bool povorot = false;
    public bool react = false;
    public bool ugroz = false;
    public string deisvie = "reget";

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    
    void FixedUpdate()
    {
        if (reactTime<=0 && deisvie == "ugroza")
        {
            deisvie = "reget";
            ugroz = false;
            anim.SetBool("react", false);
            dialog.SetActive(false);
        }

        if(reactTime>0 && ugroz == true)
        {
            deisvie = "ugroza";
            anim.SetBool("react", true);
            dialog.SetActive(true);

        }


        if (reactTime <= 0 && deisvie == "smell")
        {
            if (povorot == false)
            {
                Flip();
                povorot = true;

            }
            anim.SetBool("idet", true);
            transform.position = Vector2.MoveTowards(transform.position, moveSpot.position, 3 * Time.deltaTime);
            if (Vector2.Distance(transform.position, moveSpot.position) < 0.2f)
            {
               
                anim.SetBool("idet", false);
                deisvie = "grustit";
                reactTime = 4;


            }
        }

        if(deisvie=="grustit"&& reactTime > 0)
        {
            dialog.gameObject.GetComponent<SpriteRenderer>().sprite = dialogs[0];
            dialog.SetActive(true);

        }
        if (deisvie == "grustit" && reactTime <= 0)
        {
            
            dialog.SetActive(false);
            dialog.gameObject.GetComponent<SpriteRenderer>().sprite = dialogs[1];
            deisvie= "sporit";
            reactTime = 3;

        }
        if (deisvie == "sporit" && reactTime <= 0)
        {
            dialog.SetActive(true);
            deisvie = "obida";
            reactTime = 4;

        }
        if (deisvie == "obida" && reactTime <= 0)
        {
            dialog.SetActive(false);
            
        }


        if (reactTime <= 0 && react == true && deisvie=="reget")
        {
            anim.SetTrigger("smell");
            deisvie = "smell";
            reactTime = 1f;
            
        }
       
        if (Sup.sgorel == true && Sup.garTime <= 0 && react == false)
        {
            reactTime = 3f;
            react = true;
        }
        if (reactTime > 0) reactTime -= Time.deltaTime;
    }

    public void Flip()
    {

        Vector3 Scalet = transform.localScale;
        Scalet.x *= -1;
        transform.localScale = Scalet;
    }

    public void OnTriggerStay2D(Collider2D other)
    {



        if (other.CompareTag("Player"))
        {
            if (trigers.posY > this.gameObject.transform.position.y - 0.120)
                this.gameObject.GetComponent<Renderer>().sortingOrder = 6;
            if (trigers.posY < this.gameObject.transform.position.y - 0.120)
                this.gameObject.GetComponent<Renderer>().sortingOrder = 2;

        }
    }
}
