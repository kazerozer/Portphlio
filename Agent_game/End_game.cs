using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End_game : MonoBehaviour
{ 
     public trigers trigers;
    public bool End;
    public bool NS=false;
    public bool NS2 = false;
    public bool colide=false;

   
    // Start is called before the first frame update
    void Start()
    {
        End = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
            if (trigers.end==true)
            {



                if (trigers.ko == true || trigers.otrav == true) if (trigers.doki == true)
                    {
                        if (trigers.ko == true) NS = true;
                        if (trigers.bonus2 == 2) NS2 = true;
                        End = true;
                    }
            }
        }
    }

