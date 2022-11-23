using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kabinet_dver : MonoBehaviour
{
    public Cia_agent_pent Cia_agent_pent;
    public Sprite dver_open;
    public Sprite dver_close;
    public void OnTriggerStay2D(Collider2D other)
    {


        this.gameObject.GetComponent<SpriteRenderer>().sprite = dver_open;

    }
    public void OnTriggerExit2D(Collider2D other)
    {



        this.gameObject.GetComponent<SpriteRenderer>().sprite = dver_close;


    }
  
    void FixedUpdate()
    {
        if (Cia_agent_pent.deistvie == "stoit")
        gameObject.GetComponent<BoxCollider2D>().isTrigger = false; else gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
    }
}
