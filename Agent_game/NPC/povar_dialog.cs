using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class povar_dialog : MonoBehaviour
{
    public povar povar;
    public Sprite[] dialog;





    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        this.gameObject.GetComponent<SpriteRenderer>().sprite = dialog[povar.tek];
    }
}
