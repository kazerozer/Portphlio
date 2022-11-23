using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golub2 : MonoBehaviour
{
    private Animator anim;
    public bool letet = false;
    private bool doFlip = false;

   
    void Start()
    {
        anim = GetComponent<Animator>();
    }

  
    void FixedUpdate()
    {


        if (letet == true)
        {
            if (transform.position.y < 8.02)
            {
                if (doFlip == false)
                {
                    Flip();
                    doFlip = true;
                }
                transform.Translate(0.14f, 0.09f, 0f);
            }
            else
            {
                letet = false;
            }
        }

    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            anim.SetBool("Ispug", true);
            
            letet = true;

        }
    }

    public void Flip()
    {

        Vector3 Scalet = transform.localScale;
        Scalet.x *= -1;
        transform.localScale = Scalet;
    }
}
