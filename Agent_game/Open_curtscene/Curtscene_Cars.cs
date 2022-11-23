using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Curtscene_Cars : MonoBehaviour
{
    public Transform trigerSpot;
    public CurtsceneCamera CurtsceneCamera;
    public float speed;
  

    void Start()
    {
       
    }


    void FixedUpdate()
    {
        if (CurtsceneCamera.TimeOut <= 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, trigerSpot.position, speed * Time.deltaTime);
            
        }
    }
}
