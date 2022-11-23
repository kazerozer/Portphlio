using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tyalletvoda : MonoBehaviour
{
    public bool dolilas = false;
    public tyalet tyalet;
    void Start()
    {
        
    }
    
    void FixedUpdate()
    {
        Vector3 Scalet = transform.localScale;
        //transform.localScale = Vector3(0.3, 0.0, 0.0);
        if (Scalet.x <= 16.4 && tyalet.zasor == true && tyalet.time <= 0)
        {

            Scalet.x += 0.05f;
            transform.Translate(0.014f, 0f, 0f);
            transform.localScale = Scalet;
        }
        if(Scalet.x >= 16.4)dolilas = true;
        else dolilas = false;
        if (Scalet.x > 0 && tyalet.zasor == false && tyalet.time <= 0)
        {

            Scalet.x -= 0.05f;
            transform.Translate(-0.014f, 0f, 0f);
            transform.localScale = Scalet;
        }


    }
}
