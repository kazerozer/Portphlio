using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine.UI;

public class start_game : MonoBehaviour
{
    public GameObject Stbutton;
    public GameObject Briffing;
    public GameObject MainMenu;
    public GameObject Nastroiki;
    public GameObject Mecege;
    public GameObject load;

    //public bool isFullScreen=true;
    void Start()
    {
        // Switch to 640 x 480 full-screen
       // Screen.SetResolution(1920, 1080, true);
    }
    public void PlayGame()
    {
        load.SetActive(true);
        SceneManager.LoadScene("open_curtscene");
        Time.timeScale = 1f;
        Cursor.visible = false;
        Stbutton.SetActive(false);

    }
    public void Brifing()
    {
        Briffing.SetActive(true);
        Stbutton.SetActive(true);
        MainMenu.SetActive(false);

    }

    public void Nastroki()
    {
        
     
        MainMenu.SetActive(false);
        Nastroiki.SetActive(true);

    }
    public void Sound()
    {
        Mecege.SetActive(true);
    }
    public void Zakr()
    {
        Mecege.SetActive(false);
    }
    public void IZnastrok()
    {


        MainMenu.SetActive(true);
        Nastroiki.SetActive(false);

    }

    /* public void FullScrin()
     {
         //isFullScreen = isFullScreen;
         Screen.fullScreen = isFullScreen;


     }

    

       public void Kachestvo(int q)
       {
          QualitySettings.SetQualityLevel(q);

       }
       Resolution[] rsl;
       List<string> resolutions;
       public Dropdown dropdown;

       public void Awake()
       {
           resolutions = new List<string>();
           rsl = Screen.resolutions;
           foreach(var i in rsl)
           {
               resolutions.Add(i.width + "x" + i.height);
           }
           dropdown.ClearOptions();
           dropdown.AddOptions(resolutions);
       }

       public void Resolution(int r)
       {
          Screen.SetResolution(rsl[r].width, rsl[r].height, isFullScreen);
       }
       
    */
    public void ExitGame()
    {
        Application.Quit(); 
    }
}
