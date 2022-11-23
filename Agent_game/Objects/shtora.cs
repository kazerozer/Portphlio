using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shtora : MonoBehaviour
{
    public double shtorakd;
    public bool body = false;
    private Animator anim;
    public bool close = false;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (shtorakd > 0) shtorakd -= Time.deltaTime;
        if (close == true) {

            if(body==false)this.gameObject.GetComponent<Renderer>().sortingOrder = 6;
            anim.SetBool("Close", true);
        }
        if (close == false) {
            
            anim.SetBool("Close", false);
        }
        if(close==false && shtorakd<=0) this.gameObject.GetComponent<Renderer>().sortingOrder = 3;
    }
}
