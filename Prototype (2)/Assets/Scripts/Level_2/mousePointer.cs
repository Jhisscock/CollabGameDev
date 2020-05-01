using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mousePointer : MonoBehaviour
{ float smooth = 5.0f;
    float tiltAngle = 60.0f;

    void Update()
    {
        if(Input.GetKey("up")|| Input.GetKey("w"))
        {
           
            transform.Rotate(0, 0, 2);

            
         
        }
        

        if(Input.GetKey("down")|| Input.GetKey("s"))
        {   
          
             transform.Rotate(0, 0, -2f);

        
        }
    }
}
