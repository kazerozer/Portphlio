using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ohranik_dialogs : MonoBehaviour
{
    public ohranik ohranik;
    public Sprite[] dialog;
   




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        this.gameObject.GetComponent<SpriteRenderer>().sprite = dialog[ohranik.tek];
    }
}
