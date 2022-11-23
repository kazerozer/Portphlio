using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class uprav_dialoges : MonoBehaviour
{
    public uprav uprav;
    public Sprite[] dialog;





    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        this.gameObject.GetComponent<SpriteRenderer>().sprite = dialog[uprav.tek];
    }
}
