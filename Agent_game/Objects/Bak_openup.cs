using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bak_openup : MonoBehaviour
{
    private Animator anim;
    public bool colide = false;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }




    // Update is called once per frame
    void Update()
    {
        if (colide == true)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.JoystickButton0))
            {

                anim.SetTrigger("openUp");
               

            }
        }
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            colide = true;
        }
    }
    public void OnTriggerExit2D(Collider2D other)
    {

        colide = false;

    }
}
