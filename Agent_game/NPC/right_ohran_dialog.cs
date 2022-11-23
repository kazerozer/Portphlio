using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class right_ohran_dialog : MonoBehaviour
{
    public ohranik_left ohranik_left;
    public Sprite[] dialog;





    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(ohranik_left.tek<5)
        this.gameObject.GetComponent<SpriteRenderer>().sprite = dialog[ohranik_left.tek];
    }
}
