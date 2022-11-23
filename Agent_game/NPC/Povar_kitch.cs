using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Povar_kitch : MonoBehaviour
{
    private Animator anim;
    public Sup Sup;
    public float reactTime;
    public Transform moveSpot;

    public GameObject dialog;
    public Sprite[] dialogs;
    public GameObject povar_front;
  
    public string deistive;
    public bool povorot = false;
   
    // Start is called before the first frame update
    void Start()
    {
        deistive = "stoit";
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
       
        if (reactTime <= 0 && deistive=="poshol")
        {

            if (povorot == false)
            {
                Flip();
                povorot = true;
                anim.SetBool("idet", true);
                povar_front.SetActive(false);

            }
            transform.position = Vector2.MoveTowards(transform.position, moveSpot.position, 2 * Time.deltaTime);
            if (Vector2.Distance(transform.position, moveSpot.position) < 0.2f)
            {

                anim.SetBool("idet", false);
                dialog.SetActive(true);
                deistive = "oret";
                reactTime = 4;


            }
        }

        if(reactTime <= 0 && deistive == "oret")
        {
            dialog.SetActive(false);
            dialog.gameObject.GetComponent<SpriteRenderer>().sprite = dialogs[1];
            reactTime = 5;
            deistive = "slushaet";
        }

        if (reactTime <= 0 && deistive == "slushaet")
        {
            dialog.SetActive(true);
            reactTime = 5;
            deistive = "oret2";
        }

        if (reactTime <= 0 && deistive == "oret2")
        {
            dialog.SetActive(false);
         
        }

        if (Sup.sgorel == true && Sup.garTime <= 0 && deistive=="stoit")
        {
            reactTime = 5f;
            
            deistive = "poshol";
        }
        if (reactTime > 0) reactTime -= Time.deltaTime;
    }

    public void Flip()
    {

        Vector3 Scalet = transform.localScale;
        Scalet.x *= -1;
        transform.localScale = Scalet;
    }
}
