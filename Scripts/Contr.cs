using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Contr : MonoBehaviour
{
    Animator anim;
    float vert;
    float hor;
    float runFl;
    float runFr;   
    float argg; 
    float hp2 = 1;
    int gud = 0;
    int hpx = 100;
    int z = 0;
    int e = 0;

    public Text txttimer;
    public Text txthp;
    public GameObject restart;
    public GameObject exit;
    public GameObject bg;
    static int time = 120;
    
    // Start is called before the first frame update
    void Start()
    {
       
        anim = GetComponent<Animator>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        InvokeRepeating("Timer", 0f, 1f);
       


        
                
    }
    public void Poluchatel(float arg) 
    {
        
        argg = arg;
    }
    void Timer()
    {
        time = time - 1;
        print(time);
        txttimer.text = "Time: " + time;
    }
    void hurtfalse()
    {
         anim.SetBool("hurt", false);
    }
    void end()
    {
         print("wasted");
         anim.SetBool("ded", false);
         SceneManager.LoadScene("wasted");
    }
     void end2()
    {
         Time.timeScale = 0f;
    }
    public void Poluchatel2(float arg2) 
    {
        
        if(arg2 == 1 && z == 0)
        {
            anim.SetBool("hurt", true);
            Invoke("hurtfalse", 0.5f);
            if (gud == 0)
            {
                hpx -= 10;
                txthp.text = "hp: " + hpx;
                if (hpx == 0)
                {
                    z = 1;
                }

            }
            
        }
        
    }
    void esc()
    {
        e = 1;
    } 
    void OnCollisionEnter(Collision collision)
      {
    
        if (collision.gameObject.tag == "Finish")
        {
            SceneManager.LoadScene("SampleScene");

        } 
    
    }
       // Update is called once per frame
    void Update()
    {
        vert = Input.GetAxis("Vertical");
        hor = Input.GetAxis("Horizontal");

        if (hpx == 0)
        {
            z = 1;
            anim.SetBool("ded", true);
            
            
            Invoke("end", 4f);
            
        }
       

        anim.SetFloat("runF", vert);
        anim.SetFloat("runB", vert);
        runFl = 5 * hor * vert;
        anim.SetFloat("runR", hor);
        anim.SetFloat("runL", hor);

         

        transform.rotation = Quaternion.Euler(0,argg,0);

        if (Input.GetKey("mouse 0"))
        {
             anim.SetBool("punch",true);
             
             
        } else{
            anim.SetBool("punch",false);
            
        }
        if (Input.GetKeyDown("escape") && e == 0)
        {

            restart.SetActive(true);
            exit.SetActive(true);
            bg.SetActive(true);
            Invoke("esc", 0.00001f);
            Time.timeScale = 0.01f; 
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;        
        }
        if (Input.GetKeyDown("escape") && e == 1)
        {
            restart.SetActive(false);
            exit.SetActive(false);
            bg.SetActive(false);
            e = 0;
            Time.timeScale = 1f;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        
         if (Input.GetKey("x"))
        {
             anim.SetBool("dmg",true);
            
             
        } else{
            anim.SetBool("dmg",false);
            
        }
        if (Input.GetKey("space"))
        {
             anim.SetBool("jump",true);
             
        } else{
            anim.SetBool("jump",false);
            
        }
        if (Input.GetKey("space"))
        {
             anim.SetBool("jumpf",true);
             
        } else{
            anim.SetBool("jumpf",false);
            
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
             anim.SetBool("guard",true);
             gud = 1;
             
        } else{
            anim.SetBool("guard",false);
            gud = 0;
            
        }
    



        
        //if(Input.GetKey("1"))
        //{
        //     anim.SetBool("Pod",true);
        //} else{
        //    anim.SetBool("Pod",true);
        //}
        //if(vert > 0)
        //{
        //   anim.SetBool("Walk",true);
        //    print("sf");
        //} else 
        //{
        //    anim.SetBool("Walk",false);
        //    print("sf2");
        //}
    }
    
}
