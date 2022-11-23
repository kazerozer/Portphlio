using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golubi : MonoBehaviour
{
    private Animator anim;
    public bool letet = false;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

       
            if (letet == true)
            {
                if (transform.position.y < 8.02)
                {
                    
                    transform.Translate(0.1f, 0.07f, 0f);
                }
                else
                {
                letet = false;
                }
            }
        
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("GOlub"))
        {
           
        }
        else
        {
            anim.SetBool("Ispug", true);
            letet = true;
        }
    }
}
