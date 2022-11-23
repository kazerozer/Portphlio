using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shitok : MonoBehaviour
{
    public Sprite svet_on;
    public Sprite svet_off;
    //public bool open = false;
    public bool svet;
   // private bool colide = false;
    public trigers trigers;
    public GameObject[] okna;
    private Animator anim;


    void Start()
    {
        svet = true;
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        
            
                
                   if (trigers.svet_off == true)
                    {
                        anim.SetBool("Off", true);
                        svet = false;
                        okna[0].gameObject.GetComponent<SpriteRenderer>().sprite = svet_off;
                        okna[1].gameObject.GetComponent<SpriteRenderer>().sprite = svet_off;
                        okna[2].gameObject.GetComponent<SpriteRenderer>().sprite = svet_off;
                        okna[3].gameObject.SetActive(true);

                    }

                    if (trigers.shit_open == true)
                    {
                        anim.SetTrigger("lomat");
                        
                    }

                
            

        if (svet == true)
           {
            anim.SetBool("Off", false);
            okna[0].gameObject.GetComponent<SpriteRenderer>().sprite = svet_on;
            okna[1].gameObject.GetComponent<SpriteRenderer>().sprite = svet_on;
            okna[2].gameObject.GetComponent<SpriteRenderer>().sprite = svet_on;
            okna[3].gameObject.SetActive(false);
        }
    }

   

}
