using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kiany : MonoBehaviour
{
    public Golub2 Golub2;
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Golub2.letet == true) anim.SetTrigger("grust");
    }
}
