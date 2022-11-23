using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class line_up : MonoBehaviour
{
    public CurtsceneCamera CurtsceneCamera;
    public GameObject Text;
    public GameObject[] lines;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (CurtsceneCamera.TimeOut < 8 && CurtsceneCamera.TimeOut > 6) lines[0].transform.Translate(2f, 0f, 0f);
        if (CurtsceneCamera.TimeOut < 6 && CurtsceneCamera.TimeOut > 4) lines[1].transform.Translate(2f, 0f, 0f);
        if (CurtsceneCamera.TimeOut < 4 && CurtsceneCamera.TimeOut > 2) lines[2].transform.Translate(2f, 0f, 0f);
        if (CurtsceneCamera.TimeOut <= 0)
        {
            lines[0].SetActive(false);
            lines[1].SetActive(false);
            lines[2].SetActive(false);
        }
        //if (Scalet.x <= 0 && line < 3) line++;
        // if (Scalet.x > 0 && line < 3) Scalet.x -= 0.005f;

            Vector3 Scalet = transform.localScale;
        //transform.localScale = Vector3(0.3, 0.0, 0.0);
        if (Scalet.y > 0 && CurtsceneCamera.pos==2)
        {
            Text.SetActive(false);
            Scalet.y -= 0.0005f;
            transform.Translate(0f, 0.4f, 0f);
            transform.localScale = Scalet;
        }

    }
}
