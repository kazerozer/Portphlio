using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plita : MonoBehaviour
{
    public trigers trigers;

    public void OnTriggerStay2D(Collider2D other)
    {

       

        if (other.CompareTag("Player"))
        {
            if (trigers.posY > this.gameObject.transform.position.y )
                this.gameObject.GetComponent<Renderer>().sortingOrder = 6;
            if (trigers.posY < this.gameObject.transform.position.y)
                this.gameObject.GetComponent<Renderer>().sortingOrder = 2;
           
        }
    }
}
