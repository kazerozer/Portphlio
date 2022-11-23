using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tyalet : MonoBehaviour
{
    public trigers trigers;
    private Animator anim;
    public float time;
    public bool zasor = false;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(time>0)time-= Time.deltaTime;

        if (trigers.zasor == false)
        {
            if (zasor == true) time = 1.5f;
            zasor = false;
        }
        if (zasor == false && time <= 0) { anim.SetBool("slom", false); }

        if (trigers.zasor == true)
        {
            if(zasor==false)time = 1;
            zasor = true;
        }
        if (zasor == true && time <= 0) { anim.SetBool("slom",true); }
        
    }
}
