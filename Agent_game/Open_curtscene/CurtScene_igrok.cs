using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CurtScene_igrok : MonoBehaviour
{
    public Transform[] trigerSpot;
    public CurtsceneCamera CurtsceneCamera;
    private Animator anim;
    public int pos;
    public float speed;
    public GameObject load;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (CurtsceneCamera.TimeOut <= 0)
        {
            if(pos==0) anim.SetBool("dvig", true);
            transform.position = Vector2.MoveTowards(transform.position, trigerSpot[pos].position, speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, trigerSpot[pos].position) < 0.2f)
            {
                if (pos == 2)
                {
                    anim.SetBool("dvig", false);
                    load.SetActive(true);
                    SceneManager.LoadScene("level1");
                }
                if(pos==1) this.gameObject.GetComponent<Renderer>().sortingOrder = 0;
                if (pos == 1) Flip();
                if (pos < 3) pos++;
               

            }
        }
    }

    public void Flip()
    {

        Vector3 Scalet = transform.localScale;
        Scalet.x *= -1;
        transform.localScale = Scalet;
    }
}
