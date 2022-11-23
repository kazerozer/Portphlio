using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Камера 


public class CAMERA : MonoBehaviour
{
  
    public Transform[] trigerSpot;
    private Vector3 pers;
    public bool to_Hunter = false;
    public bool to_CIA = false;
    public bool to_offic = false;
    public float speed;
    //public float showTime;
    void Start()
    {
        
    }

  
    void FixedUpdate()
    {
		
		// Перевод камеры на НПС Агент Хантер
        if (to_Hunter == true)
        {
            pers = new Vector3(trigerSpot[0].position.x, trigerSpot[1].position.y + 1.3f, -5);
            transform.position = Vector3.MoveTowards(transform.position, pers, speed * Time.deltaTime);

        }
       // Перевод камеры на НПС Агент ЦРУ 
        if (to_CIA == true)
        {
            pers = new Vector3(trigerSpot[2].position.x, trigerSpot[2].position.y + 1.3f, -5);
            transform.position = Vector3.MoveTowards(transform.position, pers, 4 * Time.deltaTime);

        }
	   // Перевод камеры на НПС Официант
        if (to_offic == true)
        {
            pers = new Vector3(trigerSpot[3].position.x, trigerSpot[3].position.y + 1.3f, -5);
            transform.position = Vector3.MoveTowards(transform.position, pers, 12 * Time.deltaTime);

        }
		// Перевод камеры на Игрока
        if (to_CIA == false && to_Hunter==false && to_offic == false)
        {
            pers = new Vector3(trigerSpot[0].position.x, trigerSpot[0].position.y + 1.3f, -5);
            transform.position = pers;

        }
        

    }
}
