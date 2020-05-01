using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flashApear : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject clue;
    void Start()
    {
        clue.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "clue"){
            clue.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other){
        if(other.gameObject.tag == "clue"){
            clue.SetActive(false);
        }
    }
}
