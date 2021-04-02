using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordcol : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void del()
    {
        Destroy(GetComponent<Collider>());
    }
    void col()
    {
        gameObject.AddComponent(typeof(BoxCollider));
       
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("mouse 0"))
        {
            
            Invoke("del", 1f);
            Invoke("col", 0.2f);
             
             
             
        } 
            
    }
}
