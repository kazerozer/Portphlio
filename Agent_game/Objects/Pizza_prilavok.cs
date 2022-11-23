using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pizza_prilavok : MonoBehaviour
{
    public bool playerIn = false;

    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIn = true;
        }
    }
    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIn = false;
        }
    }
}
