﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ofic_dialog : MonoBehaviour
{
    public KO KO;
    public Sprite[] dialog;





    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        this.gameObject.GetComponent<SpriteRenderer>().sprite = dialog[KO.tek];
    }
}
