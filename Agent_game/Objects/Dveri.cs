using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dveri : MonoBehaviour
{
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
}
