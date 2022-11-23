using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_In_cheker : MonoBehaviour
{
    public bool player_in = false;
    // Start is called before the first frame update
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {

            player_in = true;

        }
    }
}
