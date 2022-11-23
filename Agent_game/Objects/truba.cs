
using UnityEngine;

public class trubashatal : MonoBehaviour
{
    private Animator anim;
    public trigers trigers;
    public bool brake = false;
    public bool colide = false;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }
  
  


    // Update is called once per frame
    void FixedUpdate()
    {
        
            
       if (trigers.slomano == true)
        {
            anim.SetBool("slom", true);
            brake = true;
        }
        

            
        
    }

       

}
