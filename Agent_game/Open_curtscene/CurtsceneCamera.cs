using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurtsceneCamera : MonoBehaviour
{
    public Transform[] trigerSpot;
    public float TimeOut;
    private Vector3 pers;
    
    public float speed;
    public int pos;
    //public float showTime;

    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (TimeOut > 0) TimeOut -= Time.deltaTime;
        if (TimeOut <= 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, trigerSpot[0].position, speed * Time.deltaTime);
            if (Vector3.Distance(transform.position, trigerSpot[0].position) < 0.01f)
            {
                pos = 2;
                speed = 7;
            }


            if (pos == 2)
            {
                if(Camera.main.orthographicSize > 5f)
                Camera.main.orthographicSize -= 0.05f;
                pers = new Vector3(trigerSpot[1].position.x, trigerSpot[1].position.y + 3f, -5);
                transform.position = pers;
                //transform.position = Vector3.MoveTowards(transform.position, pers, speed * Time.deltaTime);
            }

            if (pos==3)
            {
                if (Camera.main.orthographicSize > 3.60f)
                    Camera.main.orthographicSize -= 0.05f;
              
                pers = new Vector3(trigerSpot[2].position.x, trigerSpot[0].position.y + 1.3f, -5);
                transform.position = pers; //Vector3.MoveTowards(transform.position, pers, speed * Time.deltaTime);
            }

        }
    }
}
