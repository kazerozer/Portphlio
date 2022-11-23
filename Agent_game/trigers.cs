using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Управление персонажем, и его взаимодействия с обьектами


public class trigers : MonoBehaviour
{
    private Rigidbody2D rb;
    public bool atacked = false;
    public bool pereodet = false;
    public bool zasor = false;
    public bool postavleno=false;
    public bool end = false;
    public Animator anim;
    public Hunter Hunter;
    public shtora shtora;
    public uborshik uborshik;
    public povar povar;
    public razved_Chek razved_Chek;
    public Sup Sup;
    public Hamzi Hamzi;
    public Cia_agent_pent Cia_agent_pent;
    public string odegda;
    public double kd;
    public double Dkd;
    public double Celikd=2;
    public float palevnoTime;
    public float KabpalevnoTime;
    public int bonus2 = 0;




    public bool control_block = false;
    public bool ko = false;
    public bool Cia_ko = false;
    public float posY;
    public bool vPente = false;
    public bool svet_off = false;
    public bool otrav = false;
    public bool doki = false;
    public bool skazano = false;
    public bool slomano = false;
    public bool v_per = false;
    public bool KrisaShow = false;
    public bool Fail = false;
    public bool Hunt_dialog = false;
    public bool shit_open = false;
    public bool gazetPos = false;
    public bool Hide = false;
    public bool CIA_hiden = false;
    public bool Spawn_vedro = false;
    public bool vodka_try = false;
    public double namok;
    public string triger_name;
   
    public tyalet tyalet;
    public Transform[] trigerSpot;


    public bool curer_odeg_vzat = false;
    


    private bool luga = false;
    private bool vimito = false;
    public bool spawn = false;
    public float spawnTime = 0.1f;
    public GameObject pizza;
    public GameObject svet_dialog;
    public GameObject tyalet_voda;
    public GameObject food;
    public GameObject voda;
    public GameObject futbolka;
    public GameObject OrigPizza;
    public GameObject Vedro;
    public GameObject Vedro2;
    public GameObject dokum;
    public GameObject Vodka;
    public GameObject HuntDialog;
    public GameObject Rat_yad;
    private GameObject cL_Voda;
    private GameObject clonePizza;
    public GameObject XUD;
    public GameObject cel1;
    public GameObject cel1_check;
    public GameObject cel2_check;
    public GameObject cel2;
    public GameObject cel3;
    public GameObject ObLUGA;
    public GameObject molot;
    public GameObject oficiant;
    public GameObject CIA_agent;
    public GameObject Obed_stol;
    public GameObject Hunter_agent;
    public GameObject Hunter_pos;
    public GameObject Nelza;
    public GameObject Nelza2;

    public Text Deist;
    public Sprite bludo;
    public Sprite[] sp;
    
    



    public float speed = 2f;
    int x = 0;
    public string storona = "right";
    void Start()
    {
        odegda = "suit";

        Time.timeScale = 1f;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        posY = this.gameObject.transform.position.y;
        if (kd > 0) control_block = true;
        else if (Hide == true) control_block = true;
        else if (Fail == true) control_block = true;
        else control_block = false;

        if (control_block == true) anim.SetBool("dvig", false);

        if (Spawn_vedro == true && kd < 0.6)
        {
            clonePizza = Instantiate(Vedro, this.transform.position, Quaternion.identity);
            clonePizza.transform.Translate(-0.4f, -0.76f, 0f);
            clonePizza.gameObject.GetComponent<Renderer>().sortingOrder = 8;
            Spawn_vedro = false;
        }


        if (Hunter.dead == true)
        {
            cel1_check.SetActive(true); 
            
        }
        if (doki == true)
        {
            cel2_check.SetActive(true);
            
        }
        if( Celikd<=0)
        {
            cel1.SetActive(false);
            cel2.SetActive(false);
            cel3.SetActive(true);
        }

        if (luga == true && namok <= 0)
        {
            cL_Voda = Instantiate(voda, this.transform.position, this.transform.rotation);
            cL_Voda.transform.Translate(0f, -1.8f, 2.5f);
            if (storona == "left") FlipV();

            luga = false;


        }
        if (kd > 0) kd -= Time.deltaTime;
        if(doki == true && Hunter.dead == true)Celikd -= Time.deltaTime;
        if (Dkd > 0) Dkd -= Time.deltaTime;
        if (palevnoTime > 0) palevnoTime -= Time.deltaTime;
        if (KabpalevnoTime > 0) KabpalevnoTime -= Time.deltaTime;

        if (namok > 0) namok -= Time.deltaTime;



        if (Hunt_dialog ==true && Dkd<=0)HuntDialog.SetActive(true);


        //УПРАВЛЕНИЯ ПЕРСОНАЖОМ
        if (control_block == false)
        {


            if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
            {
                anim.SetBool("dvig", true);
                float moveY = Input.GetAxis("Vertical");
                float moveX = Input.GetAxis("Horizontal");
                
                var direction = new Vector2(moveX, moveY);
                rb.MovePosition(rb.position + direction * speed * Time.deltaTime);
            }
            else
            {
                anim.SetBool("dvig", false);
            }
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetAxis("Horizontal") < 0)
            {

                if (storona == "right")
                {
                    Flip();
                    
                    storona = "left";
                }


              

            }
            if (Input.GetKey(KeyCode.RightArrow) || Input.GetAxis("Horizontal") > 0)
            {
                if (storona == "left")
                {
                    Flip();
                    
                    storona = "right";
                }

              

            }

           

        }     
    }
	
	
	
   // РАБОТА ТРИГГЕРОВ
   
    void Update()
    {
        if (triger_name == "molotok" && curer_odeg_vzat==false )
        {
            XUD.SetActive(true);
            Deist.text = "[ПРОБЕЛ] Взять молоток";

            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.JoystickButton0))
            {
                XUD.SetActive(false);
                kd = 1;
                Destroy(molot, 0.5f);
                anim.SetTrigger("vzal_molot");
                odegda = "s_molotom";

            }
        }

        if (triger_name == "Rat_dead"&& odegda=="oficiant")
        {
            XUD.SetActive(true);
            Deist.text = "[ПРОБЕЛ] Взять Крысиный Яд";
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.JoystickButton0) )
            {
                XUD.SetActive(false);
                kd = 1;
                Destroy(Rat_yad, 0.4f);
                anim.SetTrigger("Beret_yad");
                odegda = "s_yadom";

            }
        }

        if (triger_name == "dver")
        {
            XUD.SetActive(true);
            Deist.text = "[ПРОБЕЛ] Зайти в пиццерию";
          if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.JoystickButton0))
            {
                
                
                transform.position = trigerSpot[18].position;

            }
        }

        if (triger_name == "backTo" )
        {
            XUD.SetActive(true);
            Deist.text = "[ПРОБЕЛ] Выйти на улицу";
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.JoystickButton0))
            {
                transform.position = trigerSpot[19].position;

            }
        }

        if (triger_name == "truba" && slomano == false)
        {
            XUD.SetActive(true);
            Deist.text = "[ПРОБЕЛ] Сорвать изоленту";

            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.JoystickButton0))
            {
                XUD.SetActive(false);
                kd = 1;
                if (storona == "left")
                {
                    Flip();
                    storona = "right";
                }
                anim.SetTrigger("Use");
                slomano = true;

            }
        }

        if (triger_name == "pizzaMan")
        {
            if (slomano == true)
            {
                XUD.SetActive(true);
                Deist.text = "[ПРОБЕЛ] Рассказать о поломке";

                if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.JoystickButton0))
                {
                    XUD.SetActive(false);

                    skazano = true;

                }
            }
        }

        if (triger_name == "podsobka")
        {
            if (skazano == true)
            {
                XUD.SetActive(true);
                Deist.text = "[ПРОБЕЛ] Зайти в раздевалку";

                if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.JoystickButton0))
                {

                    transform.Translate(0f, 12f, 0f);

                }
            }
        }

        if (triger_name == "futbolka")
        {
            XUD.SetActive(true);
            Deist.text = "[ПРОБЕЛ] Переодеться в курьера";
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.JoystickButton0))
            {
                curer_odeg_vzat = true;
                kd = 1;
                anim.SetTrigger("Use");
                Destroy(futbolka, 0.5f);
                XUD.SetActive(false);

                anim.SetBool("odegda_on", true);
                odegda = "pizzaM";

            }

        }

        if (triger_name == "back_to_pizza")
        {
            XUD.SetActive(true);
            Deist.text = "[ПРОБЕЛ] Выйти из раздевалки";

            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.JoystickButton0))
            {
                transform.Translate(0f, -12f, 0f);

            }
        }

        if (triger_name == "pizza")
        {

            if (odegda == "pizzaM")
            {
                XUD.SetActive(true);
                Deist.text = "[ПРОБЕЛ] Взять коробки с пиццей";

                if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.JoystickButton0))
                {
                    kd = 1;
                    transform.position = trigerSpot[20].position;
                    anim.SetTrigger("vzat");
                    Destroy(OrigPizza, 0.5f);
                    XUD.SetActive(false);
                    anim.SetBool("zakaz", true);
                    odegda = "pizza_zakaz";

                    if (storona =="right")
                    {
                        Flip();
                        storona = "left";
                    }
                }

            }

        }

        if (triger_name == "v_Otel")
        {
            if (odegda != "suit" && odegda != "s_molotom")
            {
                XUD.SetActive(true);
                Deist.text = "[ПРОБЕЛ] Зайти в отель";
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.JoystickButton0))
                {
                    transform.Translate(2f, 68f, 0f);

                }
            }
        }

        if (triger_name == "iz_otela")
        {
            if (ko == true || otrav == true) if (doki == true)
                {
                    XUD.SetActive(true);
                    Deist.text = "[ПРОБЕЛ] Выйти на улицу";
                    if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.JoystickButton0))
                    {

                        //transform.position = trigerSpot[5].position;
                        transform.Translate(-2f, -69f, 0f);



                    }
                }
                else
                {
                    XUD.SetActive(true);
                    Deist.text = "необходимо выполнить цели миссии";
                }
        }

        if (triger_name == "v_podsobky")
        {
            XUD.SetActive(true);
            Deist.text = "[ПРОБЕЛ] Зайти в подсобку";
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.JoystickButton0))
            {
                transform.Translate(0f, 20f, 0f);
            }
        }

        if (triger_name == "iz_podsobki")
        {
            XUD.SetActive(true);
            Deist.text = "[ПРОБЕЛ] Выйти из подсобки";
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.JoystickButton0))
            {
                transform.Translate(0f, -20f, 0f);
            }
        }

        if (triger_name == "v_pereulok_izOtela")
        {
            XUD.SetActive(true);
            Deist.text = "[ПРОБЕЛ] Выйти в переулок";
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.JoystickButton0))
            {
                transform.Translate(16f, -31f, 0f);
                v_per = true;
            }
        }

        if (triger_name == "v_rest_izPereulka")
        {
            XUD.SetActive(true);
            if (odegda == "oficiant")
            {
                Deist.text = "[ПРОБЕЛ] Зайти в ресторан Отеля";
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.JoystickButton0))
                {
                    transform.Translate(-16f, 31f, 0f);
                    if (shit_open == true)
                    {
                        povar.pers_ofic_triger = true;
                        povar.dialog_time = 5;

                    }
                }
            }
            else if(odegda == "ofc_s_body")
             {
                XUD.SetActive(true);
                Deist.text = "Избавьтесь от тела";
              }
            else Deist.text = "Заперто";
        }

        if (triger_name == "to_pent")
        {
            XUD.SetActive(true);
            Deist.text = "[ПРОБЕЛ] Подняться в пентхаус";
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.JoystickButton0))
            {
                if (odegda == "s_Vedrom" || odegda == "oficiant_food")
                {
                    transform.position = trigerSpot[4].position;
                    vPente = true;

                    //transform.Translate(0f, 48f, 0f);
                }
            }
        }

        if (triger_name == "to_hotel")
        {
            if (ko == true || otrav == true) if (doki == true)
                {
                    XUD.SetActive(true);
                    Deist.text = "[ПРОБЕЛ] В холл отеля";
                    if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.JoystickButton0))
                    {

                        transform.position = trigerSpot[5].position;
                   
                        //transform.Translate(0f, -47f, 0f);
                    }
                }
                else {
                     XUD.SetActive(true);
                     Deist.text = "необходимо выполнить цели миссии";
                     }
        }

        if (triger_name == "v_ofice")
        {
            XUD.SetActive(true);
            Deist.text = "[ПРОБЕЛ] Зайти в кабинет";
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.JoystickButton0))
            {
                transform.Translate(0f, 16f, 0f);
            }

        }

        if (triger_name == "to_pent_office")
        {
            XUD.SetActive(true);
            Deist.text = "[ПРОБЕЛ] Выйти в коридор";
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.JoystickButton0))
            {
                transform.Translate(0f, -17f, 0f);
                KabpalevnoTime = 1f;
            }
        }

        if (triger_name == "razdacha")
        {
            if (odegda == "pizza_zakaz")
            {
                XUD.SetActive(true);
                Deist.text = "[ПРОБЕЛ] Положить коробки";
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.JoystickButton0))
                {
                    XUD.SetActive(false);
                    kd = 1;
                    transform.position = trigerSpot[21].position;
                    if (storona == "left")
                    {
                        Flip();
                        storona = "right";
                    }
                    anim.SetBool("zakaz", false);
                    KrisaShow = true;
                    odegda = "pizzaM";
                    spawn = true;


                }

            }
        }

        if (spawn == true && spawnTime > 0) spawnTime -= Time.deltaTime;
        if (spawn == true && spawnTime <= 0)
        {
            clonePizza = Instantiate(pizza, pizza.transform.position, Quaternion.identity);
            spawn = false;

        }

        if (triger_name == "oficiant")
        {
            if (v_per == true)
            {
                XUD.SetActive(true);
                if (atacked == false)
                {

                    Deist.text = "[ПРОБЕЛ] Оглушить";
                }
                if (atacked == true && pereodet == false)
                {

                    Deist.text = "[ПРОБЕЛ] Переодеться и взять ключ";
                }

                if (pereodet == true)
                {

                    Deist.text = "[ПРОБЕЛ] Поднять";
                }
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.JoystickButton0))
                {
                    XUD.SetActive(false);
                    kd = 1;
                    if (atacked == true && pereodet == true)
                    {
                        anim.SetBool("with_body", true);
                        odegda = "ofc_s_body";
                        Destroy(oficiant, 0.2f);
                    }

                    if (atacked == true && pereodet == false)
                    {
                        if (odegda == "pizzaM")
                        {
                            anim.SetTrigger("pereodev");
                            anim.SetBool("oficiant", true);
                            odegda = "oficiant";
                            pereodet = true;
                            Destroy(clonePizza, .0f);
                            clonePizza = Instantiate(food, food.transform.position, Quaternion.identity);
                        }
                        else
                        {
                            anim.SetBool("oficiant", true);
                            odegda = "oficiant";
                            pereodet = true;
                        }
                    }

                    if (atacked == false)
                    {
                        transform.position = trigerSpot[1].position;
                        if (odegda == "pizzaM")
                        {
                            if (storona == "left")
                            {
                                Flip();
                                storona = "right";
                            }
                        }
                        else if (storona == "right")
                        {
                            Flip();
                            storona = "left";
                        }
                        anim.SetTrigger("atack");
                        atacked = true;
                    }



                }
            }
        }

        if (triger_name == "bak")
        {
            if (odegda == "suit" && Hide == false)
            {
                XUD.SetActive(true);
                Deist.text = "[ПРОБЕЛ] Спрятаться";
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.JoystickButton0))
                {

                    transform.position = trigerSpot[2].position;
                    anim.SetBool("musorka", true);
                    Hide = true;
                    kd = 1;


                }

            }
            if (odegda == "suit" && Hide == true&& kd<=0)
            {
                XUD.SetActive(true);
                Deist.text = "[ПРОБЕЛ] Вылезти";
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.JoystickButton0))
                {


                    anim.SetBool("musorka", false);
                    Hide = false;
                    kd = 1;


                }

            }
         

           
            if (odegda == "ofc_s_body")
            {
                XUD.SetActive(true);
                Deist.text = "[ПРОБЕЛ] Положить в мусорку";
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.JoystickButton0))
                {
                    
                    transform.position = trigerSpot[2].position;
                    anim.SetBool("with_body", false);
                    anim.SetTrigger("drop_body");
                    kd = 1;
                    bonus2++;
                    odegda = "oficiant";
                    XUD.SetActive(false);
                }
            }

        }

        if (triger_name == "food_to_hunter" && otrav == false)
        {
            XUD.SetActive(true);
            if (odegda == "s_yadom")
            { Deist.text = "[ПРОБЕЛ] Отравить пиццу"; }
            if (odegda == "oficiant" && postavleno == true && otrav == false)
                Deist.text = "[ПРОБЕЛ] Отравить пиццу (Необходимо Яд)";
            if (odegda == "oficiant" && postavleno == false)
                Deist.text = "[ПРОБЕЛ] Взять поднос";
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.JoystickButton0))
            {
                if (odegda == "s_yadom")
                {
                    XUD.SetActive(false);
                    transform.position = trigerSpot[14].position;
                    palevnoTime = 1f;
                    anim.SetTrigger("pizza_otrav");
                    odegda = "oficiant";
                    otrav = true;
                }
                if (odegda == "oficiant" && postavleno == false)
                {
                    kd = 1;
                    if (odegda == "oficiant")
                    {
                        XUD.SetActive(false);
                        anim.SetBool("s_food", true);
                        odegda = "oficiant_food";
                        Destroy(clonePizza, 0.3f);
                    }
                }
            }
        }

        if (triger_name == "stol_pent"&& odegda == "oficiant_food")
        {
            if (postavleno == false && razved_Chek.srabotal == true)
            {
                XUD.SetActive(true);
                Deist.text = "[ПРОБЕЛ] Поставить поднос";
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.JoystickButton0))
                {
                    if (storona == "left")
                    {
                        Flip();
                        storona = "right";
                    }

                    XUD.SetActive(false);
                    anim.SetBool("s_food", false);
                        transform.position = trigerSpot[14].position;
                        kd = 1;
                        postavleno = true;
                        Destroy(Obed_stol.GetComponent<BoxCollider2D>());
                   
                    clonePizza = Instantiate(food, trigerSpot[3].position, Quaternion.identity);
                        // clonePizza.transform.Translate(0f, 0f, 4f);
                        odegda = "oficiant";

                    
                }
            }
        }

        if (triger_name == "dockuments")
        {
            XUD.SetActive(true);
            Deist.text = "[ПРОБЕЛ] Взять документы";
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.JoystickButton0))
            {
                XUD.SetActive(false);
                kd = 1;
                doki = true;
                Destroy(dokum, 0.3f);
                anim.SetTrigger("dokum");
            }
        }

        if (triger_name == "v_pereulok")
        {
            XUD.SetActive(true);
            Deist.text = "[ПРОБЕЛ] Войти в переулок";
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.JoystickButton0))
            {
                transform.position = trigerSpot[22].position;
                if (storona == "right")
                {
                    Flip();
                    storona = "left";
                }
            }
        }


        if (triger_name == "shitok" && atacked ==false)
        {

            if (svet_off == false && shit_open == true)
            {
                XUD.SetActive(true);
                Deist.text = "[ПРОБЕЛ] Выключить свет";
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.JoystickButton0))
                {
                    kd = 1;
                    anim.SetTrigger("Use");
                    v_per = true;
                    svet_off = true;
                    Dkd = 4;
                    svet_dialog.SetActive(true);
                    XUD.SetActive(false);
                }
            }

            if (shit_open == false && curer_odeg_vzat==false)
            {
                if (odegda == "s_molotom")
                {
                    XUD.SetActive(true);
                    Deist.text = "[ПРОБЕЛ] Открыть щиток";
                    if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.JoystickButton0))
                    {
                        XUD.SetActive(false);
                        transform.position = trigerSpot[0].position;
                        if (storona == "right")
                        {
                            Flip();
                            storona = "left";
                        }
                        kd = 2;
                        anim.SetTrigger("biet_molot");
                        shit_open = true;
                        odegda = "suit";

                    }
                }
                else
                {
                    XUD.SetActive(true);
                    Deist.text = "[ПРОБЕЛ] Открыть щиток (Необходимо Молоток)";
                }
            }
            





        }

        if (svet_off == true && Dkd <= 0) { svet_dialog.SetActive(false); }





        if (triger_name == "v_rest")
        {
            XUD.SetActive(true);
            Deist.text = "[ПРОБЕЛ] Войти в ресторан";
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.JoystickButton0))
            {
                transform.Translate(0f, 20f, 0f);
            }
        }

        if (triger_name == "iz_resta")
        {
            XUD.SetActive(true);
            Deist.text = "[ПРОБЕЛ] Вернуться в холл";
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.JoystickButton0))
            {
                transform.Translate(0f, -22f, 0f);
                povar.pers_ofic_triger = false;
                povar.tek = 0;
            }
        }

        if (triger_name == "iz_perehoda")
        {
            if (odegda == "ofc_s_body") {
                XUD.SetActive(true);
                Deist.text = "Избавьтесь от тела";
            }
            else
            { XUD.SetActive(true);
                Deist.text = "[ПРОБЕЛ] Вернуться на улицу";
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.JoystickButton0))
                {
                    transform.position = trigerSpot[23].position;
                }
            }
        }

        if (triger_name == "v_kitch")
        {
            XUD.SetActive(true);
            Deist.text = "[ПРОБЕЛ] Зайти на кухню";
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.JoystickButton0))
            {
                transform.Translate(0f, 18f, 0f);
            }
        }

        if (triger_name == "to_pent_lkitc")
        {
            XUD.SetActive(true);
            Deist.text = "[ПРОБЕЛ] Выйти в коридор";
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.JoystickButton0))
            {
                transform.Translate(0f, -18f, 0f);
            }
        }



        if (triger_name == "to_gostin")
        {
            XUD.SetActive(true);
            Deist.text = "[ПРОБЕЛ] Войти в гостиную";
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.JoystickButton0))
            {
                transform.Translate(0f, 37f, 0f);
            }
        }

        if (triger_name == "to_pent_from_gost")
        {
            XUD.SetActive(true);
            Deist.text = "[ПРОБЕЛ] Выйти в коридор";
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.JoystickButton0))
            {
                transform.Translate(0f, -37f, 0f);
            }
        }

        if (triger_name == "uborshik")if( odegda=="oficiant"|| odegda == "s_vodka")
        {
            if (odegda == "s_vodka")
            {
                XUD.SetActive(true);
                Deist.text = "[ПРОБЕЛ] Отдать бутылку";
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.JoystickButton0))
                {
                    XUD.SetActive(false);
                    transform.position = trigerSpot[17].position;
                    if (storona == "left")
                    {
                        Flip();
                        storona = "right";
                    }
                    anim.SetBool("s_vodka", false);
                    uborshik.beret = true;
                    kd = 1;
                    odegda = "oficiant";
                  
                }

            }

            if (uborshik.spit == true && uborshik.razTime <= 0 && uborshik.razdet == false)
            { 
            XUD.SetActive(true);
            Deist.text = "[ПРОБЕЛ] Переодеться в уборщика";
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.JoystickButton0))
            {
                XUD.SetActive(false);
                kd = 1;
                odegda = "uborshik";
                uborshik.razdet = true;
                anim.SetTrigger("Use");
                anim.SetBool("ubor_odeg", true);
                    
                }
           }
        }

        if (triger_name == "vedro")
        {
            if (odegda == "uborshik")
            {
                XUD.SetActive(true);
                Deist.text = "[ПРОБЕЛ] Взять ведро со шваброй";
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.JoystickButton0))
                {
                    XUD.SetActive(false);
                    kd = 1;
                   // if (storona == "left")
                   // {
                    //    Flip();
                      //  storona = "right";
                   // }
                    anim.SetBool("vzal_vedro", true);
                    if (Vedro != null) Destroy(Vedro, 0.2f);
                   //Vedro.SetActive(false);
                   // Vedro2.SetActive(false);
                    //if (Vedro2 != null) Destroy(Vedro2, 0.2f);
                    //if (clonePizza != null) Destroy(clonePizza, 0.2f);
                    XUD.SetActive(false);
                    odegda = "s_Vedrom";
                }
            }
        }

        if (triger_name == "vedro2")
        {
            if (odegda == "uborshik")
            {
                XUD.SetActive(true);
                Deist.text = "[ПРОБЕЛ] Взять ведро со шваброй";
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.JoystickButton0))
                {
                    XUD.SetActive(false);
                    kd = 1;
                    // if (storona == "left")
                    // {
                    //    Flip();
                    //  storona = "right";
                    // }
                    anim.SetBool("vzal_vedro", true);
                    //if (Vedro != null) Destroy(Vedro, 0.2f);
                    //Vedro.SetActive(false);
                    // Vedro2.SetActive(false);
                    if (Vedro2 != null) Destroy(Vedro2, 0.2f);
                    //if (clonePizza != null) Destroy(clonePizza, 0.2f);
                    XUD.SetActive(false);
                    odegda = "s_Vedrom";
                }
            }
        }

        if (triger_name == "viski"&& vimito==false)
        {
            if (odegda == "s_Vedrom")
            {
                XUD.SetActive(true);
            Deist.text = "[ПРОБЕЛ] Вымыть лужу";

            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.JoystickButton0))
            {
                    
                    kd = 5;
                    if (storona == "left")
                    {
                        Flip();
                        storona = "right";
                    }
                    namok = 5;
                luga = true;
                    vimito = true;
                    transform.position = trigerSpot[11].position;
                    anim.SetTrigger("mochit");
                    anim.SetTrigger("moet");
                    
                    Destroy(ObLUGA, 4.8f);
                    XUD.SetActive(false);

            }

            }
        }

        if (triger_name == "balkon" && ko == false)
        {
            if (odegda == "s_Vedrom"&& vimito==true)
            {
                XUD.SetActive(true);
                Deist.text = "[ПРОБЕЛ] Намочить пол";
               
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.JoystickButton0))
                {
                    
                    kd = 5;
                    transform.position = trigerSpot[12].position;
                    if (storona == "left")
                    {
                        Flip();
                        storona = "right";
                    }
                    namok = 5;
                    luga = true;
                    anim.SetTrigger("mochit");
                    anim.SetTrigger("moet");
                    //anim.SetTrigger("kidaet");
                    anim.SetBool("vzal_vedro",false);
                    odegda = "uborshik";
                    XUD.SetActive(false);
                    ko = true;
                }

            }
        }

        if (triger_name == "tyalet" && zasor==false && odegda!= "oficiant_food")
        {
            XUD.SetActive(true);
            Deist.text = "[ПРОБЕЛ] Сломать унитаз";
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.JoystickButton0))
            {
                XUD.SetActive(false);
                transform.position = trigerSpot[13].position;
                if (storona == "right")
                {
                    Flip();
                    storona = "left";
                }
                zasor = true;
                anim.SetTrigger("Use");
                kd = 2f;

            }
        }

        if(odegda == "ofc_s_CIA_bodyV"&& kd < 0.3&& kd >=0 ) Vedro2.SetActive(true);
        if (triger_name == "cia_agent")
        {
            if (Cia_agent_pent.doshel == true && Cia_agent_pent.deistvie == "dumaet")
            {
                if (Cia_ko == true)
                {
                    XUD.SetActive(true);
                    Deist.text = "[ПРОБЕЛ] Поднять";

                    if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.JoystickButton0))
                    {
                        Nelza.SetActive(true);
                        Nelza2.SetActive(true);
                        XUD.SetActive(false);
                        kd = 1;
                        if (storona == "right")
                        {
                            Flip();
                            storona = "left";
                        }
                        if (odegda == "s_Vedrom")
                        {
                            
                           
                            anim.SetBool("with_CIA_body", true);
                            anim.SetBool("vzal_vedro", false);
                            odegda = "ofc_s_CIA_bodyV";
                            if (CIA_agent != null) Destroy(CIA_agent, 1f);
                        }
                        if(odegda=="uborshik")
                        {
                            anim.SetBool("with_CIA_body", true);
                            odegda = "ofc_s_CIA_bodyU";
                            if (CIA_agent != null) Destroy(CIA_agent, 0.2f);
                        }
                        if (odegda == "oficiant")
                        {
                            anim.SetBool("with_CIA_body", true);
                            odegda = "ofc_s_CIA_body";
                            if (CIA_agent != null) Destroy(CIA_agent, 0.2f);
                        }

                    }
                }
                if (Cia_ko == false)
                {
                    XUD.SetActive(true);
                    Deist.text = "[ПРОБЕЛ] Оглушить агента";
                    if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.JoystickButton0))
                    {
                        XUD.SetActive(false);
                        transform.position = trigerSpot[10].position;
                        if (storona == "right")
                        {
                            Flip();
                            storona = "left";
                        }
                        if (odegda!="s_Vedrom") transform.Translate(-0.4f, 0f, 0f);
                        Cia_ko = true;
                        anim.SetTrigger("atack");
                       // KoKd = 1.5;
                        kd = 1.5f;

                    }
                }
            }
        }


        if (triger_name == "Dush" && odegda != "oficiant_food")
        {
            if (CIA_hiden == false && Cia_ko == false)
            {
                if (Hide == false)
                {
                    XUD.SetActive(true);
                    Deist.text = "[ПРОБЕЛ] Спрятаться в Ванне";
                    if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.JoystickButton0))
                    {

                        anim.SetBool("dvig", false);
                        transform.position = trigerSpot[6].position;
                        if (storona == "left")
                        {
                            Flip();
                            storona = "right";
                        }
                        if (odegda!="oficiant") transform.Translate(0f, -0.05f, 0f);
                        Dkd = 1;
                        Hide = true;
                        shtora.close = true;
                        anim.SetBool("Hide", true);

                    }
                }
                if (Hide == true)
                {

                    Deist.text = "[ПРОБЕЛ] Выйти из Ванны";
                    if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.JoystickButton0))
                        if(Dkd <= 0)
                    {
                            XUD.SetActive(false);
                            kd = 0.5;
                        transform.position = trigerSpot[6].position;
                        if (odegda != "oficiant") transform.Translate(0f, -0.05f, 0f);
                        Hide = false;
                        shtora.close = false;
                        shtora.shtorakd = 0.3;
                        anim.SetBool("Hide", false);

                    }
                }
            }
            if (odegda == "ofc_s_CIA_body")
            {
                XUD.SetActive(true);
                Deist.text = "[ПРОБЕЛ] Спрятать в Ванне";
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.JoystickButton0) && Dkd <= 0)
                {
                    Nelza.SetActive(false);
                    Nelza2.SetActive(false);
                    kd = 0.5;
                    transform.position = trigerSpot[7].position;
                    if (storona == "left")
                    {
                        Flip();
                        storona = "right";
                    }
                    shtora.close = true;
                    bonus2++;
                    anim.SetBool("with_CIA_body", false);
                    shtora.body = true;
                    CIA_hiden = true;

                    odegda = "oficiant";
                }
            }

                if (odegda == "ofc_s_CIA_bodyV" || odegda == "ofc_s_CIA_bodyU")
                {
                    XUD.SetActive(true);
                    Deist.text = "[ПРОБЕЛ] Спрятать в Ванне";
                    if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.JoystickButton0) && Dkd <= 0)
                    {
                    Nelza.SetActive(false);
                    Nelza2.SetActive(false);
                    XUD.SetActive(false);
                     kd = 0.5;
                        transform.position = trigerSpot[7].position;
                    if (storona == "left")
                    {
                        Flip();
                        storona = "right";
                    }
                    transform.Translate(0f, -0.34f, 0f);
                        shtora.close = true;
                        anim.SetBool("with_CIA_body", false);
                        shtora.body = true;
                        CIA_hiden = true;
                    bonus2++;
                    odegda = "uborshik";
                    }

                }




            }

        if (triger_name == "NELZA2")
        {
            XUD.SetActive(true);
            Deist.text = "Избавьтесь от тела";
        }

        if (triger_name == "Itan_Hunter" && odegda != "oficiant_food")
        {

            if (Hunter.stoitTime > 0 && Hunter.stoitTime < 5)
            {
                XUD.SetActive(true);
                if (odegda == "s_Vedrom")
                {
                    Deist.text = "[ПРОБЕЛ] Атаковать";
                    if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.JoystickButton0))
                    {
                        XUD.SetActive(false);
                        anim.SetTrigger("dushit");
                        transform.position = trigerSpot[9].position;
                        Destroy(Hunter_agent, 0.8f);
                        Fail = true;
                        Hunt_dialog = true;
                        Dkd = 1;
                        if (Hunter.pos == 10)
                        {
                            if (storona == "right")
                            {
                                Flip();
                                storona = "left";
                            }
                            transform.Translate(2f, 0f, 0f);
                        }
                        else
                        {
                            transform.Translate(-2f, 0f, 0f);
                            if (storona == "left")
                            {
                                Flip();
                                storona = "right";
                            }
                        }
                    }
                }

                else
                {
                    Deist.text = "[ПРОБЕЛ] Задушить";
                    if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.JoystickButton0))
                    {

                        anim.SetTrigger("dushit");
                        transform.position = trigerSpot[9].position;
                        if (Hunter.pos == 10)
                        {
                            if (storona == "right")
                            {
                                Flip();
                                storona = "left";
                            }
                            
                        }
                        else
                        {
                           
                            if (storona == "left")
                            {
                                Flip();
                                storona = "right";
                            }
                        }
                        Destroy(Hunter_agent, 0.2f);
                        Fail = true;
                        Hunt_dialog = true;
                        Dkd = 1;
                        HuntDialog.transform.Translate(-1.9f, 0f, 0f);
                    }
                }
            }
            if (Hunter.smokeTime > 0 && Hunter.smokeTime < 10)
            {
                XUD.SetActive(true);
                Deist.text = "[ПРОБЕЛ] Столкнуть";
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.JoystickButton0))
                {
                    XUD.SetActive(false);
                    anim.SetTrigger("tolkaet");
                    transform.position = trigerSpot[8].position;
                    if (storona == "left")
                    {
                        Flip();
                        storona = "right";
                    }
                    if (odegda == "s_Vedrom") Destroy(Hunter_agent, 1f);
                    else Destroy(Hunter_agent, 0.2f);
                    Fail = true;
                    Hunt_dialog = true;
                    Dkd = 1;
                    //  transform.Translate(0f, 0f, 0f);
                }
            }
        }

        if (triger_name == "sup" && Sup.sgorel==false && vodka_try == true )
        {
            
                XUD.SetActive(true);
                Deist.text = "[ПРОБЕЛ] Сжечь суп";
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.JoystickButton0))
            {
                XUD.SetActive(false);
                kd = 1;
                anim.SetTrigger("Use");
                transform.position = trigerSpot[24].position;
                if (storona == "right")
                {
                    Flip();
                    storona = "left";
                }
                Sup.sgorel = true;
                Sup.garTime = 2f;
                triger_name = "net";
            }

         }

        if (triger_name == "vodka")
        {

            XUD.SetActive(true);
            Deist.text = "[ПРОБЕЛ] Взять водку";
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.JoystickButton0))
            {
                XUD.SetActive(false);
                if (Hamzi.react == false)
                {
                    vodka_try = true;
                    Hamzi.ugroz = true;
                    Hamzi.reactTime = 3f;
                    anim.SetTrigger("vodka_try");
                }


                if (Hamzi.react == true)
                {
                    XUD.SetActive(false);
                    if (storona == "left")
                    {
                        Flip();
                        storona = "right";
                    }
                    anim.SetBool("s_vodka", true);
                    Destroy(Vodka, 0.2f);
                    odegda = "s_vodka";
                    triger_name = "net";
                }
            }
        }

        if (triger_name == "Kitch_dver")
        {
            
                XUD.SetActive(true);
                Deist.text = "[ПРОБЕЛ] Зайти на кухню";
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.JoystickButton0))
                {
                    if(odegda=="oficiant" || odegda == "s_vodka") transform.position = trigerSpot[15].position;

                }
        }
        if (triger_name == "v_rest_iz_kithch")
        {

            XUD.SetActive(true);
            Deist.text = "[ПРОБЕЛ] Выйти из кухни";
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.JoystickButton0))
            {
               transform.position = trigerSpot[16].position;

            }
        }

       

        if (triger_name == "End_car")
        {
            if (doki == true)
            {
                XUD.SetActive(true);
                Deist.text = "[ПРОБЕЛ] Закончить миссию";
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.JoystickButton0))
                {
                   
                    end = true;
                }
                
            }
        }

        //if (zasor == true && kd <= 0) tyalet_voda.SetActive(true);

        if (triger_name == "net")
        {
            XUD.SetActive(false);

        }
    }

   // ВЗАИМОДЕЙСТВИЯ С ОБЬЕКТАМИ

    void OnTriggerStay2D(Collider2D other)
    {       
       
        if (other.CompareTag("viski"))
        {
            triger_name ="viski";
        }

        if (other.CompareTag("molotok"))
        {
            triger_name = "molotok";
        }

        if (other.CompareTag("dver"))
        {
            triger_name = "dver";
        }

        if (other.CompareTag("backTo"))
        {
            triger_name = "backTo";
        }

        if (other.CompareTag("truba"))
        {
            triger_name = "truba";
        }

        if (other.CompareTag("pizzaMan"))
        {
            triger_name = "pizzaMan";
        }

        if (other.CompareTag("podsobka"))
        {
            triger_name = "podsobka";
        }

        if (other.CompareTag("futbolka"))
        {
            if ( curer_odeg_vzat ==false) triger_name = "futbolka";
            else triger_name = "net";
        }

        if (other.CompareTag("back_to_pizza"))
        {
            triger_name = "back_to_pizza";
        }

        if (other.CompareTag("pizza"))
        {
            triger_name = "pizza";
        }

        if (other.CompareTag("v_Otel"))
        {
            triger_name = "v_Otel";
        }

        if (other.CompareTag("iz_otela"))
        {
            triger_name = "iz_otela";
        }

        if (other.CompareTag("v_podsobky"))
        {
            triger_name = "v_podsobky";
        }

        if (other.CompareTag("iz_podsobki"))
        {
            triger_name = "iz_podsobki";
        }

        if (other.CompareTag("v_pereulok_izOtela"))
        {
            triger_name = "v_pereulok_izOtela";
        }

        if (other.CompareTag("v_rest_izPereulka"))
        {
            triger_name = "v_rest_izPereulka";
        }

        if (other.CompareTag("to_pent"))
        {
            triger_name = "to_pent";
        }

        if (other.CompareTag("to_hotel"))
        {
            triger_name = "to_hotel";
        }

        if (other.CompareTag("v_ofice"))
        {
            triger_name = "v_ofice";
        }

        if (other.CompareTag("to_pent_office"))
        {
            triger_name = "to_pent_office";
        }

        if (other.CompareTag("razdacha"))
        {
            triger_name = "razdacha";
        }

        if (other.CompareTag("oficiant"))
        {
            triger_name = "oficiant";
        }

        if (other.CompareTag("bak"))
        {
            triger_name = "bak";
        }

        if (other.CompareTag("Rat_dead"))
        {
            triger_name = "Rat_dead";
        }

        if (other.CompareTag("food_to_hunter"))
        {
            triger_name = "food_to_hunter";
        }

        if (other.CompareTag("stol_pent"))
        {
            triger_name = "stol_pent";
        }

        if (other.CompareTag("dockuments"))
        {
            if (doki == false) triger_name = "dockuments";
            else triger_name = "net";
            
        }

        if (other.CompareTag("v_pereulok"))
        {
            triger_name ="v_pereulok";
        }

        if (other.CompareTag("shitok"))
        {
            triger_name = "shitok";
        }
        if (other.CompareTag("v_rest"))
        {
            triger_name = "v_rest";
        }

        if (other.CompareTag("iz_resta"))
        {
            triger_name = "iz_resta";
        }

        if (other.CompareTag("iz_perehoda"))
        {
            triger_name = "iz_perehoda";
        }

        if (other.CompareTag("v_kitch"))
        {
            triger_name = "v_kitch";
        }

        if (other.CompareTag("to_pent_lkitc"))
        {
            triger_name ="to_pent_lkitc";
        }

        if (other.CompareTag("to_gostin"))
        {
            triger_name = "to_gostin";
        }

        if (other.CompareTag("to_pent_from_gost"))
        {
            triger_name = "to_pent_from_gost";
        }

        if (other.CompareTag("uborshik"))
        {
            triger_name = "uborshik";
        }

        if (other.CompareTag("vedro"))
        {
            triger_name = "vedro";
        }
        if (other.gameObject.name == "vedro2")
        {
            triger_name = "vedro2";
        }
        if (other.CompareTag("balkon"))
        {
            triger_name = "balkon";
        }
        if (other.CompareTag("End_car"))
        {
            triger_name = "End_car";
        }
        if (other.CompareTag("larek"))
        {
            gazetPos = true;
        }
        if (other.CompareTag("tyalet"))
        {
            triger_name = "tyalet";
        }
        if (other.CompareTag("cia_agent"))
        {
            triger_name = "cia_agent";
        }

        if (other.CompareTag("Dush"))
        {
            triger_name = "Dush";
        }
        if (other.CompareTag("Itan_Hunter"))
        {
            if(Fail==false)triger_name = "Itan_Hunter";
            else triger_name = "net";
        }

        if (other.gameObject.name == "kitchen_sup")
        {
            triger_name = "sup";
        }

        if (other.gameObject.name == "vodka")
        {
            triger_name = "vodka";
        }
        if (other.gameObject.name == "Kitch_dver")
        {
            triger_name = "Kitch_dver";
        }

        if (other.gameObject.name == "v_rest_iz_kithch")
        {
            triger_name = "v_rest_iz_kithch";
        }
        if (other.gameObject.name == "NELZA2")
        {
            triger_name = "NELZA2";
        }



    }

    void OnTriggerExit2D(Collider2D other)
    {
        
        triger_name = "net";
    }

    public void FlipV()
    {

        Vector3 Scalet = cL_Voda.transform.localScale;
        Scalet.x *= -1;
        cL_Voda.transform.localScale = Scalet;
    }

    public void Flip()
    {

        Vector3 Scalet = transform.localScale;
        Scalet.x *= -1;
        transform.localScale = Scalet;
        
       

    }





}






}
