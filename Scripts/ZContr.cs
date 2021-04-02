using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZContr : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform dest;
    int hp = 40;
    int hpx = 100;
    int x = 0;
    static float y;
    static float z;
    Animator anim;
    void Start()
    { 
        anim = GetComponent<Animator>();
    }
    void vozr()
    {
        y = Random.Range(-27f,4);
        z = Random.Range(-69,-43);
        Instantiate(gameObject, new Vector3(y,0,z), transform.rotation);
        Destroy(gameObject);

    }
    void mail()
    {
        FindObjectOfType<Contr>().Poluchatel2(x);
    }
    void punf()
    {
        anim.SetBool("punch", false);
        
        x = 0;
        
        
    }
    void hurf()
    {
        anim.SetBool("hit", false);
       
    }
    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(dest.position); 
         
    }
     void OnCollisionEnter(Collision collision)
    {
    if (collision.gameObject.tag == "swordd")
        {
            anim.SetBool("hit", true);
            hp -= 20;
            Invoke("hurf", 0.5f);
            if(hp <= 0)
            {
                anim.SetBool("hpene", true);
                Invoke("vozr", 1f);
            }
            
        } 
        if (collision.gameObject.tag == "Player")
        {
            x = 1;
            
            Invoke("mail", 0.5f);
            
            anim.SetBool("punch", true);
            Invoke("punf", 0.5f);


        } 
    
    }
    
    
}
