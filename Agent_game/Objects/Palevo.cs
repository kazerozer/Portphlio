using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Palevo : MonoBehaviour
{
    public bool palevo = false;
    
    void Start()
    {
        
    }

    
    void FixedUpdate()
    {
        
    }


    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {

            palevo = true;

        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {

            palevo = false;

        }
        
    }



}