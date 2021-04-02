using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeadContr : MonoBehaviour
{
    Transform head_tr;
    
    float MouseX;
    float MouseY;
    public float sens = 3f;
    
    void Start()
    {
        head_tr = GetComponent<Transform>();
    }


    void Update()
    {
        MouseX = MouseX + Input.GetAxis("Mouse X") * sens;
        MouseY = MouseY - Input.GetAxis("Mouse Y") * sens;

        MouseY = Mathf.Clamp(MouseY, -90, 90);

        head_tr.rotation = Quaternion.Euler(MouseY, MouseX, 0);

        FindObjectOfType<Contr>().Poluchatel(MouseX);

       
    }
}
