using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_walk : MonoBehaviour
{

    public float speed;
   
    public double kd;
    public Transform StartSpot;
    public trigers trigers;
    private Animator anim;
    public Transform moveSpot;
    void Start()
    {
        anim = GetComponent<Animator>();
    }


    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if(trigers.posY> this.gameObject.transform.position.y-0.719)
                this.gameObject.GetComponent<Renderer>().sortingOrder = 6;
            if (trigers.posY < this.gameObject.transform.position.y - 0.719)
                this.gameObject.GetComponent<Renderer>().sortingOrder = 4;
            if (trigers.posY == this.gameObject.transform.position.y - 0.719)
            {
                kd = 3;

                //anim.SetBool("stop", true);
            }
        }
    }
            void FixedUpdate()
    {
        if (kd > 0) { kd -= Time.deltaTime; }
        else
        {
        //anim.SetBool("stop", false);
        transform.position = Vector2.MoveTowards(transform.position, moveSpot.position, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, moveSpot.position) < 0.2f)
        {
            
           transform.position = StartSpot.position;


            }
        }

    }
}
