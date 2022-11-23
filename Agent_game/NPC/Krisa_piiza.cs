using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Krisa_piiza : MonoBehaviour
{

   
    public povar povar;
    private Animator anim;
    public Transform[] moveSpot;
    public int i;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (povar.krisaShoUp == false)
        {
            transform.position = Vector2.MoveTowards(transform.position, moveSpot[i].position, 2 * Time.deltaTime);
            if (Vector2.Distance(transform.position, moveSpot[i].position) < 0.2f)
            {
                if (i == 1)
                {


                    anim.SetBool("pizza", true);
                }
                if (i == 0)
                {
                    this.gameObject.GetComponent<Renderer>().sortingOrder = 4;
                    i = 1;
                }

            }
        }
        if (povar.krisaShoUp == true)
        {
            anim.SetBool("pizza", false);
            this.gameObject.GetComponent<Renderer>().sortingOrder = 0;
            transform.position = Vector2.MoveTowards(transform.position, moveSpot[2].position, 3 * Time.deltaTime);
           
                
        }
     }
}
