using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public int sec;
    public int min;
    public string s;
    public string m;

    public string end_time;
    public Text Timer;

    // Start is called before the first frame update
    void Start()
    {
        min = 0;
        sec = 0;
        
    }

   void OnEnable()
   {
        StartCoroutine(RepeatingFunction());
   }

    IEnumerator RepeatingFunction()
    {
        while (true)
        {
            TimeCount();
           
            yield return new WaitForSeconds(1);
        }
    }
    void TimeCount()
    {
      
       
        
        if (sec > 59)
        {
            sec = 0;
            min++;
        }
       

        if (sec < 10) s = "0" + sec; else s = sec.ToString();
        if (min < 10) m = "0" + min; else m = min.ToString();

        sec++;
      


        Timer.text = m + ":" + s;
        end_time = m + ":" + s;
    }

}
