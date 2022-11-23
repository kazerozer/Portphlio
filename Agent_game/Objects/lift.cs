using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lift : MonoBehaviour
{
    public GameObject Lift;
    public Sprite react;


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {



            Lift.GetComponent<SpriteRenderer>().sprite = react;

        }

    }

    
}
