using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pEntercode : MonoBehaviour
{
    private float numC1T = 0;
    private float numC2T = 0;
    private float numC3T = 0;
    private float numEnterT = 0;
   
    public bool rightCode = false;
    private float sum = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(numEnterT > 1){
            numEnterT = 0;
        }    
       
        codeCorrect();
        //if(rightCode){
      //  }

        

    }

    void codeCorrect(){
        if( numC1T == 2){
            sum++;
        }
        if( numC2T == 5){
            sum++;
        }
        if( numC3T == 4){
            sum++;
        }
        if( numEnterT == 1){
            sum++;
        }
       

        if(sum == 4){
            rightCode = true;
        }
    }
    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "code1T"){
            if(Input.GetKeyDown(KeyCode.E)){
                numC1T++;
            }
        }
        else if(other.gameObject.tag == "code2T"){
            if(Input.GetKeyDown(KeyCode.E)){
                numC2T++;
            }
        }
        else if(other.gameObject.tag == "code3T"){
            if(Input.GetKeyDown(KeyCode.E)){
                numC3T++;
            }
        }
        else if(other.gameObject.tag == "enterT"){
            if(Input.GetKeyDown(KeyCode.E)){
                numEnterT++;
            }
        }
       

    }
}
