﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hunter_dialogss : MonoBehaviour
{
    public Hunter Hunter;
    public Sprite[] dialog;
  





    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
         this.gameObject.GetComponent<SpriteRenderer>().sprite = dialog[Hunter.tek];
      
    }
}
