using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class voda : MonoBehaviour
{
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }


        void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.JoystickButton0))
            {

                
                    anim.SetTrigger("voda1");

                }
        }
    }
    // Update is called once per frame

    void Update()
    {
    }
}
