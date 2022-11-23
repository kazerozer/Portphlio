using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vedro : MonoBehaviour
{
    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.JoystickButton0))
            {

                Destroy(gameObject, 0f);


            }
        }
    }
}
