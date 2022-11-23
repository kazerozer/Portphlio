using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class krisa_beg : MonoBehaviour
{

    public Transform moveSpot;
    public perspos perspos;
    public bool begat = false;
    public string name;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    
    // Update is called once per frame
    void FixedUpdate()
    {
        if (perspos.zashel == true) begat = true;
        if (begat == true)
        {
            if (name == "left")
            {
                Flip();
                name = "";
            }
            transform.position = Vector2.MoveTowards(transform.position, moveSpot.position, speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, moveSpot.position) < 0.1f)
            {
               
            }
            }
    }
    public void Flip()
    {

        Vector3 Scalet = transform.localScale;
        Scalet.x *= -1;
        transform.localScale = Scalet;
    }
}
