using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Curt_Golubi : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator anim;
    public bool letet = true;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("Ispug", true);
    }

    // Update is called once per frame
    void FixedUpdate()
    {


        if (letet == true)
        {
            if (transform.position.y < 58.02)
            {

                transform.Translate(0.2f, 0.07f, 0f);
            }
            else
            {
                letet = false;
            }
        }

    }
}
