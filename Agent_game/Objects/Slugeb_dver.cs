using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slugeb_dver : MonoBehaviour
{
    public Sprite dver_open;
    public Sprite dver_close;
    public trigers trigers;
    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (trigers.odegda == "oficiant") this.gameObject.GetComponent<SpriteRenderer>().sprite = dver_open;
            
        }
        if (other.CompareTag("oficiant"))
        
            this.gameObject.GetComponent<SpriteRenderer>().sprite = dver_open;

    }
    public void OnTriggerExit2D(Collider2D other)
    {



        this.gameObject.GetComponent<SpriteRenderer>().sprite = dver_close;


    }
}
