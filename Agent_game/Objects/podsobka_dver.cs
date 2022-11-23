using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class podsobka_dver : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite dver_open;
    public Sprite dver_close;
    public reactiontrub reactiontrub;
    public bool playerIn = false;

    // Update is called once per frame


    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (reactiontrub.poshol == true)
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = dver_open;
            }
            else playerIn = true;

                
           
        }
    }
    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {

            if (reactiontrub.poshol == true)
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = dver_close;
            }
            else playerIn = false;
        }
    }
}