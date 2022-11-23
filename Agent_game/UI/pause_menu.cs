using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class pause_menu : MonoBehaviour
{
    public static bool Pause = false;
    public End_game End_game;
    public trigers trigers;
    public HUD HUD;
    public ohranik ohranik;
    public Sprite obuch2;
    public GameObject pauseMenuUI;
    public GameObject EndMenuUI;
    public GameObject XUD;
    public GameObject bonus;
    public GameObject bonus2;
    public GameObject Obuch;
    public GameObject FailMenu;
    public float kd;
    public float failtimer;
    public bool obuch_pokaz = false;
    public bool proverka1 = false;

    public bool pokazano = false;
    public Text time;
    public Text Rang;
 
    // Start is called before the first frame update
    void Start()
    {
        failtimer = 5f;
        Cursor.visible = false;
        kd = 1f;
    }

    // Update is called once per frame
    void Update()
    {

      
        if(failtimer>0 && trigers.Fail == true) failtimer -= Time.deltaTime;
        if(trigers.Fail==true && failtimer <= 0)
        {
            Time.timeScale = 0f;
            XUD.SetActive(false);
            Cursor.visible = true;
            FailMenu.SetActive(true);
           
        }
        if (kd <= 0 && ohranik.obuch_triger == true && pokazano==false)
        {
            Obuch.GetComponent<Image>().sprite = obuch2;
            Obuch.SetActive(true);
            //kd = 2f;
            Time.timeScale = 0f;
            ohranik.obuch_triger = false;
            //obuch_pokaz = false;
            pokazano = true;

        }
        if (kd>0)kd -= Time.deltaTime;
        if (kd <= 0 && obuch_pokaz == false && pokazano == false)
        {
            Obuch.SetActive(true);
            Time.timeScale = 0f;
            //


        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Pause)
            {
                Resume();
            }
            else
            {
                Paused();
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Obuch.SetActive(false);
            proverka1 = true;
            obuch_pokaz = true;
            
           Time.timeScale = 1f;
        }
        if (End_game.End == true) {
            Time.timeScale = 0f;
            XUD.SetActive(false);
            Cursor.visible = true;
            EndMenuUI.SetActive(true);
            time.text = HUD.end_time;

            if (HUD.min <= 3 )if(End_game.NS == true || End_game.NS2 == true)
            {
                Rang.text = "Специалист";
                    if (End_game.NS == true) bonus.SetActive(true); else bonus2.SetActive(true);
            }
            else Rang.text = "Опытный";


            if (HUD.min <= 3 && End_game.NS == true && End_game.NS2==true)
            {
                Rang.text = "Профессионал";
                bonus.SetActive(true);
                bonus2.SetActive(true);
            }
            if (HUD.min>3&& HUD.min<=5 ) Rang.text = "Опытный";
          if ( HUD.min > 5) Rang.text = "Салага";



        }
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        Pause = false;
        Cursor.visible = false;
        XUD.SetActive(true);
    }
    void Paused()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        Cursor.visible = true;
        Pause = true;
        XUD.SetActive(false);
    }
    public void Restart()
    {
        SceneManager.LoadScene("level1");
        Time.timeScale = 1f;
        
        Pause = false;

    }
    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1f;
    }
    public void Clouse()
    {
        Obuch.SetActive(false);
        Time.timeScale = 1f;
    }


}
