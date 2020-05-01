using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Broom : MonoBehaviour
{
    public GameObject GM;
    public GameObject otherBroom;
    private bool inBroom;
    // Start is called before the first frame update
    void Start()
    {
        inBroom = false;
    }

    void Update(){
        if(inBroom && Input.GetKeyDown(KeyCode.E)){
            this.gameObject.SetActive(false);
            otherBroom.SetActive(true);
            GM.GetComponent<Room_2>().gotBroom = true;
        }
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Player"){
            inBroom = true;
        }
    }

    void OnTriggerExit2D(Collider2D other){
        if(other.gameObject.tag == "Player"){
            inBroom = false;
        }
    }
}
