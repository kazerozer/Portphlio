using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitman : MonoBehaviour
{
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        anim.SetBool("ushel", false);

        anim.SetBool("trevog", true);



    }
    void OnTriggerExit2D(Collider2D other)
    {

        anim.SetBool("ushel",true);

        anim.SetBool("trevog", false);



    }



}
