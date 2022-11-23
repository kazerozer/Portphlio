using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pizza_man_dialogs : MonoBehaviour
{
    public reactiontrub reactiontrub;
    public Sprite[] dialog;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = dialog[reactiontrub.tek];
    }
}
