using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class p1EnterCode : MonoBehaviour
{

    private float numC1B = 0;
    private float numC2B = 0;
    private float numC3B = 0;
    private float numEnterB = 0;
    public bool rightCode = false;
    private float sum = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(numEnterB > 1){
            numEnterB = 0;
        }
        codeCorrect();
        
    }

    void codeCorrect(){
         if( numC1B == 5){
            sum++;
        }
        if( numC2B == 0){
            sum++;
        }
        if( numC3B == 4){
            sum++;
        }
        if( numEnterB == 1){
            sum++;
        }
        if(sum == 4){
            rightCode = true;
        }
    }

     void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "code1B"){
            if(Input.GetKeyDown(KeyCode.E)){
                numC1B++;
            }
        }
        else if(other.gameObject.tag == "code2B"){
            if(Input.GetKeyDown(KeyCode.E)){
                numC2B++;
            }
        }
        else if(other.gameObject.tag == "code3B"){
            if(Input.GetKeyDown(KeyCode.E)){
                numC3B++;
            }
        }
        else if(other.gameObject.tag == "enterB"){
            if(Input.GetKeyDown(KeyCode.E)){
                numEnterB++;
            }
        }
       

    }
}
