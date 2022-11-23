using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sup : MonoBehaviour
{
    public bool sgorel = false;
    public float garTime;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
         if (garTime > 0) garTime -= Time.deltaTime;
         if(sgorel==true && garTime<=0)
        anim.SetTrigger("sgorel");
        
    }
}
