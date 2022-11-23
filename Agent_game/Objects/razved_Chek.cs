using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class razved_Chek : MonoBehaviour
{
    public bool playerIn = false;
    public bool srabotal = false;

    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (srabotal==false)
            {
                playerIn = true; 
                srabotal = true; 
            }
           
                
        }
    }
   
}
