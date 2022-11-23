using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gazetchik : MonoBehaviour
{
    private Animator anim;
    public trigers trigers;
    public Transform Spot;
    public float speed;
    private bool povorot = false;
    private bool spawn = false;
    public float timeout = 2f;
    public float timeout1 = 1f;
    public GameObject molotok;

    void Start()
    {
        anim = GetComponent<Animator>();
    }


    void FixedUpdate()
    {
        if (trigers.gazetPos == true)
            if (timeout > 0) timeout -= Time.deltaTime;
        if (timeout <= 0)
        {
            anim.SetTrigger("polog");
            if (timeout1 > 0) timeout1 -= Time.deltaTime;
            if (timeout1 <= 0)
            {
                if (spawn == false)
                {
                    trigers.molot = Instantiate(molotok, molotok.transform.position, Quaternion.identity);
                    spawn = true;
                }
             
                if (povorot == false)
                {
                    Flip();

                    povorot = true;
                }

                transform.position = Vector2.MoveTowards(transform.position, Spot.position, speed * Time.deltaTime);
                if (Vector2.Distance(transform.position, Spot.position) < 0.2f)
                {

                    anim.SetBool("doshol", true);
                }
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
