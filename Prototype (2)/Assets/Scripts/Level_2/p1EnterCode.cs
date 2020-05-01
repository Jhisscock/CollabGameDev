using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class p1EnterCode : MonoBehaviour
{
    public GameObject wrong;
    private int numC1B = 0;
    private int numC2B = 0;
    private int numC3B = 0;
    private int numEnterB = 0;
    public bool rightCode = false;
    private string sum = "";
    private float a= 0;
   
    private bool b1 = false,b2 = false,b3 = false,b4 = false;
    // Start is called before the first frame update
    void Start()
    {
        wrong.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(b1 && Input.GetKeyDown(KeyCode.E)){
            numC1B++;
        }else if(b2 && Input.GetKeyDown(KeyCode.E)){
            numC2B++;
        }else if(b3 && Input.GetKeyDown(KeyCode.E)){
            numC3B++;
        }else if(b4 && Input.GetKeyDown(KeyCode.E)){
            numEnterB++;
            a++;
        }
        rightCode = codeCorrect();
        if(rightCode == false  && a == 1){
            numC1B = 0;
            numC2B = 0;
            numC3B = 0;
            numEnterB = 0;
            a--;
            wrong.SetActive(true);    
            
        
         

        }
    }

    bool codeCorrect(){
        sum = numC1B.ToString() + numC2B.ToString() + numC3B.ToString() + numEnterB.ToString();
        if(sum == "5071"){
            wrong.SetActive(false); 
            return true;
        }else{
            return false;
        }
         if(rightCode == false){
            numC1B = 0;
            numC2B = 0;
            numC3B = 0;
            numEnterB = 0;
        
            wrong.SetActive(true);

        }
    }


    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "code1B"){
            b1 = true;
        }
        else if(other.gameObject.tag == "code2B"){
            b2 = true;
        }
        else if(other.gameObject.tag == "code3B"){
            b3 = true;
        }
        else if(other.gameObject.tag == "enterB"){
            b4 = true;
        }
    }

    void OnTriggerExit2D(Collider2D other){
        if(other.gameObject.tag == "code1B"){
            b1 = false;
        }
        else if(other.gameObject.tag == "code2B"){
            b2 = false;
        }
        else if(other.gameObject.tag == "code3B"){
            b3 = false;
        }
        else if(other.gameObject.tag == "enterB"){
            b4 = false;
        }
    }
}
