using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class line_down : MonoBehaviour
{
    public CurtsceneCamera CurtsceneCamera;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 Scalet = transform.localScale;
        //transform.localScale = Vector3(0.3, 0.0, 0.0);
        if (Scalet.y > 0 && CurtsceneCamera.pos == 2)
        {
            
            Scalet.y -= 0.0005f;
            transform.Translate(0f, -0.4f, 0f);
            transform.localScale = Scalet;
        }

    }
}
